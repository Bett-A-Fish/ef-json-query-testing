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
  - Tests normal and `NoColumns` versions of the search patterns. (Vast improvement to dynamic search times, json didnt change)
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

### Categories

- `first` - given search values to find the first item in the table
- `last` - given search values to find the last item in the table
- `set` - values that will return more than one datarow for a search
- `req` - only searches on columns that are required to be in each row
- `op` - only searches on columns that are optional for each row
- `both` - search includes optional and required fields
- (`int`, `bool`, `string`, `date`) - the types of search values used
- `#fields` (1,2,3,4,5,6,7,9) - the number of fields searched on

## Results

A lot of the benchmarks included in this project were done before the business decision of not returning the media information. Which vastly improved the speed of the dynamic table search patterns. The test results of these have still been included but will not be reviewed here. These sections include: `Column Count`, `Less Random`, and `Split Query`. While the dynamic search patterns improved with the removal of the column data, the json patterns didn't see much difference, but for the sake of consistency I will focus on the `No Column` version of the json search patterns. However a lot of the test results still include the original version of json and dynamic search so they can be easily compared with the `No Column` versions.

The plots are generated using the included `BuildPlots_alt.R` file.

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

*Tbl 1: No Columns Benchmarks - dynamic* 
|                                    Method |           Categories |          Mean |         Error |        StdDev |
|------------------------------------------ |--------------------- |--------------:|--------------:|--------------:|
|                  Media_set1_both_int_bool |      hascolumns,set1 |    145.070 ms |     2.5972 ms |     3.0917 ms |
|        Media_noColumns_set1_both_int_bool |       nocolumns,set1 |    135.077 ms |     1.3963 ms |     1.2378 ms |
|                   Media_set1_req_int_bool |      hascolumns,set1 |    271.996 ms |     4.8273 ms |     4.2793 ms |
|         Media_noColumns_set1_req_int_bool |       nocolumns,set1 |    269.232 ms |     1.9638 ms |     1.5332 ms |
|                         Media_set1_op_int |      hascolumns,set1 |     72.571 ms |     1.0938 ms |     0.9696 ms |
|               Media_noColumns_set1_op_int |       nocolumns,set1 |     67.871 ms |     0.9793 ms |     0.9160 ms |
|                     Media_set1_req_string |      hascolumns,set1 |    169.146 ms |     3.3757 ms |     7.1939 ms |
|           Media_noColumns_set1_req_string |       nocolumns,set1 |  1,551.383 ms |    25.1084 ms |    23.4864 ms |
|               Media_set1_op_string_single |      hascolumns,set1 | 22,116.768 ms | 1,084.1167 ms | 3,145.2191 ms |
|     Media_noColumns_set1_op_string_single |       nocolumns,set1 |    427.422 ms |     3.4945 ms |     2.9181 ms |
|              Media_set1_req_string_single |      hascolumns,set1 | 29,306.243 ms |   579.0830 ms |   983.3268 ms |
|    Media_noColumns_set1_req_string_single |       nocolumns,set1 |    853.966 ms |    13.1366 ms |    10.9696 ms |
|                 Media_first_both_bool_int |     hascolumns,first |    134.972 ms |     1.4135 ms |     1.2530 ms |
|       Media_noColumns_first_both_bool_int |      nocolumns,first |    134.785 ms |     1.9739 ms |     1.8464 ms |
|                  Media_first_req_bool_int |     hascolumns,first |    249.123 ms |     3.3765 ms |     2.8195 ms |
|        Media_noColumns_first_req_bool_int |      nocolumns,first |    265.708 ms |     5.0133 ms |     4.4442 ms |
|                        Media_first_op_int |     hascolumns,first |     89.694 ms |     1.7909 ms |     2.3287 ms |
|              Media_noColumns_first_op_int |      nocolumns,first |     90.168 ms |     1.6429 ms |     1.3719 ms |
|                    Media_first_req_string |     hascolumns,first |  3,132.863 ms |    28.2227 ms |    26.3995 ms |
|          Media_noColumns_first_req_string |      nocolumns,first |  3,125.529 ms |    28.1682 ms |    26.3485 ms |
|                     Media_first_op_string |     hascolumns,first |    492.253 ms |     6.4743 ms |     5.0547 ms |
|           Media_noColumns_first_op_string |      nocolumns,first |    494.283 ms |     8.9849 ms |     9.9867 ms |
|              Media_first_op_string_single |     hascolumns,first |     76.057 ms |     2.1989 ms |     6.4490 ms |
|    Media_noColumns_first_op_string_single |      nocolumns,first |    406.639 ms |     5.1703 ms |     4.3175 ms |
|             Media_first_req_string_single |     hascolumns,first |    139.974 ms |     2.7730 ms |     6.8541 ms |
|   Media_noColumns_first_req_string_single |      nocolumns,first |    827.508 ms |     4.6228 ms |     3.8603 ms |

