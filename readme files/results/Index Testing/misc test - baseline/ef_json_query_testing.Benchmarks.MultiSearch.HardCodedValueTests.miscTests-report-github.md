``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.301
  [Host]     : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT
  DefaultJob : .NET 6.0.6 (6.0.622.26707), X64 RyuJIT


```
|                                      Method |                                    Categories |         Mean |      Error |     StdDev |       Median |
|-------------------------------------------- |---------------------------------------------- |-------------:|-----------:|-----------:|-------------:|
|       Indexed_NoColumns_first_both_bool_int |       Indexed,NoColumns,6fields,both,bool,int |     4.528 ms |  0.0893 ms |  0.1222 ms |     4.534 ms |
|        Indexed_NoColumns_first_req_bool_int |        Indexed,NoColumns,7fields,req,bool,int |     7.459 ms |  0.1482 ms |  0.3634 ms |     7.473 ms |
|              Indexed_NoColumns_first_op_int |              Indexed,NoColumns,4fields,op,int |     3.892 ms |  0.0777 ms |  0.1801 ms |     3.862 ms |
|          Indexed_NoColumns_first_req_string |          Indexed,NoColumns,4fields,req,string | 1,474.581 ms |  9.4380 ms |  8.3665 ms | 1,471.705 ms |
|           Indexed_NoColumns_first_op_string |           Indexed,NoColumns,3fields,op,string | 2,553.836 ms | 16.9128 ms | 14.9928 ms | 2,546.583 ms |
|    Indexed_NoColumns_first_op_string_single |           Indexed,NoColumns,1fields,op,string | 2,548.622 ms | 13.0405 ms | 11.5601 ms | 2,549.977 ms |
|   Indexed_NoColumns_first_req_string_single |          Indexed,NoColumns,1fields,req,string | 1,417.212 ms |  9.8963 ms |  9.2570 ms | 1,413.778 ms |
|  Indexed_NoColumns_first_both_date_int_bool |  Indexed,NoColumns,9fields,both,bool,int,date |    14.829 ms |  0.2954 ms |  0.3841 ms |    14.773 ms |
|           Indexed_NoColumns_set1_req_string |          Indexed,NoColumns,2fields,req,string |   417.356 ms |  4.4748 ms |  3.9668 ms |   415.174 ms |
|     Indexed_NoColumns_set1_op_string_single |           Indexed,NoColumns,1fields,op,string | 2,616.046 ms | 51.3737 ms | 88.6171 ms | 2,576.349 ms |
|    Indexed_NoColumns_set1_req_string_single |          Indexed,NoColumns,1fields,req,string | 1,412.808 ms | 10.7199 ms | 10.0274 ms | 1,407.777 ms |
|           Indexed_NoColumns_set2_req_string |          Indexed,NoColumns,2fields,req,string |   413.727 ms |  3.1193 ms |  2.6047 ms |   414.537 ms |
|    Indexed_NoColumns_set2_req_string_single |          Indexed,NoColumns,1fields,req,string | 1,388.766 ms |  9.5842 ms |  8.9650 ms | 1,385.774 ms |
|             Indexed_NoColumns_set1_req_date |            Indexed,NoColumns,3fields,req,date |    13.227 ms |  0.2624 ms |  0.2694 ms |    13.179 ms |
|              Indexed_NoColumns_set1_op_date |             Indexed,NoColumns,2fields,op,date |    38.536 ms |  0.6489 ms |  0.6070 ms |    38.528 ms |
|            Indexed_NoColumns_set1_both_date |           Indexed,NoColumns,5fields,both,date |   157.390 ms |  3.0270 ms |  2.6833 ms |   156.530 ms |
|      Indexed_AllColumns_first_both_bool_int |      Indexed,AllColumns,6fields,both,bool,int |     4.872 ms |  0.0958 ms |  0.1246 ms |     4.869 ms |
|       Indexed_AllColumns_first_req_bool_int |       Indexed,AllColumns,7fields,req,bool,int |     7.782 ms |  0.1555 ms |  0.2882 ms |     7.800 ms |
|             Indexed_AllColumns_first_op_int |             Indexed,AllColumns,4fields,op,int |     4.298 ms |  0.0858 ms |  0.1310 ms |     4.296 ms |
|         Indexed_AllColumns_first_req_string |         Indexed,AllColumns,4fields,req,string | 1,494.821 ms | 10.4280 ms |  9.2442 ms | 1,493.988 ms |
|          Indexed_AllColumns_first_op_string |          Indexed,AllColumns,3fields,op,string | 2,562.838 ms | 18.1869 ms | 16.1222 ms | 2,564.213 ms |
|   Indexed_AllColumns_first_op_string_single |          Indexed,AllColumns,1fields,op,string | 2,542.060 ms | 19.5057 ms | 17.2913 ms | 2,542.687 ms |
|  Indexed_AllColumns_first_req_string_single |         Indexed,AllColumns,1fields,req,string | 1,413.885 ms |  8.9422 ms |  8.3646 ms | 1,410.010 ms |
| Indexed_AllColumns_first_both_date_int_bool | Indexed,AllColumns,9fields,both,bool,int,date |    15.567 ms |  0.3093 ms |  0.5168 ms |    15.596 ms |
|          Indexed_AllColumns_set1_req_string |         Indexed,AllColumns,2fields,req,string |   424.256 ms |  3.7496 ms |  3.3240 ms |   423.184 ms |
|    Indexed_AllColumns_set1_op_string_single |          Indexed,AllColumns,1fields,op,string | 2,548.902 ms |  6.4609 ms |  6.0436 ms | 2,547.741 ms |
|   Indexed_AllColumns_set1_req_string_single |         Indexed,AllColumns,1fields,req,string | 1,413.768 ms | 12.7380 ms | 10.6368 ms | 1,415.672 ms |
|          Indexed_AllColumns_set2_req_string |         Indexed,AllColumns,2fields,req,string |   416.348 ms |  2.3960 ms |  2.0008 ms |   415.732 ms |
|   Indexed_AllColumns_set2_req_string_single |         Indexed,AllColumns,1fields,req,string | 1,388.980 ms | 16.2322 ms | 14.3895 ms | 1,385.625 ms |
|            Indexed_AllColumns_set1_req_date |           Indexed,AllColumns,3fields,req,date |    20.919 ms |  0.5313 ms |  1.4984 ms |    20.241 ms |
|             Indexed_AllColumns_set1_op_date |            Indexed,AllColumns,2fields,op,date |    44.317 ms |  0.8734 ms |  1.3337 ms |    43.939 ms |
|           Indexed_AllColumns_set1_both_date |          Indexed,AllColumns,5fields,both,date |   160.022 ms |  1.1898 ms |  0.9936 ms |   159.584 ms |
