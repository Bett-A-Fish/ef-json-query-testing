``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                       Method |                   Categories |        Mean |     Error |    StdDev |
|----------------------------- |----------------------------- |------------:|----------:|----------:|
|   Json_Req_Three_ShortString |   json,three,req,shortstring | 1,280.30 ms | 14.273 ms | 12.653 ms |
|   Media_Req_Four_ShortString |   media,four,req,shortstring | 3,189.39 ms | 15.443 ms | 13.690 ms |
|    Json_Req_Four_ShortString |    json,four,req,shortstring | 1,308.16 ms | 25.161 ms | 22.304 ms |
|   Media_Req_Five_ShortString |   media,five,req,shortstring | 4,040.11 ms | 66.571 ms | 99.640 ms |
|    Json_Req_Five_ShortString |    json,five,req,shortstring | 1,280.73 ms | 16.058 ms | 15.021 ms |
|    Media_Req_Six_ShortString |    media,six,req,shortstring | 4,728.36 ms | 23.233 ms | 20.595 ms |
|     Json_Req_Six_ShortString |     json,six,req,shortstring | 1,283.91 ms | 15.817 ms | 14.795 ms |
|  Media_Req_Seven_ShortString |  media,seven,req,shortstring | 5,449.51 ms |  9.016 ms |  7.992 ms |
|   Json_Req_Seven_ShortString |   json,seven,req,shortstring | 1,288.51 ms | 19.108 ms | 17.874 ms |
|  Media_Req_Eight_ShortString |  media,eight,req,shortstring | 5,960.90 ms | 34.140 ms | 30.264 ms |
|   Json_Req_Eight_ShortString |   json,eight,req,shortstring | 1,287.21 ms | 18.112 ms | 16.942 ms |
|     Media_Op_One_ShortString |     media,one,op,shortstring |   397.69 ms |  2.288 ms |  1.911 ms |
|      Json_Op_One_ShortString |      json,one,op,shortstring |   170.46 ms |  0.704 ms |  0.550 ms |
|     Media_Op_Two_ShortString |     media,two,op,shortstring |   796.30 ms | 14.451 ms | 13.517 ms |
|      Json_Op_Two_ShortString |      json,two,op,shortstring | 4,106.29 ms | 25.568 ms | 23.916 ms |
|   Media_Op_Three_ShortString |   media,three,op,shortstring | 1,197.46 ms | 12.685 ms | 11.865 ms |
|    Json_Op_Three_ShortString |    json,three,op,shortstring | 4,759.08 ms | 29.472 ms | 26.126 ms |
|    Media_Op_Four_ShortString |    media,four,op,shortstring | 1,576.58 ms | 20.381 ms | 18.067 ms |
|     Json_Op_Four_ShortString |     json,four,op,shortstring | 4,758.49 ms | 24.450 ms | 21.674 ms |
|    Media_Op_Five_ShortString |    media,five,op,shortstring | 1,973.91 ms | 19.018 ms | 16.859 ms |
|     Json_Op_Five_ShortString |     json,five,op,shortstring | 4,782.00 ms | 12.091 ms | 10.719 ms |
|     Media_Op_Six_ShortString |     media,six,op,shortstring | 2,356.98 ms | 34.185 ms | 31.976 ms |
|      Json_Op_Six_ShortString |      json,six,op,shortstring | 4,783.61 ms | 19.404 ms | 17.201 ms |
|   Media_Op_Seven_ShortString |   media,seven,op,shortstring | 2,739.50 ms | 27.625 ms | 25.840 ms |
|    Json_Op_Seven_ShortString |    json,seven,op,shortstring | 4,770.88 ms | 31.735 ms | 26.500 ms |
|   Media_Op_Eight_ShortString |   media,eight,op,shortstring | 3,140.70 ms | 36.274 ms | 33.930 ms |
|    Json_Op_Eight_ShortString |    json,eight,op,shortstring | 4,775.82 ms | 36.509 ms | 28.504 ms |
|   Media_Both_Two_ShortString |   media,two,both,shortstring | 1,197.33 ms | 16.348 ms | 14.492 ms |
|    Json_Both_Two_ShortString |    json,two,both,shortstring |   874.19 ms | 16.871 ms | 20.083 ms |
|  Media_Both_Four_ShortString |  media,four,both,shortstring | 2,416.62 ms | 33.188 ms | 31.044 ms |
|   Json_Both_Four_ShortString |   json,four,both,shortstring | 1,298.13 ms | 23.281 ms | 21.777 ms |
|   Media_Both_Six_ShortString |   media,six,both,shortstring | 3,599.08 ms | 30.492 ms | 27.030 ms |
|    Json_Both_Six_ShortString |    json,six,both,shortstring | 1,291.01 ms | 23.548 ms | 22.027 ms |
| Media_Both_Eight_ShortString | media,eight,both,shortstring | 4,711.53 ms | 14.270 ms | 12.650 ms |
|  Json_Both_Eight_ShortString |  json,eight,both,shortstring | 1,292.35 ms | 24.618 ms | 24.179 ms |
|    Media_Req_One_ShortString |    media,one,req,shortstring |   795.91 ms | 11.162 ms |  9.895 ms |
|     Json_Req_One_ShortString |     json,one,req,shortstring |    25.97 ms |  0.512 ms |  0.937 ms |
|    Media_Req_Two_ShortString |    media,two,req,shortstring | 1,611.80 ms | 28.309 ms | 26.480 ms |
|     Json_Req_Two_ShortString |     json,two,req,shortstring |   372.84 ms |  4.945 ms |  4.383 ms |
|  Media_Req_Three_ShortString |  media,three,req,shortstring | 2,409.65 ms | 33.803 ms | 31.620 ms |