*Tbl 2: No Columns Benchmarks - json* 
|                                    Method |          Categories |          Mean |         Error |        StdDev |
|------------------------------------------ |-------------------- |--------------:|--------------:|--------------:|
|               Indexed_first_both_bool_int |    hascolumns,first |      6.642 ms |     0.1323 ms |     0.3531 ms |
|     Indexed_noColumns_first_both_bool_int |     nocolumns,first |      6.440 ms |     0.1281 ms |     0.3094 ms |
|                Indexed_first_req_bool_int |    hascolumns,first |     28.642 ms |     0.5380 ms |     0.4492 ms |
|      Indexed_noColumns_first_req_bool_int |     nocolumns,first |     27.370 ms |     0.3812 ms |     0.3184 ms |
|                      Indexed_first_op_int |    hascolumns,first |      4.765 ms |     0.0953 ms |     0.2494 ms |
|            Indexed_noColumns_first_op_int |     nocolumns,first |      4.515 ms |     0.0884 ms |     0.1452 ms |
|                  Indexed_first_req_string |    hascolumns,first |  1,466.409 ms |    28.4672 ms |    26.6282 ms |
|        Indexed_noColumns_first_req_string |     nocolumns,first |  1,463.739 ms |    19.8935 ms |    18.6084 ms |
|                   Indexed_first_op_string |    hascolumns,first |  2,511.278 ms |    15.3365 ms |    14.3458 ms |
|         Indexed_noColumns_first_op_string |     nocolumns,first |  2,517.308 ms |    24.1128 ms |    21.3753 ms |
|            Indexed_first_op_string_single |    hascolumns,first |  2,501.888 ms |     6.5184 ms |     5.0891 ms |
|  Indexed_noColumns_first_op_string_single |     nocolumns,first |  2,513.694 ms |    19.7399 ms |    17.4989 ms |
|           Indexed_first_req_string_single |    hascolumns,first |  1,410.806 ms |    22.5999 ms |    21.1400 ms |
| Indexed_noColumns_first_req_string_single |     nocolumns,first |  1,409.895 ms |    26.6260 ms |    24.9060 ms |
|                Indexed_set1_both_int_bool |     hascolumns,set1 |     12.186 ms |     0.2398 ms |     0.2665 ms |
|      Indexed_noColumns_set1_both_int_bool |      nocolumns,set1 |      6.042 ms |     0.1145 ms |     0.2655 ms |
|                 Indexed_set1_req_int_bool |     hascolumns,set1 |     17.135 ms |     0.3383 ms |     0.5064 ms |
|       Indexed_noColumns_set1_req_int_bool |      nocolumns,set1 |     13.913 ms |     0.2726 ms |     0.4163 ms |
|                       Indexed_set1_op_int |     hascolumns,set1 |      7.768 ms |     0.1404 ms |     0.1313 ms |
|             Indexed_noColumns_set1_op_int |      nocolumns,set1 |      3.700 ms |     0.0735 ms |     0.1910 ms |
|                   Indexed_set1_req_string |     hascolumns,set1 |    420.444 ms |     8.3722 ms |     7.8313 ms |
|         Indexed_noColumns_set1_req_string |      nocolumns,set1 |    418.181 ms |     8.0565 ms |     6.7275 ms |
|             Indexed_set1_op_string_single |     hascolumns,set1 |  2,514.774 ms |    47.6085 ms |    44.5330 ms |
|   Indexed_noColumns_set1_op_string_single |      nocolumns,set1 |  2,503.007 ms |    44.4445 ms |    41.5734 ms |
|            Indexed_set1_req_string_single |     hascolumns,set1 |  1,404.229 ms |    23.8953 ms |    22.3517 ms |
|  Indexed_noColumns_set1_req_string_single |      nocolumns,set1 |  1,403.096 ms |    19.6017 ms |    18.3354 ms |

