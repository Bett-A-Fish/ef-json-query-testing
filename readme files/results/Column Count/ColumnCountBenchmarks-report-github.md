``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                                 Method |                       Categories |        Mean |     Error |    StdDev |
|--------------------------------------- |--------------------------------- |------------:|----------:|----------:|
|          Media_count10_first_op_string |  table,columncount,first,count10 |   644.32 ms | 12.667 ms | 21.509 ms |
|   Media_count10_first_op_string_single |  table,columncount,first,count10 |   545.75 ms |  7.265 ms |  6.067 ms |
|         Media_count10_first_req_string |  table,columncount,first,count10 | 3,325.79 ms | 42.093 ms | 37.314 ms |
|  Media_count10_first_req_string_single |  table,columncount,first,count10 |   148.90 ms |  2.969 ms |  8.472 ms |
|          Media_count25_first_op_string |  table,columncount,first,count25 |   486.89 ms |  2.632 ms |  2.055 ms |
|   Media_count25_first_op_string_single |  table,columncount,first,count25 |    79.77 ms |  1.798 ms |  5.272 ms |
|         Media_count25_first_req_string |  table,columncount,first,count25 | 3,162.48 ms | 33.700 ms | 31.523 ms |
|  Media_count25_first_req_string_single |  table,columncount,first,count25 |   145.52 ms |  2.897 ms |  5.983 ms |
|         Media_countAll_first_op_string | table,columncount,first,countall |   498.29 ms |  8.871 ms |  7.864 ms |
|  Media_countAll_first_op_string_single | table,columncount,first,countall |    77.48 ms |  1.943 ms |  5.728 ms |
|        Media_countAll_first_req_string | table,columncount,first,countall | 3,159.02 ms | 18.331 ms | 16.250 ms |
| Media_countAll_first_req_string_single | table,columncount,first,countall |   140.97 ms |  2.812 ms |  5.992 ms |
