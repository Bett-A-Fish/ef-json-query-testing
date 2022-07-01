``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                         Method |                         Categories |      Mean |    Error |   StdDev |
|------------------------------- |----------------------------------- |----------:|---------:|---------:|
|           Indexed_set1_op_date | json,hascolumns,indexed,set2,dates |  45.51 ms | 0.635 ms | 0.563 ms |
|             Media_set1_op_date |  table,hascolumns,media,set2,dates | 143.42 ms | 2.784 ms | 2.604 ms |
| Indexed_noColumns_set1_op_date |  json,nocolumns,indexed,set2,dates |  37.43 ms | 0.253 ms | 0.211 ms |
|   Media_noColumns_set1_op_date |   table,nocolumns,media,set2,dates | 113.82 ms | 1.351 ms | 1.264 ms |