*Fig 1: No Columns Benchmarks - first*
![Fig 1: No Columns Benchmarks - first](readme%20files%5Cresults%5CNo%20Columns%5Cno%20columns%20-%20all%5Cfirst%5Cef_json_query_testing.Benchmarks.NoColumnsBenchmarks-boxplot.png)

*Fig 2: No Columns Benchmarks - set1*
![Fig 2: No Columns Benchmarks - set1](readme%20files%5Cresults%5CNo%20Columns%5Cno%20columns%20-%20all%5Cset1%5Cef_json_query_testing.Benchmarks.NoColumnsBenchmarks-boxplot.png)

*Fig 3: No Columns Benchmarks - strings only*
![Fig 3: No Columns Benchmarks - strings only](readme%20files%5Cresults%5CNo%20Columns%5Cno%20columns%20-%20string%20only%5Cef_json_query_testing.Benchmarks.NoColumnsBenchmarks-boxplot.png)

### Date Field

Date fields were not originally included in the benchmarks because additional work needed to be done to have them work properly. The dynamic search pattern needed a custom EF function added to allow for date conversions on the sql side. While json needed dates converted into a deterministic style to allow for indexing to be added. While the search for int and bool are exact matches, date search was setup to look for values with equal or greater dates than the one provided.

`Tbl 3` is a collection of data taken from the previous tables and the benchmark runs for Date fields to compare the search times for dates against those without. Dates can be seen to slightly increase search time for both json and dynamic search styles. Most drastically for dynamic when searching over both required and optional fields with a difference of 322ms. Json is seen to consistently run faster than the dynamic search.

*Tbl 3:  Date Field Benchmarks*
|                                     Method |                     Categories |       Mean |     Error |    StdDev |
|------------------------------------------- |------------------------------- |-----------:|----------:|----------:|
|            Indexed_noColumns_set1_req_date |             json,req,set1,date |   13.08 ms |  0.259 ms |  0.467 ms |
|        Indexed_noColumns_set1_req_int_bool |         json,req,set1,int,bool |  13.913 ms | 0.2726 ms | 0.4163 ms |
|              Media_noColumns_set1_req_date |            table,req,set1,date |  352.69 ms |  6.394 ms |  5.339 ms |
|          Media_noColumns_set1_req_int_bool |        table,req,set1,int,bool | 269.232 ms | 1.9638 ms | 1.5332 ms |
|             Indexed_noColumns_set1_op_date |              json,op,set1,date |   37.43 ms |  0.253 ms |  0.211 ms |
|              Indexed_noColumns_set1_op_int |               json,op,set1,int |   3.700 ms | 0.0735 ms | 0.1910 ms |
|               Media_noColumns_set1_op_date |             table,op,set1,date |  113.82 ms |  1.351 ms |  1.264 ms |
|                Media_noColumns_set1_op_int |              table,op,set1,int |  67.871 ms | 0.9793 ms | 0.9160 ms |
|           Indexed_noColumns_set1_both_date |            json,both,set1,date |   158.5 ms |   3.12 ms |   2.61 ms |
|       Indexed_noColumns_set1_both_int_bool |            json,both,set1,bool |   6.042 ms | 0.1145 ms | 0.2655 ms |
|             Media_noColumns_set1_both_date |           table,both,set1,date |   456.7 ms |   2.62 ms |   2.19 ms |
|         Media_noColumns_set1_both_int_bool |           table,both,set1,bool | 135.077 ms | 1.3963 ms | 1.2378 ms |
| Indexed_noColumns_first_both_date_int_bool |  json,both,first,int,bool,date |   15.07 ms |  0.298 ms |  0.446 ms |
|      Indexed_noColumns_first_both_bool_int |       json,both,first,int,bool |   6.440 ms | 0.1281 ms | 0.3094 ms |
|   Media_noColumns_first_both_date_int_bool | table,both,first,int,bool,date |  398.38 ms |  5.232 ms |  4.638 ms |
|        Media_noColumns_first_both_bool_int |      table,both,first,int,bool | 134.785 ms | 1.9739 ms | 1.8464 ms |

