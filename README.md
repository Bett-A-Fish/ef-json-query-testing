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

A lot of the benchmarks included in this project were done before the business decision of not returning the media information. Which vastly improved the speed of the dynamic table search patterns. The test results of these has still been included but will not be reviewed here. These sections include: `Column Count`, `Less Random`, and `Split Query`. While the dynamic search patterns improved with the removal of the column data, the json patterns didn't see much difference, but for the sake of consistency I will focus on the `No Column` version of the json search patterns. However a lot of the test results still include the original version of json and dynamic search so they can be easily compared with the `No Column` versions.

The plots are generated using the included `BuildPlots_alt.R` file.

### No Columns

### Date Field

### Misc

### String
