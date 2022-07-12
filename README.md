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
    - [Categories](#categories)
  - [Results](#results)
    - [No Columns](#no-columns)
    - [Date Field](#date-field)
    - [Misc](#misc)
    - [String](#string)
      - [String Categories](#string-categories)
      - [Normal](#normal)
      - [Build Upon](#build-upon)
      - [Short String & Long String](#short-string--long-string)
      - [Char Count](#char-count)
      - [With Required and Optional Int](#with-required-and-optional-int)
    - [Json Index Benchmarks](#json-index-benchmarks)
      - [Index Benchmarks](#index-benchmarks)
      - [Json Index](#json-index)
      - [Json Index String](#json-index-string)
      - [Misc Test](#misc-test)

## Data Model

I'm using the below structure to mimic what an ad hock query builder could use for testing user created queries.

![Ad hock query builder structure](readme%20files/dataModel/querybuilder.png)

The structure for testing searching where each bit of information is saved as a separate row in a table.

![Dynamic table structure](readme%20files/dataModel/media.png)

The structure for testing searching with the information stored in JSON.

![Json table structure](readme%20files/dataModel/json.png)

Note: The dynamic table and json structures are separated into different models: `Media_Dynamic` and `Media_Json`

Sad Note: At some point `Media_Dynamic` started getting referred to as just media. While `Media_Json` is referred to as json. Tying to get this cleaned up.

## Test Data

I'm using [Bogus](https://github.com/bchavez/Bogus) with a hardcoded seed value to easily create lots of consistent semi-realistic looking data to add into the above data structures. `Media_Dynamic` is created then a selection of `DynamicFields` are used to generate data for the media item into `DynamicMediaInformation`. When all items for `Media_Dynamic` are done, this information is duplicated into `Media_Json` to reduce variables when testing search patterns.

Links to two large bacpac files have been included that were used to benchmark these search patterns: `ef_testing_index_large.bacpac` and `ef_testing_string_large.bacpac` which can be found [here](data%20files/database%20file%20links.txt). The first uses a generated list of 50 different fields including the types: int, bool, date, string. The second is 40 fields of only strings with two additional int fields. Both have 100,000 generated rows of data. A new set can be generated with your own seed and data counts using `CreateBogusData.cs`

### CreateBogusData.cs

The field `FakerSeed` is the seed used for generating the bogus data.

`LoadAllData` Can be called to fill the whole database in one go. `fieldsCount` Will be the list of available dynamic fields each row has available with random data types and sets if the fields are required or optional. `mediaItemsCount` Is the total number of rows to be able to search over which will be created for one table structure and duplicated into the other. `listTypeCount` For generating some dropdown types and the list of options available for each.

`LoadSharedData` Loads the data for the ad hock query builder portion of the database. Filling out the available fields a row can contain. The parameters are the same as above.

`LoadMediaData` Loads the data for the Dynamic and Json tables for running searches against. First it will create data for the dynamic table, then copy that data into the json table.

Some extra private "large" versions of methods are included that I used to generate the massive bacpac files that have been included. These were only temporarily called and are not currently used. (Needed to pause regularly for my laptop to cool down.)

## Search Patterns

Multiple search pattern types were created to see what variants were most efficient. The intent is to see how each handles different search patterns, however all of the below are currently only setup to handle a basic `AND` search rather than the full query builder outlined above. For each pattern, unit tests were added to allow easily checking their validity along with how they each handle bad user input using [NaughtyStrings](https://github.com/SimonCropp/NaughtyStrings). As benchmarking has progressed, more variants have been added and older ones deemed consistently worse than similar counterparts were moved out of the way into `SearchServiceOld.cs`.

### Json Patterns

- `JsonSearch_Indexed_NoColumns`
  - Not a big change from `JsonSearch_Indexed` but a business decision changed the information needed to be brought back from the server.
- `JsonSearch_Indexed_NoColumns_StringAdjustment`
  - An attempt to see if searching on optional string fields could be sped up
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

Single search was mainly used for the original setup of benchmark dotnet and getting a basis started for search patterns. All of these were quickly dropped for multi search versions if possible. Though these aren't used anymore, they are still available.

### Multi search

This section has the hard coded and random sections. Originally random values were used for testing but realized the consistency of choosing what would be returned was also valuable information to these tests. So added the hard coded section of tests. The random tests can be used with any database. The hard coded ones can be used with the provided bacpac file: `ef_testing_index_large.bacpac`. Except for `StringBenchmarks.cs` which needs the other bacpac to work: `ef_testing_string_large.bacpac`.

- Less Random
  - Tests the normal search patterns with specific data to see if the location of the data in the database might have changed search times.
  - Categories: `table`, `json`, `first`, `last`, `set1`, `set2`
- Column Count
  - Tests the `RestrictedColumns` search pattern to see if less data returned would improve dynamic search speed. (less columns actually increased search times)
  - Categories: `table`, `columncount`, `first`, `set1`, `set2`, `count10`, `count25`, `countall`
- Split Query
  - Tests the normal json against the "normal", `SplitQuery`, and `TwoQueries` versions of the dynamic search patterns. (`SplitQuery` was consistently worse than everything, `TwoQueries` was better, but json still out performed)
  - Categories: `table`, `json`, `indexed`, `media`, `media2`, `mediasplit`, `first`, `last`, `set1`, `set2`
- No Columns
  - Tests normal and `NoColumns` versions of the search patterns. (Vast improvement to dynamic search times, json didn't change)
  - Categories: `table`, `json`, `hascolumns`, `nocolumns`, `first`, `last`, `set1`, `set2`
- Date Field
  - Tests the normal and `NoColumns` versions of the search patterns against date fields
  - Categories: `table`, `json`, `hascolumns`, `nocolumns`, `first`, `set1`, `set2`, `set3`
- Misc
  - Tests the normal and `NoColumns` versions of the search patterns against some of the datasets that had larger differences in search times
  - Categories: `indexed`, `media`, `AllColumns`, `NoColumns`, `#fields` (1,2,3,4,5,6,7,9), `both`, `req`, `op`, `date`, `int`, `bool`, `string`
- String
  - Tests only `NoColumn` search patterns against different sets of string search values
  - Categories: `media`, `json`, `req`, `op`, `both`, `one`, `two`, `three`, `four`, `five`, `six`, `seven`, `eight`, `buildupon`, `shortstring`, `longstring`, `charcount`, `ten`, `twelve`, `fourteen`, `sixteen`, `withint`
  - Uses `ef_testing_string_large.bacpac`
- Json Index
  - These tests require database changes between runs for testing how indexing effects the search speed of different types of searches.
  - `JsonIndexBenchmarks` uses `ef_testing_index_large.bacpac` with the required changes per run listed in the class
  - `JsonIndexStringBenchmarks` uses `ef_testing_string_large.bacpac` with the required changes per run listed in the class
  - A set of tests only using the json `NoColumn` search pattern

### Categories

- `first` - given search values to find the first item in the table
- `last` - given search values to find the last item in the table
- `set#` - values that will return more than one row for a search
- `req` - only searches on columns that are required to be in each row
- `op` - only searches on columns that are optional for each row
- `both` - search includes optional and required fields
- (`int`, `bool`, `string`, `date`) - the types of search values used
- `#fields` (1,2,3,4,5,6,7,9) or `number` spelled out - the number of fields searched on
- `table` or `media` for tests using the dynamic search patterns
- `json` for tests using the json search patterns
- Additional benchmark specific categories listed in their respective sections below

## Results

A lot of the benchmarks included in this project were done before the business decision of not returning the media information. Which vastly improved the speed of the dynamic table search patterns. The test results of these have still been included but will not be reviewed here. These sections include: `Column Count`, `Less Random`, and `Split Query`. While the dynamic search patterns improved with the removal of the column data, the json patterns didn't see much difference, but for the sake of consistency I will focus on the `No Column` version of the json search patterns. However a lot of the test results still include the original version of json and dynamic search so they can be easily compared with the `No Column` versions.

The plots are generated using the included `BuildPlots_alt.R` file found [here](data%20files/BuildPlots_alt.R).

---

### No Columns

The information in `Tbl 1` shows how the dynamic search pattern improved when columns were not required to be returned. While the benchmarks on the data types for int and bool show small improvements in speed, ones that include strings show a vast improvement based on how many rows were being requested. `set1` showing a drastic improvement from 30 seconds down to 1 second. `first` showing 3 seconds down to .5 seconds.

While `Tbl 2` for json shows removing column information has a slight improvement but most of it can be accounted for with the error and standard deviation.

``` ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
```

<details>
  <summary>Tbl 1: No Columns Benchmarks - dynamic</summary>

|                                    Method |          Mean |         Error |        StdDev |
|------------------------------------------ |--------------:|--------------:|--------------:|
|                  Media_set1_both_int_bool |    145.070 ms |     2.5972 ms |     3.0917 ms |
|        Media_noColumns_set1_both_int_bool |    135.077 ms |     1.3963 ms |     1.2378 ms |
|                   Media_set1_req_int_bool |    271.996 ms |     4.8273 ms |     4.2793 ms |
|         Media_noColumns_set1_req_int_bool |    269.232 ms |     1.9638 ms |     1.5332 ms |
|                         Media_set1_op_int |     72.571 ms |     1.0938 ms |     0.9696 ms |
|               Media_noColumns_set1_op_int |     67.871 ms |     0.9793 ms |     0.9160 ms |
|                     Media_set1_req_string |    169.146 ms |     3.3757 ms |     7.1939 ms |
|           Media_noColumns_set1_req_string |  1,551.383 ms |    25.1084 ms |    23.4864 ms |
|               Media_set1_op_string_single | 22,116.768 ms | 1,084.1167 ms | 3,145.2191 ms |
|     Media_noColumns_set1_op_string_single |    427.422 ms |     3.4945 ms |     2.9181 ms |
|              Media_set1_req_string_single | 29,306.243 ms |   579.0830 ms |   983.3268 ms |
|    Media_noColumns_set1_req_string_single |    853.966 ms |    13.1366 ms |    10.9696 ms |
|                 Media_first_both_bool_int |    134.972 ms |     1.4135 ms |     1.2530 ms |
|       Media_noColumns_first_both_bool_int |    134.785 ms |     1.9739 ms |     1.8464 ms |
|                  Media_first_req_bool_int |    249.123 ms |     3.3765 ms |     2.8195 ms |
|        Media_noColumns_first_req_bool_int |    265.708 ms |     5.0133 ms |     4.4442 ms |
|                        Media_first_op_int |     89.694 ms |     1.7909 ms |     2.3287 ms |
|              Media_noColumns_first_op_int |     90.168 ms |     1.6429 ms |     1.3719 ms |
|                    Media_first_req_string |  3,132.863 ms |    28.2227 ms |    26.3995 ms |
|          Media_noColumns_first_req_string |  3,125.529 ms |    28.1682 ms |    26.3485 ms |
|                     Media_first_op_string |    492.253 ms |     6.4743 ms |     5.0547 ms |
|           Media_noColumns_first_op_string |    494.283 ms |     8.9849 ms |     9.9867 ms |
|              Media_first_op_string_single |     76.057 ms |     2.1989 ms |     6.4490 ms |
|    Media_noColumns_first_op_string_single |    406.639 ms |     5.1703 ms |     4.3175 ms |
|             Media_first_req_string_single |    139.974 ms |     2.7730 ms |     6.8541 ms |
|   Media_noColumns_first_req_string_single |    827.508 ms |     4.6228 ms |     3.8603 ms |

</details>

<details>
  <summary>Tbl 2: No Columns Benchmarks - json</summary>

|                                    Method |          Mean |         Error |        StdDev |
|------------------------------------------ |--------------:|--------------:|--------------:|
|               Indexed_first_both_bool_int |      6.642 ms |     0.1323 ms |     0.3531 ms |
|     Indexed_noColumns_first_both_bool_int |      6.440 ms |     0.1281 ms |     0.3094 ms |
|                Indexed_first_req_bool_int |     28.642 ms |     0.5380 ms |     0.4492 ms |
|      Indexed_noColumns_first_req_bool_int |     27.370 ms |     0.3812 ms |     0.3184 ms |
|                      Indexed_first_op_int |      4.765 ms |     0.0953 ms |     0.2494 ms |
|            Indexed_noColumns_first_op_int |      4.515 ms |     0.0884 ms |     0.1452 ms |
|                  Indexed_first_req_string |  1,466.409 ms |    28.4672 ms |    26.6282 ms |
|        Indexed_noColumns_first_req_string |  1,463.739 ms |    19.8935 ms |    18.6084 ms |
|                   Indexed_first_op_string |  2,511.278 ms |    15.3365 ms |    14.3458 ms |
|         Indexed_noColumns_first_op_string |  2,517.308 ms |    24.1128 ms |    21.3753 ms |
|            Indexed_first_op_string_single |  2,501.888 ms |     6.5184 ms |     5.0891 ms |
|  Indexed_noColumns_first_op_string_single |  2,513.694 ms |    19.7399 ms |    17.4989 ms |
|           Indexed_first_req_string_single |  1,410.806 ms |    22.5999 ms |    21.1400 ms |
| Indexed_noColumns_first_req_string_single |  1,409.895 ms |    26.6260 ms |    24.9060 ms |
|                Indexed_set1_both_int_bool |     12.186 ms |     0.2398 ms |     0.2665 ms |
|      Indexed_noColumns_set1_both_int_bool |      6.042 ms |     0.1145 ms |     0.2655 ms |
|                 Indexed_set1_req_int_bool |     17.135 ms |     0.3383 ms |     0.5064 ms |
|       Indexed_noColumns_set1_req_int_bool |     13.913 ms |     0.2726 ms |     0.4163 ms |
|                       Indexed_set1_op_int |      7.768 ms |     0.1404 ms |     0.1313 ms |
|             Indexed_noColumns_set1_op_int |      3.700 ms |     0.0735 ms |     0.1910 ms |
|                   Indexed_set1_req_string |    420.444 ms |     8.3722 ms |     7.8313 ms |
|         Indexed_noColumns_set1_req_string |    418.181 ms |     8.0565 ms |     6.7275 ms |
|             Indexed_set1_op_string_single |  2,514.774 ms |    47.6085 ms |    44.5330 ms |
|   Indexed_noColumns_set1_op_string_single |  2,503.007 ms |    44.4445 ms |    41.5734 ms |
|            Indexed_set1_req_string_single |  1,404.229 ms |    23.8953 ms |    22.3517 ms |
|  Indexed_noColumns_set1_req_string_single |  1,403.096 ms |    19.6017 ms |    18.3354 ms |

</details>

<details>
  <summary>Fig 1: No Columns Benchmarks - first</summary>

![Fig 1: No Columns Benchmarks - first](readme%20files/results/No%20Columns/no%20columns%20-%20all/first/ef_json_query_testing.Benchmarks.NoColumnsBenchmarks-boxplot-line.png)

</details>

<details>
  <summary>Fig 2: No Columns Benchmarks - set1</summary>

![Fig 2: No Columns Benchmarks - set1](readme%20files/results/No%20Columns/no%20columns%20-%20all/set1/ef_json_query_testing.Benchmarks.NoColumnsBenchmarks-boxplot-line.png)

</details>

<details>
  <summary>Fig 3: No Columns Benchmarks - strings only</summary>

![Fig 3: No Columns Benchmarks - strings only](readme%20files/results/No%20Columns/no%20columns%20-%20string%20only/ef_json_query_testing.Benchmarks.NoColumnsBenchmarks-boxplot-line.png)

</details>

---

### Date Field

Date fields were not originally included in the benchmarks because additional work needed to be done to have them work properly. The dynamic search pattern needed a custom EF function added to allow for date conversions on the sql side. While json needed dates converted into a deterministic style to allow for indexing to be added. While the search for int and bool are exact matches, date search was setup to look for values with equal or greater dates than the one provided.

`Tbl 3` is a collection of data taken from the previous tables and the benchmark runs for Date fields to compare the search times for dates against those without. Dates can be seen to slightly increase search time for both json and dynamic search styles. Most drastically for dynamic when searching over both required and optional fields with a difference of 322ms. Json is seen to consistently run faster than the dynamic search.

<details>
  <summary>Tbl 3:  Date Field Benchmarks</summary>

|                                     Method |       Mean |     Error |    StdDev |
|------------------------------------------- |-----------:|----------:|----------:|
|            Indexed_noColumns_set1_req_date |   13.08 ms |  0.259 ms |  0.467 ms |
|        Indexed_noColumns_set1_req_int_bool |  13.913 ms | 0.2726 ms | 0.4163 ms |
|              Media_noColumns_set1_req_date |  352.69 ms |  6.394 ms |  5.339 ms |
|          Media_noColumns_set1_req_int_bool | 269.232 ms | 1.9638 ms | 1.5332 ms |
|             Indexed_noColumns_set1_op_date |   37.43 ms |  0.253 ms |  0.211 ms |
|              Indexed_noColumns_set1_op_int |   3.700 ms | 0.0735 ms | 0.1910 ms |
|               Media_noColumns_set1_op_date |  113.82 ms |  1.351 ms |  1.264 ms |
|                Media_noColumns_set1_op_int |  67.871 ms | 0.9793 ms | 0.9160 ms |
|           Indexed_noColumns_set1_both_date |   158.5 ms |   3.12 ms |   2.61 ms |
|       Indexed_noColumns_set1_both_int_bool |   6.042 ms | 0.1145 ms | 0.2655 ms |
|             Media_noColumns_set1_both_date |   456.7 ms |   2.62 ms |   2.19 ms |
|         Media_noColumns_set1_both_int_bool | 135.077 ms | 1.3963 ms | 1.2378 ms |
| Indexed_noColumns_first_both_date_int_bool |   15.07 ms |  0.298 ms |  0.446 ms |
|      Indexed_noColumns_first_both_bool_int |   6.440 ms | 0.1281 ms | 0.3094 ms |
|   Media_noColumns_first_both_date_int_bool |  398.38 ms |  5.232 ms |  4.638 ms |
|        Media_noColumns_first_both_bool_int | 134.785 ms | 1.9739 ms | 1.8464 ms |

</details>

---

### Misc

The misc benchmarks are a collection of benchmarks I pulled from other places when I wanted to further dig into what was causing the odd search times in certain scenarios. It also includes extra benchmarks to compare to the oddities.

`Tbl 4` shows a collection of different benchmarks comparing json and dynamics no columns search patterns. For the data types of int, bool, and date, json is consistently faster than the dynamic search. `Tbl 5` is string only searches and is where the data gets strange. In most test cases where all fields searched are required, json runs faster. However, there seems to be a correlation between the field count and when the dynamic pattern would run faster. Fo the optional field searches, json was consistently worse than the dynamic search. Which leads into the next set of benchmarks focused on strings that go into more detail on these oddities.

<details>
  <summary>Tbl 4:  Misc Benchmarks - int, bool, and dates</summary>
  
|                                      Method |          Mean |       Error |        StdDev | Field Count |
|-------------------------------------------- |--------------:|------------:|--------------:|------------:|
|         Media_NoColumns_first_both_bool_int |    137.736 ms |   1.7443 ms |     1.5463 ms |           6 |
|       Indexed_NoColumns_first_both_bool_int |      4.225 ms |   0.0903 ms |     0.2621 ms |           6 |
|          Media_NoColumns_first_req_bool_int |    226.766 ms |   2.4157 ms |     2.1415 ms |           7 |
|        Indexed_NoColumns_first_req_bool_int |      7.471 ms |   0.1444 ms |     0.2333 ms |           7 |
|                Media_NoColumns_first_op_int |     90.938 ms |   1.4189 ms |     1.2578 ms |           4 |
|              Indexed_NoColumns_first_op_int |      3.967 ms |   0.0771 ms |     0.2174 ms |           4 |
|    Media_NoColumns_first_both_date_int_bool |    404.453 ms |   4.1403 ms |     3.4573 ms |           9 |
|  Indexed_NoColumns_first_both_date_int_bool |     14.679 ms |   0.2885 ms |     0.4491 ms |           9 |
|               Media_NoColumns_set1_req_date |    352.554 ms |   6.6846 ms |     5.9258 ms |           3 |
|             Indexed_NoColumns_set1_req_date |     13.153 ms |   0.2595 ms |     0.4264 ms |           3 |
|                Media_NoColumns_set1_op_date |    118.228 ms |   2.2492 ms |     2.3097 ms |           2 |
|              Indexed_NoColumns_set1_op_date |     37.716 ms |   0.7233 ms |     0.9147 ms |           2 |
|              Media_NoColumns_set1_both_date |    464.646 ms |   5.6165 ms |     4.6900 ms |           5 |
|            Indexed_NoColumns_set1_both_date |    157.691 ms |   2.4201 ms |     2.5894 ms |           5 |

</details>

<details>
  <summary>Tbl 5:  Misc Benchmarks - strings</summary>

|                                      Method |          Mean |       Error |        StdDev | Field Count |
|-------------------------------------------- |--------------:|------------:|--------------:|------------:|
|            Media_NoColumns_first_req_string |  3,184.654 ms |  60.3905 ms |    56.4893 ms |           4 |
|          Indexed_NoColumns_first_req_string |  1,502.366 ms |  19.4950 ms |    18.2357 ms |           4 |
|     Media_NoColumns_first_req_string_single |    851.483 ms |  14.8172 ms |    13.8600 ms |           1 |
|   Indexed_NoColumns_first_req_string_single |  1,430.889 ms |  22.8104 ms |    21.3369 ms |           1 |
|             Media_NoColumns_set1_req_string |  1,569.290 ms |  25.3611 ms |    23.7227 ms |           2 |
|           Indexed_NoColumns_set1_req_string |    426.467 ms |   5.0285 ms |     4.4576 ms |           2 |
|      Media_NoColumns_set1_req_string_single |    865.013 ms |   9.8744 ms |     8.7534 ms |           1 |
|    Indexed_NoColumns_set1_req_string_single |  1,429.871 ms |  27.8590 ms |    27.3612 ms |           1 |
|             Media_NoColumns_set2_req_string |  1,582.771 ms |  29.5328 ms |    27.6250 ms |           2 |
|           Indexed_NoColumns_set2_req_string |    415.466 ms |   3.1280 ms |     2.4421 ms |           2 |
|      Media_NoColumns_set2_req_string_single |    839.025 ms |   3.2153 ms |     2.5103 ms |           1 |
|    Indexed_NoColumns_set2_req_string_single |  1,437.138 ms |  28.1644 ms |    35.6189 ms |           1 |
|             Media_NoColumns_first_op_string |    494.814 ms |   9.5839 ms |     9.8420 ms |           3 |
|           Indexed_NoColumns_first_op_string |  2,589.288 ms |  36.7829 ms |    32.6071 ms |           3 |
|      Media_NoColumns_first_op_string_single |    415.320 ms |   6.4889 ms |     5.7522 ms |           1 |
|    Indexed_NoColumns_first_op_string_single |  2,576.569 ms |  30.3320 ms |    28.3726 ms |           1 |
|       Media_NoColumns_set1_op_string_single |    437.780 ms |   8.5108 ms |     7.1069 ms |           1 |
|     Indexed_NoColumns_set1_op_string_single |  2,577.872 ms |  41.3992 ms |    38.7249 ms |           1 |

</details>

<details>
  <summary>Fig 4:  Misc Benchmarks</summary>

![Fig 4:  Misc Benchmarks](readme%20files/results/Misc/misc%20run%20reduced%20data/miscTests-media-allcolumns-index-allcolumns-removed-boxplot-line.png)

</details>

---

### String

These benchmarks use a different database than those above. The file for it has been included: `ef_testing_string_large.bacpac`. This database was setup specifically to test different scenarios for string searches. It is setup with 41 fields. 20 string columns that are required, 20 that are optional, and one additional column for an int.

#### String Categories

- `normal` - Each search has a random selection of values with an increasing amount of fields searched on
- `buildupon` - Each search has the same search terms as the previous plus one new one
- `shortstring` - Same as `buildupon` but each search field uses only 5 character long strings
- `longstring` - Same as `buildupon` but each search field uses strings of length 10
- `charcount` - Each search is over 4 fields with the lengths of the strings increasing in each search
- `withint` - A copy of `buildupon` with a required int field added onto each search
- `optionalint` - Similar to `buildupon` with an optional int field added onto each search

---

#### Normal

This first run was somewhat informative. It showed a basic pattern that the dynamic search over strings takes longer based on how many fields are searched over. While the json search changes based on the types of fields searched. With optional fields taking longer than dynamic and required only fields being much faster than the dynamic version. However this data seemed inconsistent because json had some random spikes in its search times.

`Tbl 6` shows the raw data and Fig 5 the basic plot for this. This format wasn't very informative so I added additional plots (`Fig 6`, `Fig 7`, `Fig 8`) for better comparing of these search patterns.

<details>
  <summary>Tbl 6: String Benchmarks - Normal</summary>

|           Method |        Mean |     Error |    StdDev |
|----------------- | -----------:|----------:|----------:|
|    Media_Req_One |   153.63 ms |  3.046 ms |  4.368 ms |
|     Json_Req_One |    26.43 ms |  0.521 ms |  0.714 ms |
|    Media_Req_Two | 1,721.58 ms | 11.659 ms | 10.336 ms |
|     Json_Req_Two |   493.26 ms |  6.767 ms |  6.330 ms |
|  Media_Req_Three | 2,572.17 ms | 19.979 ms | 17.711 ms |
|   Json_Req_Three | 1,966.27 ms | 11.146 ms |  9.880 ms |
|   Media_Req_Four | 3,409.05 ms | 26.122 ms | 24.435 ms |
|    Json_Req_Four | 2,383.64 ms |  9.347 ms |  8.743 ms |
|   Media_Req_Five | 4,234.82 ms | 10.756 ms |  8.982 ms |
|    Json_Req_Five | 1,402.98 ms |  7.307 ms |  5.705 ms |
|    Media_Req_Six | 5,221.28 ms | 95.834 ms | 89.643 ms |
|     Json_Req_Six | 2,594.07 ms | 14.244 ms | 13.324 ms |
|  Media_Req_Seven | 6,009.03 ms | 16.013 ms | 14.979 ms |
|   Json_Req_Seven | 2,609.36 ms |  9.405 ms |  8.797 ms |
|  Media_Req_Eight | 6,827.40 ms | 19.107 ms | 17.872 ms |
|   Json_Req_Eight | 4,680.04 ms | 10.539 ms |  9.342 ms |
|     Media_Op_One |    62.31 ms |  1.176 ms |  1.307 ms |
|      Json_Op_One |    28.05 ms |  0.264 ms |  0.234 ms |
|     Media_Op_Two |   863.29 ms |  1.770 ms |  1.569 ms |
|      Json_Op_Two | 2,206.16 ms | 15.537 ms | 12.974 ms |
|   Media_Op_Three | 1,362.10 ms |  9.611 ms |  8.520 ms |
|    Json_Op_Three | 5,340.91 ms | 19.233 ms | 17.050 ms |
|    Media_Op_Four | 1,798.65 ms |  3.925 ms |  3.671 ms |
|     Json_Op_Four | 5,403.10 ms | 33.622 ms | 31.450 ms |
|    Media_Op_Five | 2,185.05 ms |  4.914 ms |  4.597 ms |
|     Json_Op_Five | 5,371.52 ms | 21.022 ms | 18.635 ms |
|     Media_Op_Six | 2,669.32 ms | 18.444 ms | 17.253 ms |
|      Json_Op_Six | 5,461.66 ms | 10.487 ms |  9.810 ms |
|   Media_Op_Seven | 2,793.89 ms |  5.922 ms |  4.624 ms |
|    Json_Op_Seven | 6,735.02 ms | 16.532 ms | 15.464 ms |
|   Media_Op_Eight | 3,486.25 ms | 13.419 ms | 11.896 ms |
|    Json_Op_Eight | 5,306.52 ms | 18.558 ms | 17.359 ms |
|   Media_Both_Two | 1,338.78 ms |  9.500 ms |  8.887 ms |
|    Json_Both_Two | 2,536.93 ms | 10.512 ms |  9.833 ms |
|  Media_Both_Four | 2,693.03 ms | 10.054 ms |  9.404 ms |
|   Json_Both_Four | 5,431.76 ms | 14.023 ms | 13.117 ms |
|   Media_Both_Six | 3,682.96 ms | 12.264 ms | 11.471 ms |
|    Json_Both_Six | 3,665.26 ms |  8.397 ms |  7.444 ms |
| Media_Both_Eight | 5,169.48 ms | 21.261 ms | 18.848 ms |
|  Json_Both_Eight | 5,442.79 ms | 13.986 ms | 13.083 ms |

</details>

<details>
  <summary>Fig 5: String Benchmarks - Normal - Box Plot</summary>

![Fig 5: String Benchmarks - Normal - Box Plot](readme%20files/results/String/string%20fields%20-%20normal/ef_json_query_testing.Benchmarks.MultiSearch.HardCodedValueTests.StringBenchmarks-boxplot-line.png)

</details>

<details>
  <summary>Fig 6: String Benchmarks - Normal - Line Plot - Required Only</summary>

![Fig 6: String Benchmarks - Normal - Line Plot - Required Only](readme%20files/results/String/string%20fields%20-%20normal/String%20Search%20Query%20-%20json%20vs%20media%20with%20required%20fields.png)

</details>

<details>
  <summary>Fig 7: String Benchmarks - Normal - Line Plot - Optional Only</summary>

![Fig 7: String Benchmarks - Normal - Line Plot - Optional Only](readme%20files/results/String/string%20fields%20-%20normal/String%20Search%20Query%20-%20json%20vs%20media%20with%20optional%20fields.png)

</details>

<details>
  <summary>Fig 8: String Benchmarks - Normal - Line Plot - Both</summary>

![Fig 8: String Benchmarks - Normal - Line Plot - Both](readme%20files/results/String/string%20fields%20-%20normal/String%20Search%20Query%20-%20json%20vs%20media%20with%20combined%20optional%20and%20required%20fields.png)

</details>

---

#### Build Upon

Similar to the last benchmark, this one was made to get more consistent data. Each test builds on the previous set of fields so that all of the search fields are the same except for the newest one added. Example:

```C#

{ 1 , "possimus" }

{ 1 , "possimus" },
{ 2 , "tempore" }

{ 1 , "possimus" },
{ 2 , "tempore" },
{ 3 , "numquam" }

```

This style looks to have worked. As there is no longer any unexpected changes in the data. The plots `Fig 10`, `Fig 11`, and `Fig 12` show the new and previous tests for comparison. While the dynamic(media) search shows a consistent increase for every field added, json displays a consistent speed for any fields added after the third, seen in `Fig 10`. Which vastly increases how fast it does a search compared to dynamic when all fields are required. However, while json is still very consistent for optional fields, media is faster though the difference decreases the more fields that are added, as seen in `Fig 11` and `Fig 12`.

<details>
  <summary>Tbl 7: String Benchmarks - Build Upon</summary>

|                     Method |        Mean |     Error |    StdDev |
|--------------------------- |------------:|----------:|----------:|
|    Media_Req_One_BuildUpon |   146.83 ms |  2.882 ms |  4.735 ms |
|     Json_Req_One_BuildUpon |    26.24 ms |  0.439 ms |  0.343 ms |
|    Media_Req_Two_BuildUpon | 1,598.75 ms | 25.381 ms | 22.500 ms |
|     Json_Req_Two_BuildUpon |   326.68 ms |  3.764 ms |  3.336 ms |
|  Media_Req_Three_BuildUpon | 2,412.93 ms | 33.383 ms | 31.226 ms |
|   Json_Req_Three_BuildUpon | 1,276.54 ms | 16.827 ms | 14.917 ms |
|   Media_Req_Four_BuildUpon | 3,181.99 ms | 23.472 ms | 21.955 ms |
|    Json_Req_Four_BuildUpon | 1,270.15 ms | 15.886 ms | 14.860 ms |
|   Media_Req_Five_BuildUpon | 3,987.76 ms | 13.665 ms | 12.114 ms |
|    Json_Req_Five_BuildUpon | 1,269.49 ms | 14.888 ms | 13.926 ms |
|    Media_Req_Six_BuildUpon | 4,768.32 ms | 28.002 ms | 31.124 ms |
|     Json_Req_Six_BuildUpon | 1,270.05 ms | 11.058 ms | 10.344 ms |
|  Media_Req_Seven_BuildUpon | 5,562.17 ms | 23.576 ms | 22.053 ms |
|   Json_Req_Seven_BuildUpon | 1,264.94 ms |  9.581 ms |  8.000 ms |
|  Media_Req_Eight_BuildUpon | 6,349.26 ms | 38.729 ms | 34.332 ms |
|   Json_Req_Eight_BuildUpon | 1,268.51 ms | 16.261 ms | 15.211 ms |
|     Media_Op_One_BuildUpon |   100.09 ms |  1.952 ms |  2.922 ms |
|      Json_Op_One_BuildUpon |   165.85 ms |  3.302 ms |  3.391 ms |
|     Media_Op_Two_BuildUpon |   801.75 ms |  5.369 ms |  4.484 ms |
|      Json_Op_Two_BuildUpon | 3,619.08 ms | 43.439 ms | 40.633 ms |
|   Media_Op_Three_BuildUpon | 1,205.82 ms | 15.057 ms | 14.084 ms |
|    Json_Op_Three_BuildUpon | 4,761.12 ms | 12.263 ms | 10.871 ms |
|    Media_Op_Four_BuildUpon | 1,616.83 ms | 14.126 ms | 13.214 ms |
|     Json_Op_Four_BuildUpon | 4,760.38 ms | 43.668 ms | 34.093 ms |
|    Media_Op_Five_BuildUpon | 2,013.39 ms | 23.448 ms | 21.933 ms |
|     Json_Op_Five_BuildUpon | 4,751.75 ms | 10.917 ms |  9.116 ms |
|     Media_Op_Six_BuildUpon | 2,402.93 ms | 15.626 ms | 13.852 ms |
|      Json_Op_Six_BuildUpon | 4,764.77 ms | 36.133 ms | 30.172 ms |
|   Media_Op_Seven_BuildUpon | 2,818.16 ms | 34.750 ms | 32.505 ms |
|    Json_Op_Seven_BuildUpon | 4,757.01 ms |  9.972 ms |  8.840 ms |
|   Media_Op_Eight_BuildUpon | 3,208.73 ms | 32.084 ms | 30.012 ms |
|    Json_Op_Eight_BuildUpon | 4,755.69 ms | 17.241 ms | 14.397 ms |
|   Media_Both_Two_BuildUpon | 1,191.22 ms | 22.021 ms | 20.598 ms |
|    Json_Both_Two_BuildUpon | 2,667.68 ms | 27.364 ms | 24.257 ms |
|  Media_Both_Four_BuildUpon | 2,390.84 ms | 35.557 ms | 33.260 ms |
|   Json_Both_Four_BuildUpon | 4,758.69 ms |  4.975 ms |  3.884 ms |
|   Media_Both_Six_BuildUpon | 3,404.36 ms | 31.111 ms | 29.101 ms |
|    Json_Both_Six_BuildUpon | 4,762.67 ms | 15.341 ms | 13.600 ms |
| Media_Both_Eight_BuildUpon | 4,593.04 ms |  7.522 ms |  6.668 ms |
|  Json_Both_Eight_BuildUpon | 4,756.97 ms |  8.630 ms |  7.651 ms |

</details>

<details>
  <summary>Fig 9: String Benchmarks - Build Upon - Box Plot</summary>

![Fig 9: String Benchmarks - Build Upon - Box Plot](readme%20files/results/String/string%20fields%20-%20buildupon/ef_json_query_testing.Benchmarks.MultiSearch.HardCodedValueTests.StringBenchmarks-boxplot-line.png)

</details>

<details>
  <summary>Fig 10: String Benchmarks - Build Upon - Line Plot - Required Only</summary>

![Fig 10: String Benchmarks - Build Upon - Line Plot - Required Only](readme%20files/results/String/string%20fields%20-%20buildupon/String%20Search%20Query%20-%20json%20vs%20media%20with%20required%20fields.png)

</details>

<details>
  <summary>Fig 11: String Benchmarks - Build Upon - Line Plot - Optional Only</summary>

![Fig 11: String Benchmarks - Build Upon - Line Plot - Optional Only](readme%20files/results/String/string%20fields%20-%20buildupon/String%20Search%20Query%20-%20json%20vs%20media%20with%20optional%20fields.png)

</details>

<details>
  <summary>Fig 12: String Benchmarks - Build Upon - Line Plot - Both</summary>

![Fig 12: String Benchmarks - Build Upon - Line Plot - Both](readme%20files/results/String/string%20fields%20-%20buildupon/String%20Search%20Query%20-%20json%20vs%20media%20with%20combined%20optional%20and%20required%20fields.png)

</details>

---

#### Short String & Long String

These two benchmarks turned out very similar in speeds. With any difference being quite negligible. The most interesting part of this benchmark is that the `both` tests for the json search pattern actually run faster than the dynamic search patterns. As with previous tests json usually takes longer than the dynamic search. However, I'm unable to explain why this test ended up so different compared to previous runs.

<details>
  <summary>Fig 13: String Benchmarks - Short String - Line Plot - Both</summary>

![Fig 13: String Benchmarks - Short String - Line Plot - Both](readme%20files/results/String/string%20fields%20-%20shortstring/String%20Search%20Query%20-%20json%20vs%20media%20with%20combined%20optional%20and%20required%20fields.png)

</details>

<details>
  <summary>Fig 14: String Benchmarks - Long String - Line Plot - Both</summary>

  ![Fig 14: String Benchmarks - Long String - Line Plot - Both](readme%20files/results/String/string%20fields%20-%20longstring/String%20Search%20Query%20-%20json%20vs%20media%20with%20combined%20optional%20and%20required%20fields.png)

</details>

---

#### Char Count

This test was over four fields for each test but with the character count for each search changing. This data is displayed in `Fig 15` and shows that each search is very consistent. With the json patterns slightly decreasing with longer strings and dynamic patterns slightly increasing. However these changes can be explained by the error and standard deviation.

<details>
  <summary>Fig 15: String Benchmarks - Char Count - Line Plot</summary>

![Fig 15: String Benchmarks - Char Count - Line Plot](readme%20files/results/String/string%20fields%20-%20charcount/String%20Search%20Query%20-%20json%20vs%20media.png)

</details>

---

#### With Required and Optional Int

The tests `withint` and `optionalint` are similar to the `buildupon` tests but with an int field added onto each search (not included in field counts). This benchmark shows how drastically the search time reduces by having a single non-string field included in the search terms. The full comparison can be seen in `Fig 16`.

However, the times between json and dynamic search patterns are not so different, though json is consistently the faster of the two. This can be seen with `Fig 17` and `Fig 18`.

<details>
  <summary>Fig 16: String Benchmarks - With int Compared to Build Upon - Line Plot - Optional</summary>

![Fig 16: String Benchmarks - With int Compared to Build Upon - Line Plot - Optional](readme%20files/results/String/string%20fields%20-%20withint/String%20Search%20Query%20-%20json%20vs%20media%20with%20optional%20fields%20-%20comparison.png)

</details>

<details>
  <summary>Fig 17: String Benchmarks - With int - Line Plot - Optional</summary>

![Fig 17: String Benchmarks - With int - Line Plot - Optional](readme%20files/results/String/string%20fields%20-%20withint/String%20Search%20Query%20-%20json%20vs%20media%20with%20Required%20fields.png)

</details>

<details>
  <summary>Fig 18: String Benchmarks - With int - Line Plot - Required</summary>

![Fig 18: String Benchmarks - With int - Line Plot - Required](readme%20files/results/String/string%20fields%20-%20withint/String%20Search%20Query%20-%20json%20vs%20media%20with%20optional%20fields.png)

</details>

---

### Json Index Benchmarks

This ended up being a combination of a few different benchmarks and tests on the two provided databases. Rather than making multiple copies of the tables for the different combination of tests with and without indexing, I simply added and removed the needed indexes between each run of the tests.

#### Index Benchmarks

- `JsonIndexBenchmarks` uses `ef_testing_index_large.bacpac`
  - With indexes - This was used as a baseline run for comparing with removed indexes
  - Without searched indexes - Removed indexes on columns 1 and 2 that were used in the searches
  - Without unsearched indexes - Added the removed indexes back and then removed indexes for columns 12, 31, 32, and 47, to cover a combination of required and optional fields.
- `JsonIndexStringBenchmarks` uses `ef_testing_string_large.bacpac`
  - With indexes - This was used as a baseline run for comparing with removed indexes
  - Without searched indexes - Removed indexes on columns 1 and 48 that were used in the searches
  - Without unsearched indexes - Added the removed indexes back and then removed indexes for columns 4, 6, 37, and 39, to cover a combination of required and optional fields.
- Misc Test - Uses the Misc Benchmarks file
  - Baseline - A normal run of the Misc benchmarks to use as comparison
  - No indexing - A run of the Misc Benchmarks after all indexes on the database have been removed

---

#### Json Index

This benchmark uses `ef_testing_index_large.bacpac`. And was ran three times: All columns indexed, some searched fields with indexes removed, and once with all search fields having indexes and some that were not searched having indexes removed.

In this test I focused on basic data types, Int and Bool. `Fig 19` shows how including indexes on these columns types is negligible for required and optional fields.

<details>
  <summary>Fig 19: Json Index Benchmarks - Box Plot</summary>

![Fig 19: Json Index Benchmarks - Box Plot](readme%20files/results/Index%20Testing/json%20index/JsonIndexBenchmarks-All-boxplot.png)

</details>

---

#### Json Index String

This benchmark uses `ef_testing_string_large.bacpac`. And was ran three times: All columns indexed, some searched fields with indexes removed, and once with all search fields having indexes and some that were not searched having indexes removed. `Fig 20` shows how including indexes on these searches was negligible for required and optional fields.

<details>
  <summary>Fig 20: Json Index String Benchmarks - Box Plot</summary>

![Fig 20: Json Index String Benchmarks - Box Plot](readme%20files/results/Index%20Testing/json%20index%20string/JsonIndexStringBenchmarks-All-boxplot.png)

</details>

---

#### Misc Test

After the previous two benchmarks seemed to display that indexing was not necessary, I decided to run a more thorough test using the Misc benchmarks. Once with all indexes included to be the baseline for comparison, and once with all indexes removed to see if there were specific cases where indexing improved performance.

`Tbl 8` shows the results of both runs, `Baseline` and `NotIndexed`. With most comparisons showing not enough change to make a difference. It looks like the only columns that see any improvement in search time with an index are optional primitive fields.

<details>
  <summary>Tbl 8: Json Index Misc Benchmarks</summary>

|                               Method |                  Categories |        Mean |     Error |    StdDev |
|------------------------------------- |---------------------------- |------------:|----------:|----------:|
|          BaseLine_first_req_bool_int |        7fields,req,bool,int |     7.46 ms |  0.148 ms |  0.363 ms |
|        NotIndexed_first_req_bool_int |        7fields,req,bool,int |    43.92 ms |  0.875 ms |  1.644 ms |
|                BaseLine_first_op_int |              4fields,op,int |     3.89 ms |  0.078 ms |  0.180 ms |
|              NotIndexed_first_op_int |              4fields,op,int |   332.40 ms |  6.556 ms |  5.811 ms |
|         BaseLine_first_both_bool_int |       6fields,both,bool,int |     4.53 ms |  0.089 ms |  0.122 ms |
|       NotIndexed_first_both_bool_int |       6fields,both,bool,int |   337.93 ms |  6.630 ms |  9.076 ms |
|               BaseLine_set1_req_date |            3fields,req,date |    13.23 ms |  0.262 ms |  0.269 ms |
|             NotIndexed_set1_req_date |            3fields,req,date |    13.81 ms |  0.166 ms |  0.148 ms |
|                BaseLine_set1_op_date |             2fields,op,date |    38.54 ms |  0.649 ms |  0.607 ms |
|              NotIndexed_set1_op_date |             2fields,op,date |    38.78 ms |  0.701 ms |  0.656 ms |
|              BaseLine_set1_both_date |           5fields,both,date |   157.39 ms |  3.027 ms |  2.683 ms |
|            NotIndexed_set1_both_date |           5fields,both,date |   156.83 ms |  0.935 ms |  0.874 ms |
|    BaseLine_first_both_date_int_bool |  9fields,both,bool,int,date |    14.83 ms |  0.295 ms |  0.384 ms |
|  NotIndexed_first_both_date_int_bool |  9fields,both,bool,int,date |   315.47 ms |  5.305 ms |  4.702 ms |
|     BaseLine_first_req_string_single |          1fields,req,string | 1,417.21 ms |  9.897 ms |  9.257 ms |
|   NotIndexed_first_req_string_single |          1fields,req,string | 1,413.70 ms |  7.828 ms |  6.939 ms |
|      BaseLine_set1_req_string_single |          1fields,req,string | 1,412.81 ms | 10.720 ms | 10.027 ms |
|    NotIndexed_set1_req_string_single |          1fields,req,string | 1,433.07 ms | 28.497 ms | 34.997 ms |
|      BaseLine_set2_req_string_single |          1fields,req,string | 1,388.77 ms |  9.584 ms |  8.965 ms |
|    NotIndexed_set2_req_string_single |          1fields,req,string | 1,406.49 ms | 27.769 ms | 29.712 ms |
|             BaseLine_set1_req_string |          2fields,req,string |   417.36 ms |  4.475 ms |  3.967 ms |
|           NotIndexed_set1_req_string |          2fields,req,string |   432.84 ms |  8.642 ms | 17.458 ms |
|             BaseLine_set2_req_string |          2fields,req,string |   413.73 ms |  3.119 ms |  2.605 ms |
|           NotIndexed_set2_req_string |          2fields,req,string |   415.97 ms |  6.713 ms |  5.950 ms |
|            BaseLine_first_req_string |          4fields,req,string | 1,474.58 ms |  9.438 ms |  8.367 ms |
|          NotIndexed_first_req_string |          4fields,req,string | 1,475.95 ms | 11.583 ms | 10.268 ms |
|       BaseLine_set1_op_string_single |           1fields,op,string | 2,616.05 ms | 51.374 ms | 88.617 ms |
|     NotIndexed_set1_op_string_single |           1fields,op,string | 2,588.05 ms | 35.577 ms | 33.278 ms |
|      BaseLine_first_op_string_single |           1fields,op,string | 2,548.62 ms | 13.041 ms | 11.560 ms |
|    NotIndexed_first_op_string_single |           1fields,op,string | 2,554.74 ms | 15.754 ms | 13.965 ms |
|             BaseLine_first_op_string |           3fields,op,string | 2,553.84 ms | 16.913 ms | 14.993 ms |
|           NotIndexed_first_op_string |           3fields,op,string | 2,561.59 ms | 16.619 ms | 14.732 ms |

</details>

<details>
  <summary>Fig 21: Json Index Misc Benchmarks - Box Plot</summary>

![Fig 21: Json Index Misc Benchmarks - Box Plot](readme%20files/results/Index%20Testing/misc%20test/miscTests-All-boxplot-line.png)

</details>