### Misc

The misc benchmarks are a collection of benchmarks I pulled from other places when I wanted to further dig into what was causing the odd search times in certain scenarios. It also includes extra benchmarks to compare to the oddities.

`Tbl 4` shows a collection of different benchmarks comparing json and dynamics no columns search patterns. For the data types of int, bool, and date, json is consistently faster than the dynamic search. `Tbl 5` is string only searches and is where the data gets strange. In most test cases where all fields searched are required, json runs faster. However, there seems to be a correlation between the field count and when the dynamic pattern would run faster. Fo the optional field searches, json was consistently worse than the dynamic search. Which leads into the next set of benchmarks focused on strings that go into more detail on these oddities.

*Tbl 4:  Misc Benchmarks - int, bool, and dates*
|                                      Method |                  Categories |          Mean |       Error |        StdDev | Field Count |
|-------------------------------------------- |---------------------------- |--------------:|------------:|--------------:|------------:|
|         Media_NoColumns_first_both_bool_int |         media,both,bool,int |    137.736 ms |   1.7443 ms |     1.5463 ms |           6 |
|       Indexed_NoColumns_first_both_bool_int |       Indexed,both,bool,int |      4.225 ms |   0.0903 ms |     0.2621 ms |           6 |
|          Media_NoColumns_first_req_bool_int |          media,req,bool,int |    226.766 ms |   2.4157 ms |     2.1415 ms |           7 |
|        Indexed_NoColumns_first_req_bool_int |        Indexed,req,bool,int |      7.471 ms |   0.1444 ms |     0.2333 ms |           7 |
|                Media_NoColumns_first_op_int |                media,op,int |     90.938 ms |   1.4189 ms |     1.2578 ms |           4 |
|              Indexed_NoColumns_first_op_int |              Indexed,op,int |      3.967 ms |   0.0771 ms |     0.2174 ms |           4 |
|    Media_NoColumns_first_both_date_int_bool |    media,both,bool,int,date |    404.453 ms |   4.1403 ms |     3.4573 ms |           9 |
|  Indexed_NoColumns_first_both_date_int_bool |  Indexed,both,bool,int,date |     14.679 ms |   0.2885 ms |     0.4491 ms |           9 |
|               Media_NoColumns_set1_req_date |              media,req,date |    352.554 ms |   6.6846 ms |     5.9258 ms |           3 |
|             Indexed_NoColumns_set1_req_date |            Indexed,req,date |     13.153 ms |   0.2595 ms |     0.4264 ms |           3 |
|                Media_NoColumns_set1_op_date |               media,op,date |    118.228 ms |   2.2492 ms |     2.3097 ms |           2 |
|              Indexed_NoColumns_set1_op_date |             Indexed,op,date |     37.716 ms |   0.7233 ms |     0.9147 ms |           2 |
|              Media_NoColumns_set1_both_date |             media,both,date |    464.646 ms |   5.6165 ms |     4.6900 ms |           5 |
|            Indexed_NoColumns_set1_both_date |           Indexed,both,date |    157.691 ms |   2.4201 ms |     2.5894 ms |           5 |

