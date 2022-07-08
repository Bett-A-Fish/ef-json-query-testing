``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|                     Method |         Categories |     Mean |     Error |    StdDev |
|--------------------------- |------------------- |---------:|----------:|----------:|
| Indexed_first_req_bool_int | seven,req,bool,int | 7.089 ms | 0.1335 ms | 0.2844 ms |
|       Indexed_first_op_int |        four,op,int | 3.822 ms | 0.0733 ms | 0.1119 ms |
