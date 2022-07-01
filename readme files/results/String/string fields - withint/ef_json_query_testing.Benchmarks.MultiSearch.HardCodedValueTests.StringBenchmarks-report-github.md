``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                   Method |               Categories |      Mean |     Error |    StdDev |    Median |
|------------------------- |------------------------- |----------:|----------:|----------:|----------:|
|    Media_Req_One_WithInt |    media,one,req,withint | 44.794 ms | 0.7572 ms | 0.9299 ms | 44.830 ms |
|     Json_Req_One_WithInt |     json,one,req,withint |  1.224 ms | 0.0460 ms | 0.1334 ms |  1.232 ms |
|    Media_Req_Two_WithInt |    media,two,req,withint | 43.671 ms | 0.5532 ms | 0.5175 ms | 43.480 ms |
|     Json_Req_Two_WithInt |     json,two,req,withint |  1.204 ms | 0.0480 ms | 0.1378 ms |  1.193 ms |
|  Media_Req_Three_WithInt |  media,three,req,withint | 43.581 ms | 0.6628 ms | 0.6200 ms | 43.691 ms |
|   Json_Req_Three_WithInt |   json,three,req,withint |  1.262 ms | 0.0489 ms | 0.1434 ms |  1.252 ms |
|   Media_Req_Four_WithInt |   media,four,req,withint | 45.218 ms | 0.7148 ms | 0.6686 ms | 45.258 ms |
|    Json_Req_Four_WithInt |    json,four,req,withint |  1.262 ms | 0.0473 ms | 0.1372 ms |  1.236 ms |
|   Media_Req_Five_WithInt |   media,five,req,withint | 44.746 ms | 0.6628 ms | 0.5876 ms | 44.728 ms |
|    Json_Req_Five_WithInt |    json,five,req,withint |  1.306 ms | 0.0409 ms | 0.1167 ms |  1.289 ms |
|    Media_Req_Six_WithInt |    media,six,req,withint | 44.625 ms | 0.5108 ms | 0.4528 ms | 44.605 ms |
|     Json_Req_Six_WithInt |     json,six,req,withint |  1.355 ms | 0.0512 ms | 0.1501 ms |  1.359 ms |
|  Media_Req_Seven_WithInt |  media,seven,req,withint | 45.030 ms | 0.8944 ms | 0.7469 ms | 45.115 ms |
|   Json_Req_Seven_WithInt |   json,seven,req,withint |  1.368 ms | 0.0524 ms | 0.1529 ms |  1.373 ms |
|  Media_Req_Eight_WithInt |  media,eight,req,withint | 45.482 ms | 0.8708 ms | 0.8145 ms | 45.567 ms |
|   Json_Req_Eight_WithInt |   json,eight,req,withint |  1.455 ms | 0.0517 ms | 0.1501 ms |  1.438 ms |
|     Media_Op_One_WithInt |     media,one,op,withint | 44.364 ms | 0.5180 ms | 0.4592 ms | 44.318 ms |
|      Json_Op_One_WithInt |      json,one,op,withint |  1.294 ms | 0.0561 ms | 0.1637 ms |  1.309 ms |
|     Media_Op_Two_WithInt |     media,two,op,withint | 45.643 ms | 0.7027 ms | 0.6573 ms | 45.486 ms |
|      Json_Op_Two_WithInt |      json,two,op,withint |  1.281 ms | 0.0526 ms | 0.1534 ms |  1.310 ms |
|   Media_Op_Three_WithInt |   media,three,op,withint | 47.429 ms | 0.7521 ms | 0.7035 ms | 47.544 ms |
|    Json_Op_Three_WithInt |    json,three,op,withint |  1.327 ms | 0.0496 ms | 0.1431 ms |  1.333 ms |
|    Media_Op_Four_WithInt |    media,four,op,withint | 47.372 ms | 0.9432 ms | 1.3825 ms | 47.107 ms |
|     Json_Op_Four_WithInt |     json,four,op,withint |  1.408 ms | 0.0483 ms | 0.1409 ms |  1.379 ms |
|    Media_Op_Five_WithInt |    media,five,op,withint | 47.577 ms | 0.8963 ms | 0.9204 ms | 47.570 ms |
|     Json_Op_Five_WithInt |     json,five,op,withint |  1.495 ms | 0.0500 ms | 0.1450 ms |  1.500 ms |
|     Media_Op_Six_WithInt |     media,six,op,withint | 47.997 ms | 0.8303 ms | 0.8527 ms | 48.007 ms |
|      Json_Op_Six_WithInt |      json,six,op,withint |  1.560 ms | 0.0802 ms | 0.2340 ms |  1.488 ms |
|   Media_Op_Seven_WithInt |   media,seven,op,withint | 46.671 ms | 0.5342 ms | 0.4461 ms | 46.636 ms |
|    Json_Op_Seven_WithInt |    json,seven,op,withint |  1.571 ms | 0.0465 ms | 0.1357 ms |  1.535 ms |
|   Media_Op_Eight_WithInt |   media,eight,op,withint | 47.579 ms | 0.9378 ms | 0.9630 ms | 47.390 ms |
|    Json_Op_Eight_WithInt |    json,eight,op,withint |  1.626 ms | 0.0493 ms | 0.1431 ms |  1.585 ms |
|   Media_Both_Two_WithInt |   media,two,both,withint | 43.603 ms | 0.4240 ms | 0.3540 ms | 43.492 ms |
|    Json_Both_Two_WithInt |    json,two,both,withint |  1.268 ms | 0.0418 ms | 0.1214 ms |  1.274 ms |
|  Media_Both_Four_WithInt |  media,four,both,withint | 45.548 ms | 0.8413 ms | 1.6006 ms | 45.268 ms |
|   Json_Both_Four_WithInt |   json,four,both,withint |  1.445 ms | 0.0551 ms | 0.1616 ms |  1.433 ms |
|   Media_Both_Six_WithInt |   media,six,both,withint | 45.010 ms | 0.6056 ms | 0.5057 ms | 45.106 ms |
|    Json_Both_Six_WithInt |    json,six,both,withint |  1.591 ms | 0.0551 ms | 0.1617 ms |  1.598 ms |
| Media_Both_Eight_WithInt | media,eight,both,withint | 45.163 ms | 0.7213 ms | 0.6023 ms | 45.015 ms |
|  Json_Both_Eight_WithInt |  json,eight,both,withint |  1.721 ms | 0.0542 ms | 0.1564 ms |  1.705 ms |