*Tbl 5:  Misc Benchmarks - strings*
|                                      Method |   Categories |          Mean |       Error |        StdDev | Field Count |
|-------------------------------------------- |------------- |--------------:|------------:|--------------:|------------:|
|            Media_NoColumns_first_req_string |    media,req |  3,184.654 ms |  60.3905 ms |    56.4893 ms |           4 |
|          Indexed_NoColumns_first_req_string |  Indexed,req |  1,502.366 ms |  19.4950 ms |    18.2357 ms |           4 |
|     Media_NoColumns_first_req_string_single |    media,req |    851.483 ms |  14.8172 ms |    13.8600 ms |           1 |
|   Indexed_NoColumns_first_req_string_single |  Indexed,req |  1,430.889 ms |  22.8104 ms |    21.3369 ms |           1 |
|             Media_NoColumns_set1_req_string |    media,req |  1,569.290 ms |  25.3611 ms |    23.7227 ms |           2 |
|           Indexed_NoColumns_set1_req_string |  Indexed,req |    426.467 ms |   5.0285 ms |     4.4576 ms |           2 |
|      Media_NoColumns_set1_req_string_single |    media,req |    865.013 ms |   9.8744 ms |     8.7534 ms |           1 |
|    Indexed_NoColumns_set1_req_string_single |  Indexed,req |  1,429.871 ms |  27.8590 ms |    27.3612 ms |           1 |
|             Media_NoColumns_set2_req_string |    media,req |  1,582.771 ms |  29.5328 ms |    27.6250 ms |           2 |
|           Indexed_NoColumns_set2_req_string |  Indexed,req |    415.466 ms |   3.1280 ms |     2.4421 ms |           2 |
|      Media_NoColumns_set2_req_string_single |    media,req |    839.025 ms |   3.2153 ms |     2.5103 ms |           1 |
|    Indexed_NoColumns_set2_req_string_single |  Indexed,req |  1,437.138 ms |  28.1644 ms |    35.6189 ms |           1 |
|             Media_NoColumns_first_op_string |     media,op |    494.814 ms |   9.5839 ms |     9.8420 ms |           3 |
|           Indexed_NoColumns_first_op_string |   Indexed,op |  2,589.288 ms |  36.7829 ms |    32.6071 ms |           3 |
|      Media_NoColumns_first_op_string_single |     media,op |    415.320 ms |   6.4889 ms |     5.7522 ms |           1 |
|    Indexed_NoColumns_first_op_string_single |   Indexed,op |  2,576.569 ms |  30.3320 ms |    28.3726 ms |           1 |
|       Media_NoColumns_set1_op_string_single |     media,op |    437.780 ms |   8.5108 ms |     7.1069 ms |           1 |
|     Indexed_NoColumns_set1_op_string_single |   Indexed,op |  2,577.872 ms |  41.3992 ms |    38.7249 ms |           1 |

*Fig 4:  Misc Benchmarks*
![Fig 4:  Misc Benchmarks](readme%20files%5Cresults%5CMisc%5Cmisc%20run%20reduced%20data%5CmiscTests-media-allcolumns-index-allcolumns-removed-line-boxplot.png)

### String

These benchmarks use a different database than those above. The file for it has been included: `ef_testing_string_large.bacpac`. This database was setup specifically to test different scenarios for string searches. It is setup with 41 fields. 20 string columns that are required, 20 that are optional, and one additional column for an int.

#### String Categories

- `normal` - Each search has a random selection of values with an increasing amount of fields searched on
- `buildupon` - Each search has the same search terms as the previous plus one new one
- `shortstring` - Same as `buildupon` but each search field uses only 5 character long strings
- `longstring` - Same as `buildupon` but each search field uses strings of length 10
- `charcount` - Each search is over 4 fields with the lengths of the strings increasing in each search
- `withint` - A copy of `buildupon` with a required int field added onto each search

