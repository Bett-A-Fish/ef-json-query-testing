``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                          Method |                         Categories |      Mean |    Error |   StdDev |
|-------------------------------- |----------------------------------- |----------:|---------:|---------:|
|           Indexed_set1_req_date | json,hascolumns,indexed,set1,dates |  25.85 ms | 0.514 ms | 0.455 ms |
|             Media_set1_req_date |  table,hascolumns,media,set1,dates | 376.34 ms | 7.443 ms | 7.310 ms |
| Indexed_noColumns_set1_req_date |  json,nocolumns,indexed,set1,dates |  13.08 ms | 0.259 ms | 0.467 ms |
|   Media_noColumns_set1_req_date |   table,nocolumns,media,set1,dates | 352.69 ms | 6.394 ms | 5.339 ms |
