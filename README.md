# Entity Framework Vs Json Queries 

### Content
1. Data Model
2. Test Data
3. Search Patterns
4. Running
5. Results


## Data Model
I'm using the below structure to mimic what an ad hock query builder could use for testing user created queries.
![](readme%20files/dataModel/querybuilder.png)

The structure for testing searching where each bit of information is saved as a seprate row in a table
![](readme%20files/dataModel/media.png)

The structure for testing searching with the information stored in JSON
![](readme%20files/dataModel/json.png)

Note: The table and json structures are separated into different models: `Media_Dynamic` and `Media_Json`


## Test Data
I'm using [Bogus](https://github.com/bchavez/Bogus) with a hardcoded seed value to easily create lots of consistent semi-realistic looking data to add into the above data structures. 
`Media_Dynamic` is created then a selection of `DynamicFields` are used to generate data for the media item into `DynamicMediaInformation`. When all items for `Media_Dynmic` are done, this information is duplicated into `Media_Json` to reduce variables when testing search patterns.


## Search Patterns
Multiple search pattern types were created to see what varients were most efficient. The intent is to see how each handles different search patterns, however all of the below are currently only setup to handle a basic `AND` search rather than the full query builder outlined above. For each pattern, unit tests were added to allow easily checking their validity along with how they each handle bad user input using [NaughtyStrings](https://github.com/SimonCropp/NaughtyStrings).

- Json - using Raw sql.
    - Creates a sql query to have EF run. 
    - Has single and multi selected field variants.
    -  uses parametrized values to avoid sql injection.
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

## Running Benchmarks

## Results
