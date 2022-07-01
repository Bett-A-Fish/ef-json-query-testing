# Entity Framework Vs Json Queries

## Contents

- [Entity Framework Vs Json Queries](#entity-framework-vs-json-queries)
  - [Contents](#contents)
  - [Data Model](#data-model)
  - [Test Data](#test-data)
    - [CreateBogusData.cs](#createbogusdatacs)
  - [Search Patterns](#search-patterns)
    - [Json Patterns](#json-patterns)
    - [Dynamic Patterns](#dynamic-patterns)
  - [Running](#running)
    - [Additional notes](#additional-notes)
  - [Available Benchmarks](#available-benchmarks)
    - [Single search](#single-search)
    - [Multi search](#multi-search)
  - [Results](#results)
    - [LessRandomBenchmarks.cs](#lessrandombenchmarkscs)
    - [other](#other)

## Data Model

I'm using the below structure to mimic what an ad hock query builder could use for testing user created queries.
![Ad hock query builder structure](readme%20files/dataModel/querybuilder.png)

The structure for testing searching where each bit of information is saved as a seprate row in a table
![Dynamic table structure](readme%20files/dataModel/media.png)

The structure for testing searching with the information stored in JSON
![Json table structure](readme%20files/dataModel/json.png)

Note: The dynamic table and json structures are separated into different models: `Media_Dynamic` and `Media_Json`

Sad Note: At some point `Media_Dynamic` started getting refered to as just media. While `Media_Json` is refered to as json. Tying to get this cleaned up.

## Test Data

I'm using [Bogus](https://github.com/bchavez/Bogus) with a hardcoded seed value to easily create lots of consistent semi-realistic looking data to add into the above data structures. `Media_Dynamic` is created then a selection of `DynamicFields` are used to generate data for the media item into `DynamicMediaInformation`. When all items for `Media_Dynamic` are done, this information is duplicated into `Media_Json` to reduce variables when testing search patterns.

Two large bacpac files have been included that were used to benchmark these search patterns: `ef_testing_index_large.bacpac` and `ef_testing_string_large.bacpac`. The first uses a generated list of 50 different fields including the types: int, bool, date, string. The second is 40 fields of only strings. Both have 100,000 generated rows of data. A new set can be generated with your own seed and data counts using `CreateBogusData.cs`

### CreateBogusData.cs

The field `FakerSeed` is the seed used for generating the bogus data.

`LoadAllData` Can be called to fill the whole database in one go. `fieldsCount` Will be the list of available dynamic fields each datarow has available with random datatypes and sets if the fields are required or optional. `mediaItemsCount` Is the total number of datarows to be able to search over which will be created for one table structure and duplicated into the other. `listTypeCount` For generating some dropdown types and the list of options available for each.

`LoadSharedData` Loads the data for the ad hock query builder portion of the database. Filling out the available fields a datarow can contain. The parameters are the same as above.

`LoadMediaData` Loads the data for the Dynamic and Json tables for running searches against. First it will create data for the dynamic table, then copy that data into the json table.

Some extra private "large" versions of methods are included that I used to generate the massive bacpac files that have been included. These were only temporarily called and are not currently used. (Needed to pause regularly for my laptop to cool down.)

## Search Patterns

Multiple search pattern types were created to see what varients were most efficient. The intent is to see how each handles different search patterns, however all of the below are currently only setup to handle a basic `AND` search rather than the full query builder outlined above. For each pattern, unit tests were added to allow easily checking their validity along with how they each handle bad user input using [NaughtyStrings](https://github.com/SimonCropp/NaughtyStrings). As benchmarking has progressed, more varients have been added and older ones deemed consistently worse than similar counterparts were moved out of the way into `SearchServiceOld.cs`.

### Json Patterns

- `JsonSearch_Indexed_NoColumns`
  - Not a big change from `JsonSearch_Indexed` but a business decision changed the information needed to be brought back from the server.
- `JsonSearch_Indexed_NoColumns_StringAdjustment`
  - An attempt to see if searching on optional strin fields could be sped up
- `JsonSearch_Indexed`
  - Similar to `JsonSearch_Raw` but with columns being indexed
  - Note: the testing is setup to make an index for each field but the intention for a production environment would be to only add indexing to the needed fields.
- `JsonSearch_Raw`
  - Dynamically generated sql ran with ef
  - Uses parametrized values to avoid sql injection.
- `JsonSearch_EfMagic`
  - Through custom EF functions, a query is generated.

### Dynamic Patterns

- `TableSearch_Media_NoColumns`
  - Similar to `TableSearch_Media` but a lot faster with much less data to be returned.
  - note: business decision changed the information needed to be brought back from the server.
- `TableSearch_Media`
  - Uses EF to search the database. Uses `Includes` to get the field information back from the server.
- `TableSearch_Media_RestrictedColumns`
  - Similar to `TableSearch_Media` but with the option to restrict how many columns are returned.
- `TableSearch_Media_SplitQuery`
  - Similar to `TableSearch_Media` but with the use of EF's `SplitQuery` function instead of `Includes`
- `TableSearch_Media_TwoQueries`
  - Similar to `TableSearch_Media` but intentionally splits the query into two queries. One to get the list of matching id's and the second to get the column information.

## Running

Benchmarks can be setup in `Program.cs` file.

For running with a debugger:

```C#
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly)
            .Run(args, new DebugInProcessConfig()
                .AddFilter(new AnyCategoriesFilter(new string[] { "miss" }))
                );
```

For running a proper benchmark test:

```C#
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly)
            .Run(args, DefaultConfig.Instance
                //.AddFilter(new AnyCategoriesFilter(new string[] { "indexed" }))
                //.AddFilter(new AllCategoriesFilter(new string[] { "lessrand", "set1" }))
                .AddExporter(RPlotExporter.Default)
                .AddColumn(CategoriesColumn.Default)
                );
```

Run with the command `dotnet run -c Release`

Using `AnyCategoriesFilter` and `AllCategoriesFilter` can help narrow which tests can run when doing benchmarking. `AnyCategoriesFilter` will run any test that matches at least one category in the list and `AllCategoriesFilter` will require all listed to be included.

### Additional notes

In `BaseBenchmark.cs` file, changing `EfTestDbContext.Create(false)` to `true` will print out what queries are being ran.

`LessRandomBenchmarksTestReturns` can be used to prove that `JsonSearch_Indexed` and `TableSearch_Media` return the same data for the same search inputs.

Unit tests are included to make sure each search works as expected and can handle bad user data.

## Available Benchmarks

- Single search
- Multi search
  - Hard coded value tests
  - Random value tests

### Single search

Single search was mainly used for the original setup of benchmark dotnet and getting a basis started for search patterns. All of these were quickly dropped for multi search versions if possible. Though these arent used anymore, they are still available.

### Multi search

This section has te hard coded and random sections. Originally random values were used for testing but realized the consistency of choosing what would be returned was also valuable information to these tests. So added the hard coded section of tests. The random tests can be used with any database. The hard coded ones can be used with the provided bacpac file: `ef_testing_index_large.bacpac`. Except for `StringBenchmarks.cs` which needs the other bacpac to work: `ef_testing_string_large.bacpac`.

- Column Count
  - Tests the `RestrictedColumns` search pattern
  - Categories: `table`, `columncount`, `first`, `set1`, `set2`, `count10`, `count25`, `countall`
- Date Field
  - Tests the normal and `NoColumns` versions of the search patterns against date fields
  - Categories: `table`, `json`, `hascolumns`, `nocolumns`, `first`, `set1`, `set2`, `set3`
- Less Random
  - Tests the normal search patterns
  - Categories: `table`, `json`, `first`, `last`, `set1`, `set2`
- Misc
  - Tests the normal and `NoColumns` versions of the search patterns against some of the datasets that had larger differences in search times
  - Categories: `indexed`, `media`, `AllColumns`, `NoColumns`, `#fields` (1,2,3,4,5,6,7,9), `both`, `req`, `op`, `date`, `int`, `bool`, `string`
- No Columns
  - Tests normal and `NoColumns` versions of the search patterns
  - Categories: `table`, `json`, `hascolumns`, `nocolumns`, `first`, `last`, `set1`, `set2`
- Split Query
  - Tests the normal json against the normal, `SplitQuery`, and `TwoQueries` verions of the dynamic search patterns
  - Categories: `table`, `json`, `indexed`, `media`, `media2`, `mediasplit`, `first`, `last`, `set1`, `set2`
- String
  - Tests only `NoColumn` search patterns against different sets of string search values
  - Categories: `media`, `json`, `req`, `op`, `both`, `one`, `two`, `three`, `four`, `five`, `six`, `seven`, `eight`, `buildupon`, `shortstring`, `longstring`, `charcount`, `ten`, `twelve`, `fourteen`, `sixteen`, `withint`

## Results

### LessRandomBenchmarks.cs

The below results utilize the included bacpac file and use the `LessRandomBenchmarks.cs` benchmarks. Which is a set of hardcoded test data with the aim of getting specific sets of data. It uses only two of the listed search patterns that turned out to be the fastest overall for their individual groups. `JsonSearch_Indexed` for the json table structure and `TableSearch_Media` for the dynamic table structure. With a set of categories of `first`, `last`, `set1`, and `set2`.

- `first` - given search values to find the first item in the table
- `last` - given search values to find the last item in the table
- `set` - values that will return more than one datarow for a search

And in the name of the benchmark tests the below were used to distinguish what was used in a search.

- `req` - only searches on columns that are required to be in each row
- `op` - only searches on columns that are optional for each row
- `both` - searches on both types of columns
- (`int`, `bool`, `string`) - the types of search values used
- `single` - only one column was searched on. If not included, at least two columns were used.

The boxplots are generated using the included `BuildPlots_alt.R` file.

Box plot for searches getting only the first datarow.
![First datarow boxplot](readme%20files/results/first/ef_json_query_testing.Benchmarks.LessRandomBenchmarks-first-boxplot.png)

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT

```

|                          Method |                  Categories |         Mean |      Error |     StdDev |
|-------------------------------- |---------------------------- |-------------:|-----------:|-----------:|
|     Indexed_first_both_bool_int | json,lessrand,indexed,first |     7.008 ms |  0.1370 ms |  0.3773 ms |
|       Media_first_both_bool_int |  table,lessrand,media,first |   138.727 ms |  2.2613 ms |  1.7655 ms |
|      Indexed_first_req_bool_int | json,lessrand,indexed,first |    27.680 ms |  0.4322 ms |  0.4625 ms |
|        Media_first_req_bool_int |  table,lessrand,media,first |   267.641 ms |  3.9830 ms |  3.3260 ms |
|            Indexed_first_op_int | json,lessrand,indexed,first |     5.210 ms |  0.1038 ms |  0.2097 ms |
|              Media_first_op_int |  table,lessrand,media,first |    90.174 ms |  1.2907 ms |  1.0778 ms |
|        Indexed_first_req_string | json,lessrand,indexed,first | 1,470.281 ms | 22.9791 ms | 21.4946 ms |
|          Media_first_req_string |  table,lessrand,media,first | 3,155.082 ms | 26.4490 ms | 22.0861 ms |
|         Indexed_first_op_string | json,lessrand,indexed,first | 2,498.910 ms | 20.6448 ms | 18.3011 ms |
|           Media_first_op_string |  table,lessrand,media,first |   492.755 ms |  7.3617 ms |  6.8861 ms |
|  Indexed_first_op_string_single | json,lessrand,indexed,first | 2,478.082 ms | 14.1720 ms | 13.2565 ms |
|    Media_first_op_string_single |  table,lessrand,media,first |   402.723 ms |  1.2851 ms |  1.0033 ms |
| Indexed_first_req_string_single | json,lessrand,indexed,first | 1,387.691 ms | 13.4742 ms | 11.9446 ms |
|   Media_first_req_string_single |  table,lessrand,media,first |   824.639 ms |  6.2622 ms |  5.2292 ms |

---

Box plot for searches getting only the last datarow.
![Last datarow boxplot](readme%20files/results/last/ef_json_query_testing.Benchmarks.LessRandomBenchmarks-last-boxplot.png)

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT

```

|                         Method |                 Categories |         Mean |      Error |     StdDev |
|------------------------------- |--------------------------- |-------------:|-----------:|-----------:|
|     Indexed_Last_both_int_bool | json,lessrand,indexed,last |     4.833 ms |  0.0956 ms |  0.1624 ms |
|       Media_last_both_int_bool |  table,lessrand,media,last |   153.960 ms |  1.8422 ms |  1.7232 ms |
|      Indexed_Last_req_int_bool | json,lessrand,indexed,last |     8.191 ms |  0.1634 ms |  0.3622 ms |
|        Media_last_req_int_bool |  table,lessrand,media,last |   174.140 ms |  2.8460 ms |  2.3765 ms |
|        Indexed_Last_req_string | json,lessrand,indexed,last | 1,454.150 ms | 13.6095 ms | 12.7303 ms |
|          Media_last_req_string |  table,lessrand,media,last | 3,151.460 ms | 54.4148 ms | 50.8997 ms |
| Indexed_Last_req_string_single | json,lessrand,indexed,last | 1,365.279 ms | 13.8439 ms | 12.2722 ms |
|   Media_last_req_string_single |  table,lessrand,media,last |   830.242 ms |  6.4290 ms |  5.3685 ms |

---

Box plot for searches get a set of values.
![Set1 boxplot](readme%20files/results/set1/ef_json_query_testing.Benchmarks.LessRandomBenchmarks-set1-boxplot.png)

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT

```

|                         Method |                     Categories |         Mean |      Error |     StdDev |
|------------------------------- |------------------------------- |-------------:|-----------:|-----------:|
|     Indexed_set1_both_int_bool |     json,lessrand,indexed,set1 |    12.407 ms |  0.2388 ms |  0.3348 ms |
|       Media_set1_both_int_bool |      table,lessrand,media,set1 |   137.246 ms |  1.3075 ms |  1.2230 ms |
|      Indexed_set1_req_int_bool |     json,lessrand,indexed,set1 |    17.118 ms |  0.3411 ms |  0.8106 ms |
|        Media_set1_req_int_bool |      table,lessrand,media,set1 |   272.267 ms |  1.5866 ms |  1.4065 ms |
|            Indexed_set1_op_int |     json,lessrand,indexed,set1 |     7.484 ms |  0.1443 ms |  0.1604 ms |
|              Media_set1_op_int |      table,lessrand,media,set1 |    68.615 ms |  1.3577 ms |  2.1924 ms |
|        Indexed_set1_req_string |     json,lessrand,indexed,set1 |   414.619 ms |  2.1831 ms |  1.7044 ms |
|          Media_set1_req_string |      table,lessrand,media,set1 | 1,550.519 ms | 30.6661 ms | 30.1182 ms |
|  Indexed_set1_op_string_single |     json,lessrand,indexed,set1 | 2,527.856 ms | 45.7465 ms | 42.7913 ms |
|    Media_set1_op_string_single | table,lessrand,media,set1,miss |   424.815 ms |  0.9755 ms |  0.7616 ms |
| Indexed_set1_req_string_single |     json,lessrand,indexed,set1 | 1,406.252 ms | 24.1559 ms | 22.5955 ms |
|   Media_set1_req_string_single | table,lessrand,media,set1,miss |   851.747 ms |  7.7749 ms |  6.4924 ms |

---

Box plot for searches get a set of values.
![Set2 boxplot](readme%20files/results/set2/ef_json_query_testing.Benchmarks.LessRandomBenchmarks-set2-boxplot.png)

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT

```

|                         Method |                 Categories |         Mean |      Error |     StdDev |
|------------------------------- |--------------------------- |-------------:|-----------:|-----------:|
|     Indexed_set2_both_int_bool | json,lessrand,indexed,set2 |     7.835 ms |  0.1562 ms |  0.3620 ms |
|       Media_set2_both_int_bool |  table,lessrand,media,set2 |   223.547 ms |  1.5846 ms |  1.5563 ms |
|           Indexed_set2_req_int | json,lessrand,indexed,set2 |     7.865 ms |  0.1430 ms |  0.1117 ms |
|             Media_set2_req_int |  table,lessrand,media,set2 |   174.690 ms |  2.6236 ms |  2.9162 ms |
|        Indexed_set2_req_string | json,lessrand,indexed,set2 |   410.363 ms |  5.4823 ms |  4.5780 ms |
|          Media_set2_req_string |  table,lessrand,media,set2 | 1,550.718 ms | 25.9598 ms | 24.2828 ms |
| Indexed_set2_req_string_single | json,lessrand,indexed,set2 | 1,370.598 ms | 22.5360 ms | 21.0802 ms |
|   Media_set2_req_string_single |  table,lessrand,media,set2 |   831.704 ms | 12.5529 ms | 11.7420 ms |

### other