``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|                     Method |         Categories |     Mean |     Error |    StdDev |   Median |
|--------------------------- |------------------- |---------:|----------:|----------:|---------:|
| Indexed_first_req_bool_int | seven,req,bool,int | 7.162 ms | 0.1417 ms | 0.3503 ms | 7.083 ms |
|       Indexed_first_op_int |        four,op,int | 3.768 ms | 0.1043 ms | 0.3076 ms | 3.686 ms |
