# Entity Framework Vs Json Queries

## Contents

1. Data Model
2. Test Data
3. Search Patterns
4. Running
5. Results

## Data Model

I'm using the below structure to mimic what an ad hock query builder could use for testing user created queries.
![Ad hock query builder structure](readme%20files/dataModel/querybuilder.png)

The structure for testing searching where each bit of information is saved as a seprate row in a table
![Media table structure](readme%20files/dataModel/media.png)

The structure for testing searching with the information stored in JSON
![Json table structure](readme%20files/dataModel/json.png)

Note: The table and json structures are separated into different models: `Media_Dynamic` and `Media_Json`

## Test Data

I'm using [Bogus](https://github.com/bchavez/Bogus) with a hardcoded seed value to easily create lots of consistent semi-realistic looking data to add into the above data structures. `Media_Dynamic` is created then a selection of `DynamicFields` are used to generate data for the media item into `DynamicMediaInformation`. When all items for `Media_Dynmic` are done, this information is duplicated into `Media_Json` to reduce variables when testing search patterns.

A large bacpac file that I used to benchmark these search patterns has been included `ef_testing_index_large.bacpac`. It has 100,000 generated rows of data. Or a new set can be generated with your own seed and data counts with `CreateBogusData.cs`

### CreateBogusData.cs

The field `FakerSeed` is the seed used for generating the bogus data.

`LoadAllData` Can be called to fill the whole database in one go. (`fieldsCount`) Generating the list of available dynamic fields each datarow has available with random datatypes and if required or not. (`mediaItemsCount`) Generating the total count of datarows to be able to search over. (`listTypeCount`) For generating some dropdown types and the list of options available for each.

`LoadSharedData` Loads the data for the ad hock query builder portion of the database. Filling out the available fields a datarow can contain. The parameters are the same as above.

`LoadMediaData` Loads the data for the Media and Json tables for running searches against. First it will create data for the media table, then copy that data into the json table.

Some extra private "large" versions of methods are included that I used to generate the massive bacpac file that has been included. These were only temporarily called and are not currently used.

## Search Patterns

Multiple search pattern types were created to see what varients were most efficient. The intent is to see how each handles different search patterns, however all of the below are currently only setup to handle a basic `AND` search rather than the full query builder outlined above. For each pattern, unit tests were added to allow easily checking their validity along with how they each handle bad user input using [NaughtyStrings](https://github.com/SimonCropp/NaughtyStrings).

- Json - using Raw sql.
  - Creates a sql query to have EF run.
  - Has single and multi selected field variants.
  - Uses parametrized values to avoid sql injection.
- Json - using EF magic
  - Through custom EF functions, a query is generated.
  - Has single and multi selected field variants.
- Json - with indexs
  - Creates a sql query to have EF run that will properly utilize indexing
  - Multi select variant only.
- Dynamic table - through `DynamicMediaInformation`
  - Uses EF to search through `DynamicMediaInformation` table to find `Media_Dynamic` rows that fit the given criteria.
  - single select variant only.
- Dynamic table - through `Media_Dynamic`
  - Uses EF to search through `Media_Dynamic`'s connected `DynamicMediaInformation` rows to find media items that match given criteria.
  - Has single and multi selected field variants.

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
                //.AddFilter(new AnyCategoriesFilter(new string[] { "indexed", "media" }))
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

## Results
