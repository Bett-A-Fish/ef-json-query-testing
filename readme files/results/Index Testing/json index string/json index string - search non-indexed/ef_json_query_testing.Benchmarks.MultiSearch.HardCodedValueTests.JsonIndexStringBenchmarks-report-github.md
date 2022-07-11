``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|                  Method |                Categories |        Mean |     Error |    StdDev |
|------------------------ |-------------------------- |------------:|----------:|----------:|
|  Json_Req_One_BuildUpon |  one,req,buildupon,string |    26.05 ms |  0.458 ms |  0.358 ms |
| Json_Req_Four_BuildUpon | four,req,buildupon,string | 1,270.28 ms | 24.974 ms | 24.527 ms |
|   Json_Op_One_BuildUpon |   one,op,buildupon,string |   167.72 ms |  1.879 ms |  1.666 ms |
|  Json_Op_Four_BuildUpon |  four,op,buildupon,string | 4,803.21 ms | 17.371 ms | 15.399 ms |
