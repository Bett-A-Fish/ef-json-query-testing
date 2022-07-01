``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|           Method |       Categories |        Mean |     Error |    StdDev |
|----------------- |----------------- |------------:|----------:|----------:|
|    Media_Req_One |    media,one,req |   153.63 ms |  3.046 ms |  4.368 ms |
|     Json_Req_One |     json,one,req |    26.43 ms |  0.521 ms |  0.714 ms |
|    Media_Req_Two |    media,two,req | 1,721.58 ms | 11.659 ms | 10.336 ms |
|     Json_Req_Two |     json,two,req |   493.26 ms |  6.767 ms |  6.330 ms |
|  Media_Req_Three |  media,three,req | 2,572.17 ms | 19.979 ms | 17.711 ms |
|   Json_Req_Three |   json,three,req | 1,966.27 ms | 11.146 ms |  9.880 ms |
|   Media_Req_Four |   media,four,req | 3,409.05 ms | 26.122 ms | 24.435 ms |
|    Json_Req_Four |    json,four,req | 2,383.64 ms |  9.347 ms |  8.743 ms |
|   Media_Req_Five |   media,five,req | 4,234.82 ms | 10.756 ms |  8.982 ms |
|    Json_Req_Five |    json,five,req | 1,402.98 ms |  7.307 ms |  5.705 ms |
|    Media_Req_Six |    media,six,req | 5,221.28 ms | 95.834 ms | 89.643 ms |
|     Json_Req_Six |     json,six,req | 2,594.07 ms | 14.244 ms | 13.324 ms |
|  Media_Req_Seven |  media,seven,req | 6,009.03 ms | 16.013 ms | 14.979 ms |
|   Json_Req_Seven |   json,seven,req | 2,609.36 ms |  9.405 ms |  8.797 ms |
|  Media_Req_Eight |  media,eight,req | 6,827.40 ms | 19.107 ms | 17.872 ms |
|   Json_Req_Eight |   json,eight,req | 4,680.04 ms | 10.539 ms |  9.342 ms |
|     Media_Op_One |     media,one,op |    62.31 ms |  1.176 ms |  1.307 ms |
|      Json_Op_One |      json,one,op |    28.05 ms |  0.264 ms |  0.234 ms |
|     Media_Op_Two |     media,two,op |   863.29 ms |  1.770 ms |  1.569 ms |
|      Json_Op_Two |      json,two,op | 2,206.16 ms | 15.537 ms | 12.974 ms |
|   Media_Op_Three |   media,three,op | 1,362.10 ms |  9.611 ms |  8.520 ms |
|    Json_Op_Three |    json,three,op | 5,340.91 ms | 19.233 ms | 17.050 ms |
|    Media_Op_Four |    media,four,op | 1,798.65 ms |  3.925 ms |  3.671 ms |
|     Json_Op_Four |     json,four,op | 5,403.10 ms | 33.622 ms | 31.450 ms |
|    Media_Op_Five |    media,five,op | 2,185.05 ms |  4.914 ms |  4.597 ms |
|     Json_Op_Five |     json,five,op | 5,371.52 ms | 21.022 ms | 18.635 ms |
|     Media_Op_Six |     media,six,op | 2,669.32 ms | 18.444 ms | 17.253 ms |
|      Json_Op_Six |      json,six,op | 5,461.66 ms | 10.487 ms |  9.810 ms |
|   Media_Op_Seven |   media,seven,op | 2,793.89 ms |  5.922 ms |  4.624 ms |
|    Json_Op_Seven |    json,seven,op | 6,735.02 ms | 16.532 ms | 15.464 ms |
|   Media_Op_Eight |   media,eight,op | 3,486.25 ms | 13.419 ms | 11.896 ms |
|    Json_Op_Eight |    json,eight,op | 5,306.52 ms | 18.558 ms | 17.359 ms |
|   Media_Both_Two |   media,two,both | 1,338.78 ms |  9.500 ms |  8.887 ms |
|    Json_Both_Two |    json,two,both | 2,536.93 ms | 10.512 ms |  9.833 ms |
|  Media_Both_Four |  media,four,both | 2,693.03 ms | 10.054 ms |  9.404 ms |
|   Json_Both_Four |   json,four,both | 5,431.76 ms | 14.023 ms | 13.117 ms |
|   Media_Both_Six |   media,six,both | 3,682.96 ms | 12.264 ms | 11.471 ms |
|    Json_Both_Six |    json,six,both | 3,665.26 ms |  8.397 ms |  7.444 ms |
| Media_Both_Eight | media,eight,both | 5,169.48 ms | 21.261 ms | 18.848 ms |
|  Json_Both_Eight |  json,eight,both | 5,442.79 ms | 13.986 ms | 13.083 ms |
