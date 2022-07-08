``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|                           Method |                   Categories |      Mean |     Error |    StdDev |    Median |
|--------------------------------- |----------------------------- |----------:|----------:|----------:|----------:|
|   Json_Req_Seven_WithOptionalInt |   json,seven,req,optionalint |  1.523 ms | 0.0895 ms | 0.2624 ms |  1.514 ms |
|  Media_Req_Eight_WithOptionalInt |  media,eight,req,optionalint | 25.003 ms | 0.4796 ms | 0.4925 ms | 25.051 ms |
|   Json_Req_Eight_WithOptionalInt |   json,eight,req,optionalint |  1.540 ms | 0.0502 ms | 0.1449 ms |  1.518 ms |
|     Media_Op_One_WithOptionalInt |     media,one,op,optionalint | 23.740 ms | 0.4726 ms | 0.5977 ms | 23.741 ms |
|      Json_Op_One_WithOptionalInt |      json,one,op,optionalint |  1.326 ms | 0.0701 ms | 0.2033 ms |  1.264 ms |
|     Media_Op_Two_WithOptionalInt |     media,two,op,optionalint | 24.425 ms | 0.4724 ms | 0.6775 ms | 24.511 ms |
|      Json_Op_Two_WithOptionalInt |      json,two,op,optionalint |  1.457 ms | 0.0570 ms | 0.1654 ms |  1.460 ms |
|   Media_Op_Three_WithOptionalInt |   media,three,op,optionalint | 24.454 ms | 0.4493 ms | 0.4203 ms | 24.406 ms |
|    Json_Op_Three_WithOptionalInt |    json,three,op,optionalint |  1.472 ms | 0.0602 ms | 0.1756 ms |  1.466 ms |
|    Media_Op_Four_WithOptionalInt |    media,four,op,optionalint | 26.290 ms | 0.5535 ms | 1.6234 ms | 26.739 ms |
|     Json_Op_Four_WithOptionalInt |     json,four,op,optionalint |  1.570 ms | 0.0579 ms | 0.1699 ms |  1.560 ms |
|    Media_Op_Five_WithOptionalInt |    media,five,op,optionalint | 25.594 ms | 0.5056 ms | 0.9620 ms | 25.578 ms |
|     Json_Op_Five_WithOptionalInt |     json,five,op,optionalint |  1.664 ms | 0.0485 ms | 0.1399 ms |  1.671 ms |
|     Media_Op_Six_WithOptionalInt |     media,six,op,optionalint | 25.422 ms | 0.5073 ms | 1.0248 ms | 25.117 ms |
|      Json_Op_Six_WithOptionalInt |      json,six,op,optionalint |  1.717 ms | 0.0512 ms | 0.1462 ms |  1.710 ms |
|   Media_Op_Seven_WithOptionalInt |   media,seven,op,optionalint | 25.267 ms | 0.4683 ms | 0.4381 ms | 25.337 ms |
|    Json_Op_Seven_WithOptionalInt |    json,seven,op,optionalint |  1.701 ms | 0.0516 ms | 0.1480 ms |  1.682 ms |
|   Media_Op_Eight_WithOptionalInt |   media,eight,op,optionalint | 25.506 ms | 0.4798 ms | 0.4488 ms | 25.565 ms |
|    Json_Op_Eight_WithOptionalInt |    json,eight,op,optionalint |  1.798 ms | 0.0530 ms | 0.1547 ms |  1.768 ms |
|   Media_Both_Two_WithOptionalInt |   media,two,both,optionalint | 24.129 ms | 0.4620 ms | 0.5135 ms | 24.160 ms |
|    Json_Both_Two_WithOptionalInt |    json,two,both,optionalint |  1.327 ms | 0.0510 ms | 0.1488 ms |  1.332 ms |
|  Media_Both_Four_WithOptionalInt |  media,four,both,optionalint | 24.810 ms | 0.4778 ms | 0.5112 ms | 24.881 ms |
|   Json_Both_Four_WithOptionalInt |   json,four,both,optionalint |  1.444 ms | 0.0503 ms | 0.1460 ms |  1.446 ms |
|   Media_Both_Six_WithOptionalInt |   media,six,both,optionalint | 25.582 ms | 0.5082 ms | 0.8490 ms | 25.480 ms |
|    Json_Both_Six_WithOptionalInt |    json,six,both,optionalint |  1.552 ms | 0.0620 ms | 0.1808 ms |  1.555 ms |
| Media_Both_Eight_WithOptionalInt | media,eight,both,optionalint | 25.808 ms | 0.5036 ms | 0.4464 ms | 25.624 ms |
|  Json_Both_Eight_WithOptionalInt |  json,eight,both,optionalint |  1.771 ms | 0.0501 ms | 0.1460 ms |  1.756 ms |
|    Media_Req_One_WithOptionalInt |    media,one,req,optionalint | 23.576 ms | 0.4694 ms | 0.7971 ms | 23.355 ms |
|     Json_Req_One_WithOptionalInt |     json,one,req,optionalint |  1.193 ms | 0.0511 ms | 0.1492 ms |  1.198 ms |
|    Media_Req_Two_WithOptionalInt |    media,two,req,optionalint | 23.561 ms | 0.3668 ms | 0.6614 ms | 23.478 ms |
|     Json_Req_Two_WithOptionalInt |     json,two,req,optionalint |  1.245 ms | 0.0463 ms | 0.1335 ms |  1.237 ms |
|  Media_Req_Three_WithOptionalInt |  media,three,req,optionalint | 23.388 ms | 0.3811 ms | 0.3378 ms | 23.425 ms |
|   Json_Req_Three_WithOptionalInt |   json,three,req,optionalint |  1.281 ms | 0.0499 ms | 0.1465 ms |  1.264 ms |
|   Media_Req_Four_WithOptionalInt |   media,four,req,optionalint | 23.907 ms | 0.4262 ms | 0.5234 ms | 23.777 ms |
|    Json_Req_Four_WithOptionalInt |    json,four,req,optionalint |  1.322 ms | 0.0501 ms | 0.1469 ms |  1.318 ms |
|   Media_Req_Five_WithOptionalInt |   media,five,req,optionalint | 24.298 ms | 0.4804 ms | 0.9371 ms | 23.947 ms |
|    Json_Req_Five_WithOptionalInt |    json,five,req,optionalint |  1.356 ms | 0.0492 ms | 0.1420 ms |  1.358 ms |
|    Media_Req_Six_WithOptionalInt |    media,six,req,optionalint | 24.270 ms | 0.4426 ms | 0.5096 ms | 24.054 ms |
|     Json_Req_Six_WithOptionalInt |     json,six,req,optionalint |  1.379 ms | 0.0602 ms | 0.1767 ms |  1.368 ms |
|  Media_Req_Seven_WithOptionalInt |  media,seven,req,optionalint | 24.233 ms | 0.3737 ms | 0.3312 ms | 24.204 ms |
