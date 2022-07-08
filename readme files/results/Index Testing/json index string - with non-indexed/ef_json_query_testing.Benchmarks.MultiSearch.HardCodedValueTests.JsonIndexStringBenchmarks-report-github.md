``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|                  Method |                Categories |        Mean |     Error |    StdDev |
|------------------------ |-------------------------- |------------:|----------:|----------:|
|  Json_Req_One_BuildUpon |  one,req,buildupon,string |    27.95 ms |  0.185 ms |  0.173 ms |
| Json_Req_Four_BuildUpon | four,req,buildupon,string | 1,273.21 ms | 24.125 ms | 24.775 ms |
|   Json_Op_One_BuildUpon |   one,op,buildupon,string |   166.21 ms |  1.443 ms |  1.205 ms |
|  Json_Op_Four_BuildUpon |  four,op,buildupon,string | 4,858.07 ms | 22.538 ms | 19.979 ms |
