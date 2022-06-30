``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                                     Method |                          Categories |      Mean |    Error |   StdDev |
|------------------------------------------- |------------------------------------ |----------:|---------:|---------:|
|           Indexed_first_both_date_int_bool | json,hascolumns,indexed,first,dates |  15.46 ms | 0.304 ms | 0.547 ms |
|             Media_first_both_date_int_bool |  table,hascolumns,media,first,dates | 406.55 ms | 5.210 ms | 4.351 ms |
| Indexed_noColumns_first_both_date_int_bool |  json,nocolumns,indexed,first,dates |  15.07 ms | 0.298 ms | 0.446 ms |
|   Media_noColumns_first_both_date_int_bool |   table,nocolumns,media,first,dates | 398.38 ms | 5.232 ms | 4.638 ms |
