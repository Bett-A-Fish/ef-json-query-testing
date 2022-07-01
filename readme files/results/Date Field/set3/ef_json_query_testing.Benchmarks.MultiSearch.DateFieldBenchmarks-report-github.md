``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                           Method |                         Categories |     Mean |   Error |   StdDev |
|--------------------------------- |----------------------------------- |---------:|--------:|---------:|
|           Indexed_set1_both_date | json,hascolumns,indexed,set3,dates | 159.4 ms | 1.01 ms |  0.90 ms |
|             Media_set1_both_date |  table,hascolumns,media,set3,dates | 500.9 ms | 9.78 ms | 11.64 ms |
| Indexed_noColumns_set1_both_date |  json,nocolumns,indexed,set3,dates | 158.5 ms | 3.12 ms |  2.61 ms |
|   Media_noColumns_set1_both_date |   table,nocolumns,media,set3,dates | 456.7 ms | 2.62 ms |  2.19 ms |
