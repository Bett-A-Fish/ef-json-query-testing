``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                      Method |                  Categories |        Mean |     Error |    StdDev |
|---------------------------- |---------------------------- |------------:|----------:|----------:|
|    Media_Req_One_LongString |    media,one,req,longstring |   788.18 ms | 15.049 ms | 16.103 ms |
|     Json_Req_One_LongString |     json,one,req,longstring |    18.44 ms |  0.362 ms |  0.321 ms |
|    Media_Req_Two_LongString |    media,two,req,longstring | 1,495.01 ms | 23.979 ms | 22.430 ms |
|     Json_Req_Two_LongString |     json,two,req,longstring |   136.84 ms |  2.538 ms |  2.493 ms |
|  Media_Req_Three_LongString |  media,three,req,longstring | 2,302.09 ms | 25.007 ms | 23.391 ms |
|   Json_Req_Three_LongString |   json,three,req,longstring | 1,278.47 ms | 25.405 ms | 23.763 ms |
|   Media_Req_Four_LongString |   media,four,req,longstring | 3,103.40 ms | 37.123 ms | 34.725 ms |
|    Json_Req_Four_LongString |    json,four,req,longstring | 1,274.08 ms | 20.551 ms | 18.218 ms |
|   Media_Req_Five_LongString |   media,five,req,longstring | 3,883.20 ms | 32.367 ms | 30.276 ms |
|    Json_Req_Five_LongString |    json,five,req,longstring | 1,275.26 ms | 21.957 ms | 20.539 ms |
|    Media_Req_Six_LongString |    media,six,req,longstring | 4,653.89 ms | 28.036 ms | 26.225 ms |
|     Json_Req_Six_LongString |     json,six,req,longstring | 1,272.18 ms | 24.518 ms | 22.934 ms |
|  Media_Req_Seven_LongString |  media,seven,req,longstring | 5,442.41 ms | 43.416 ms | 40.612 ms |
|   Json_Req_Seven_LongString |   json,seven,req,longstring | 1,275.43 ms | 16.021 ms | 14.986 ms |
|  Media_Req_Eight_LongString |  media,eight,req,longstring | 6,242.26 ms | 41.579 ms | 36.859 ms |
|   Json_Req_Eight_LongString |   json,eight,req,longstring | 1,277.02 ms | 17.944 ms | 16.785 ms |
|     Media_Op_One_LongString |     media,one,op,longstring |   392.53 ms |  1.947 ms |  1.520 ms |
|      Json_Op_One_LongString |      json,one,op,longstring |   161.56 ms |  3.141 ms |  3.491 ms |
|     Media_Op_Two_LongString |     media,two,op,longstring |   809.07 ms |  3.898 ms |  3.255 ms |
|      Json_Op_Two_LongString |      json,two,op,longstring | 4,019.64 ms | 22.178 ms | 19.660 ms |
|   Media_Op_Three_LongString |   media,three,op,longstring | 1,201.67 ms | 17.341 ms | 16.221 ms |
|    Json_Op_Three_LongString |    json,three,op,longstring | 4,742.92 ms | 39.189 ms | 36.658 ms |
|    Media_Op_Four_LongString |    media,four,op,longstring | 1,616.22 ms | 27.637 ms | 25.852 ms |
|     Json_Op_Four_LongString |     json,four,op,longstring | 4,750.89 ms | 20.153 ms | 17.865 ms |
|    Media_Op_Five_LongString |    media,five,op,longstring | 1,970.44 ms | 22.854 ms | 21.378 ms |
|     Json_Op_Five_LongString |     json,five,op,longstring | 4,755.03 ms | 15.314 ms | 12.788 ms |
|     Media_Op_Six_LongString |     media,six,op,longstring | 2,355.85 ms | 26.594 ms | 24.876 ms |
|      Json_Op_Six_LongString |      json,six,op,longstring | 4,749.01 ms | 20.478 ms | 19.155 ms |
|   Media_Op_Seven_LongString |   media,seven,op,longstring | 2,743.60 ms | 27.012 ms | 25.267 ms |
|    Json_Op_Seven_LongString |    json,seven,op,longstring | 4,743.81 ms | 16.070 ms | 14.246 ms |
|   Media_Op_Eight_LongString |   media,eight,op,longstring | 3,135.41 ms | 26.533 ms | 24.819 ms |
|    Json_Op_Eight_LongString |    json,eight,op,longstring | 4,750.25 ms |  5.764 ms |  4.813 ms |
|   Media_Both_Two_LongString |   media,two,both,longstring | 1,197.04 ms | 15.627 ms | 13.853 ms |
|    Json_Both_Two_LongString |    json,two,both,longstring |   788.29 ms |  6.157 ms |  4.807 ms |
|  Media_Both_Four_LongString |  media,four,both,longstring | 2,331.39 ms | 26.729 ms | 25.002 ms |
|   Json_Both_Four_LongString |   json,four,both,longstring | 1,308.21 ms | 19.194 ms | 17.954 ms |
|   Media_Both_Six_LongString |   media,six,both,longstring | 3,501.39 ms | 23.495 ms | 20.827 ms |
|    Json_Both_Six_LongString |    json,six,both,longstring | 1,281.64 ms | 20.908 ms | 19.558 ms |
| Media_Both_Eight_LongString | media,eight,both,longstring | 4,673.59 ms |  9.580 ms |  8.000 ms |
|  Json_Both_Eight_LongString |  json,eight,both,longstring | 1,264.31 ms |  8.785 ms |  6.859 ms |
