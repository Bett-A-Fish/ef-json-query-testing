``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                 Method |             Categories |        Mean |     Error |    StdDev |
|----------------------- |----------------------- |------------:|----------:|----------:|
|            Json_Op_One |            json,one,op |    26.59 ms |  0.530 ms |  0.496 ms |
|   Json_Adjusted_Op_One |   json,adjusted,one,op |    36.81 ms |  0.638 ms |  0.565 ms |
|            Json_Op_Two |            json,two,op | 1,967.09 ms | 19.934 ms | 18.646 ms |
|   Json_Adjusted_Op_Two |   json,adjusted,two,op | 2,890.25 ms | 24.956 ms | 23.344 ms |
|          Json_Op_Three |          json,three,op | 4,769.78 ms | 28.795 ms | 24.045 ms |
| Json_Adjusted_Op_Three | json,adjusted,three,op | 6,958.12 ms | 34.100 ms | 28.475 ms |
|           Json_Op_Four |           json,four,op | 4,778.30 ms | 10.345 ms |  8.638 ms |
|  Json_Adjusted_Op_Four |  json,adjusted,four,op | 6,985.07 ms | 37.876 ms | 35.429 ms |
|           Json_Op_Five |           json,five,op | 4,768.83 ms | 11.942 ms | 10.586 ms |
|  Json_Adjusted_Op_Five |  json,adjusted,five,op | 6,978.41 ms | 31.283 ms | 29.263 ms |
|            Json_Op_Six |            json,six,op | 4,903.54 ms | 23.117 ms | 19.304 ms |
|   Json_Adjusted_Op_Six |   json,adjusted,six,op | 7,209.97 ms | 36.848 ms | 34.468 ms |
|          Json_Op_Seven |          json,seven,op | 6,073.28 ms | 23.936 ms | 22.389 ms |
| Json_Adjusted_Op_Seven | json,adjusted,seven,op | 9,184.67 ms | 42.459 ms | 39.716 ms |
|          Json_Op_Eight |          json,eight,op | 4,772.98 ms | 22.209 ms | 19.688 ms |
| Json_Adjusted_Op_Eight | json,adjusted,eight,op | 6,990.87 ms | 34.126 ms | 31.921 ms |
