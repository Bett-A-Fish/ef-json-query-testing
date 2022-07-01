``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                        Method |                    Categories |    Mean |    Error |   StdDev |
|------------------------------ |------------------------------ |--------:|---------:|---------:|
|  Media_Req_Fourteen_CharCount |  media,fourteen,req,charcount | 3.318 s | 0.0120 s | 0.0100 s |
|   Json_Req_Fourteen_CharCount |   json,fourteen,req,charcount | 1.237 s | 0.0050 s | 0.0047 s |
|   Media_Req_Sixteen_CharCount |   media,sixteen,req,charcount | 3.306 s | 0.0188 s | 0.0167 s |
|    Json_Req_Sixteen_CharCount |    json,sixteen,req,charcount | 1.230 s | 0.0044 s | 0.0037 s |
|       Media_Op_Four_CharCount |       media,four,op,charcount | 1.522 s | 0.0076 s | 0.0064 s |
|        Json_Op_Four_CharCount |        json,four,op,charcount | 4.862 s | 0.0494 s | 0.0462 s |
|        Media_Op_Six_CharCount |        media,six,op,charcount | 1.523 s | 0.0054 s | 0.0047 s |
|         Json_Op_Six_CharCount |         json,six,op,charcount | 4.733 s | 0.0245 s | 0.0217 s |
|      Media_Op_Eight_CharCount |      media,eight,op,charcount | 1.591 s | 0.0067 s | 0.0059 s |
|       Json_Op_Eight_CharCount |       json,eight,op,charcount | 4.724 s | 0.0313 s | 0.0245 s |
|        Media_Op_Ten_CharCount |        media,Ten,op,charcount | 1.605 s | 0.0099 s | 0.0088 s |
|         Json_Op_Ten_CharCount |         json,Ten,op,charcount | 4.749 s | 0.0571 s | 0.0507 s |
|     Media_Op_Twelve_CharCount |     media,twelve,op,charcount | 1.680 s | 0.0067 s | 0.0063 s |
|      Json_Op_Twelve_CharCount |      json,twelve,op,charcount | 4.617 s | 0.0113 s | 0.0095 s |
|   Media_Op_Fourteen_CharCount |   media,fourteen,op,charcount | 1.658 s | 0.0044 s | 0.0034 s |
|    Json_Op_Fourteen_CharCount |    json,fourteen,op,charcount | 4.750 s | 0.0137 s | 0.0122 s |
|    Media_Op_Sixteen_CharCount |    media,sixteen,op,charcount | 1.670 s | 0.0100 s | 0.0089 s |
|     Json_Op_Sixteen_CharCount |     json,sixteen,op,charcount | 4.602 s | 0.0181 s | 0.0160 s |
|     Media_Both_Four_CharCount |     media,four,both,charcount | 2.233 s | 0.0138 s | 0.0122 s |
|      Json_Both_Four_CharCount |      json,four,both,charcount | 1.451 s | 0.0068 s | 0.0057 s |
|      Media_Both_Six_CharCount |      media,six,both,charcount | 2.324 s | 0.0325 s | 0.0304 s |
|       Json_Both_Six_CharCount |       json,six,both,charcount | 1.273 s | 0.0093 s | 0.0087 s |
|    Media_Both_Eight_CharCount |    media,eight,both,charcount | 2.379 s | 0.0141 s | 0.0125 s |
|     Json_Both_Eight_CharCount |     json,eight,both,charcount | 1.295 s | 0.0076 s | 0.0067 s |
|      Media_Both_Ten_CharCount |      media,Ten,both,charcount | 2.302 s | 0.0100 s | 0.0088 s |
|       Json_Both_Ten_CharCount |       json,Ten,both,charcount | 1.289 s | 0.0052 s | 0.0046 s |
|   Media_Both_Twelve_CharCount |   media,twelve,both,charcount | 2.501 s | 0.0056 s | 0.0050 s |
|    Json_Both_Twelve_CharCount |    json,twelve,both,charcount | 1.244 s | 0.0048 s | 0.0040 s |
| Media_Both_Fourteen_CharCount | media,fourteen,both,charcount | 2.498 s | 0.0089 s | 0.0084 s |
|  Json_Both_Fourteen_CharCount |  json,fourteen,both,charcount | 1.239 s | 0.0044 s | 0.0039 s |
|  Media_Both_Sixteen_CharCount |  media,sixteen,both,charcount | 2.495 s | 0.0172 s | 0.0161 s |
|   Json_Both_Sixteen_CharCount |   json,sixteen,both,charcount | 1.232 s | 0.0039 s | 0.0036 s |
|      Media_Req_Four_CharCount |      media,four,req,charcount | 2.920 s | 0.0096 s | 0.0080 s |
|       Json_Req_Four_CharCount |       json,four,req,charcount | 1.371 s | 0.0062 s | 0.0058 s |
|       Media_Req_Six_CharCount |       media,six,req,charcount | 2.860 s | 0.0100 s | 0.0089 s |
|        Json_Req_Six_CharCount |        json,six,req,charcount | 1.257 s | 0.0053 s | 0.0044 s |
|     Media_Req_Eight_CharCount |     media,eight,req,charcount | 3.192 s | 0.0135 s | 0.0120 s |
|      Json_Req_Eight_CharCount |      json,eight,req,charcount | 1.280 s | 0.0097 s | 0.0086 s |
|       Media_Req_Ten_CharCount |       media,Ten,req,charcount | 3.067 s | 0.0271 s | 0.0240 s |
|        Json_Req_Ten_CharCount |        json,Ten,req,charcount | 1.261 s | 0.0104 s | 0.0092 s |
|    Media_Req_Twelve_CharCount |    media,twelve,req,charcount | 3.347 s | 0.0121 s | 0.0107 s |
|     Json_Req_Twelve_CharCount |     json,twelve,req,charcount | 1.240 s | 0.0078 s | 0.0065 s |
