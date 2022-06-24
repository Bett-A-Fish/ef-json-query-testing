``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1766 (21H1/May2021Update)
AMD Ryzen 7 1700, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                                      Method |                                    Categories |          Mean |       Error |        StdDev |
|-------------------------------------------- |---------------------------------------------- |--------------:|------------:|--------------:|
|        Media_AllColumns_first_both_bool_int |        media,AllColumns,6fields,both,bool,int |    148.814 ms |   2.9436 ms |     6.9957 ms |
|         Media_AllColumns_first_req_bool_int |         media,AllColumns,7fields,req,bool,int |    245.941 ms |   1.7869 ms |     1.3951 ms |
|               Media_AllColumns_first_op_int |               media,AllColumns,4fields,op,int |     89.801 ms |   1.1519 ms |     1.0775 ms |
|           Media_AllColumns_first_req_string |           media,AllColumns,4fields,req,string |  3,155.219 ms |  20.9669 ms |    19.6125 ms |
|            Media_AllColumns_first_op_string |            media,AllColumns,3fields,op,string |    496.201 ms |   3.8217 ms |     3.1913 ms |
|     Media_AllColumns_first_op_string_single |            media,AllColumns,1fields,op,string |     79.940 ms |   1.9346 ms |     5.7041 ms |
|    Media_AllColumns_first_req_string_single |           media,AllColumns,1fields,req,string |    147.169 ms |   2.9191 ms |     6.7654 ms |
|   Media_AllColumns_first_both_date_int_bool |   media,AllColumns,9fields,both,bool,int,date |    406.474 ms |   2.3620 ms |     1.8441 ms |
|            Media_AllColumns_set1_req_string |           media,AllColumns,2fields,req,string |    176.242 ms |   3.4962 ms |     5.8414 ms |
|      Media_AllColumns_set1_op_string_single |            media,AllColumns,1fields,op,string | 20,426.783 ms | 638.3855 ms | 1,681.7626 ms |
|     Media_AllColumns_set1_req_string_single |           media,AllColumns,1fields,req,string | 29,367.726 ms | 569.3915 ms |   869.5209 ms |
|            Media_AllColumns_set2_req_string |           media,AllColumns,2fields,req,string |    177.236 ms |   3.3307 ms |     4.3309 ms |
|     Media_AllColumns_set2_req_string_single |           media,AllColumns,1fields,req,string |    257.833 ms |   3.8270 ms |     5.8443 ms |
|              Media_AllColumns_set1_req_date |             media,AllColumns,3fields,req,date |    376.160 ms |   3.6411 ms |     3.0405 ms |
|               Media_AllColumns_set1_op_date |              media,AllColumns,2fields,op,date |    143.674 ms |   1.6622 ms |     1.4735 ms |
|             Media_AllColumns_set1_both_date |            media,AllColumns,5fields,both,date |    499.730 ms |   6.8936 ms |     5.7565 ms |
|         Media_NoColumns_first_both_bool_int |         media,NoColumns,6fields,both,bool,int |    137.736 ms |   1.7443 ms |     1.5463 ms |
|          Media_NoColumns_first_req_bool_int |          media,NoColumns,7fields,req,bool,int |    226.766 ms |   2.4157 ms |     2.1415 ms |
|                Media_NoColumns_first_op_int |                media,NoColumns,4fields,op,int |     90.938 ms |   1.4189 ms |     1.2578 ms |
|            Media_NoColumns_first_req_string |            media,NoColumns,4fields,req,string |  3,184.654 ms |  60.3905 ms |    56.4893 ms |
|             Media_NoColumns_first_op_string |             media,NoColumns,3fields,op,string |    494.814 ms |   9.5839 ms |     9.8420 ms |
|      Media_NoColumns_first_op_string_single |             media,NoColumns,1fields,op,string |    415.320 ms |   6.4889 ms |     5.7522 ms |
|     Media_NoColumns_first_req_string_single |            media,NoColumns,1fields,req,string |    851.483 ms |  14.8172 ms |    13.8600 ms |
|    Media_NoColumns_first_both_date_int_bool |    media,NoColumns,9fields,both,bool,int,date |    404.453 ms |   4.1403 ms |     3.4573 ms |
|             Media_NoColumns_set1_req_string |            media,NoColumns,2fields,req,string |  1,569.290 ms |  25.3611 ms |    23.7227 ms |
|       Media_NoColumns_set1_op_string_single |             media,NoColumns,1fields,op,string |    437.780 ms |   8.5108 ms |     7.1069 ms |
|      Media_NoColumns_set1_req_string_single |            media,NoColumns,1fields,req,string |    865.013 ms |   9.8744 ms |     8.7534 ms |
|             Media_NoColumns_set2_req_string |            media,NoColumns,2fields,req,string |  1,582.771 ms |  29.5328 ms |    27.6250 ms |
|      Media_NoColumns_set2_req_string_single |            media,NoColumns,1fields,req,string |    839.025 ms |   3.2153 ms |     2.5103 ms |
|               Media_NoColumns_set1_req_date |              media,NoColumns,3fields,req,date |    352.554 ms |   6.6846 ms |     5.9258 ms |
|                Media_NoColumns_set1_op_date |               media,NoColumns,2fields,op,date |    118.228 ms |   2.2492 ms |     2.3097 ms |
|              Media_NoColumns_set1_both_date |             media,NoColumns,5fields,both,date |    464.646 ms |   5.6165 ms |     4.6900 ms |
|       Indexed_NoColumns_first_both_bool_int |       Indexed,NoColumns,6fields,both,bool,int |      4.225 ms |   0.0903 ms |     0.2621 ms |
|        Indexed_NoColumns_first_req_bool_int |        Indexed,NoColumns,7fields,req,bool,int |      7.471 ms |   0.1444 ms |     0.2333 ms |
|              Indexed_NoColumns_first_op_int |              Indexed,NoColumns,4fields,op,int |      3.967 ms |   0.0771 ms |     0.2174 ms |
|          Indexed_NoColumns_first_req_string |          Indexed,NoColumns,4fields,req,string |  1,502.366 ms |  19.4950 ms |    18.2357 ms |
|           Indexed_NoColumns_first_op_string |           Indexed,NoColumns,3fields,op,string |  2,589.288 ms |  36.7829 ms |    32.6071 ms |
|    Indexed_NoColumns_first_op_string_single |           Indexed,NoColumns,1fields,op,string |  2,576.569 ms |  30.3320 ms |    28.3726 ms |
|   Indexed_NoColumns_first_req_string_single |          Indexed,NoColumns,1fields,req,string |  1,430.889 ms |  22.8104 ms |    21.3369 ms |
|  Indexed_NoColumns_first_both_date_int_bool |  Indexed,NoColumns,9fields,both,bool,int,date |     14.679 ms |   0.2885 ms |     0.4491 ms |
|           Indexed_NoColumns_set1_req_string |          Indexed,NoColumns,2fields,req,string |    426.467 ms |   5.0285 ms |     4.4576 ms |
|     Indexed_NoColumns_set1_op_string_single |           Indexed,NoColumns,1fields,op,string |  2,577.872 ms |  41.3992 ms |    38.7249 ms |
|    Indexed_NoColumns_set1_req_string_single |          Indexed,NoColumns,1fields,req,string |  1,429.871 ms |  27.8590 ms |    27.3612 ms |
|           Indexed_NoColumns_set2_req_string |          Indexed,NoColumns,2fields,req,string |    415.466 ms |   3.1280 ms |     2.4421 ms |
|    Indexed_NoColumns_set2_req_string_single |          Indexed,NoColumns,1fields,req,string |  1,437.138 ms |  28.1644 ms |    35.6189 ms |
|             Indexed_NoColumns_set1_req_date |            Indexed,NoColumns,3fields,req,date |     13.153 ms |   0.2595 ms |     0.4264 ms |
|              Indexed_NoColumns_set1_op_date |             Indexed,NoColumns,2fields,op,date |     37.716 ms |   0.7233 ms |     0.9147 ms |
|            Indexed_NoColumns_set1_both_date |           Indexed,NoColumns,5fields,both,date |    157.691 ms |   2.4201 ms |     2.5894 ms |
|      Indexed_AllColumns_first_both_bool_int |      Indexed,AllColumns,6fields,both,bool,int |      4.690 ms |   0.0932 ms |     0.2105 ms |
|       Indexed_AllColumns_first_req_bool_int |       Indexed,AllColumns,7fields,req,bool,int |      7.787 ms |   0.1552 ms |     0.3099 ms |
|             Indexed_AllColumns_first_op_int |             Indexed,AllColumns,4fields,op,int |      4.490 ms |   0.0890 ms |     0.1972 ms |
|         Indexed_AllColumns_first_req_string |         Indexed,AllColumns,4fields,req,string |  1,493.405 ms |  26.6591 ms |    24.9369 ms |
|          Indexed_AllColumns_first_op_string |          Indexed,AllColumns,3fields,op,string |  2,582.371 ms |  24.8774 ms |    40.8742 ms |
|   Indexed_AllColumns_first_op_string_single |          Indexed,AllColumns,1fields,op,string |  2,575.057 ms |  30.5268 ms |    28.5548 ms |
|  Indexed_AllColumns_first_req_string_single |         Indexed,AllColumns,1fields,req,string |  1,425.125 ms |  19.6534 ms |    17.4222 ms |
| Indexed_AllColumns_first_both_date_int_bool | Indexed,AllColumns,9fields,both,bool,int,date |     15.903 ms |   0.3170 ms |     0.5635 ms |
|          Indexed_AllColumns_set1_req_string |         Indexed,AllColumns,2fields,req,string |    435.616 ms |   7.1531 ms |     7.6537 ms |
|    Indexed_AllColumns_set1_op_string_single |          Indexed,AllColumns,1fields,op,string |  2,579.879 ms |  35.7905 ms |    33.4785 ms |
|   Indexed_AllColumns_set1_req_string_single |         Indexed,AllColumns,1fields,req,string |  1,427.661 ms |  21.8529 ms |    20.4412 ms |
|          Indexed_AllColumns_set2_req_string |         Indexed,AllColumns,2fields,req,string |    421.996 ms |   7.5779 ms |     8.4228 ms |
|   Indexed_AllColumns_set2_req_string_single |         Indexed,AllColumns,1fields,req,string |  1,404.208 ms |  21.5036 ms |    20.1145 ms |
|            Indexed_AllColumns_set1_req_date |           Indexed,AllColumns,3fields,req,date |     23.174 ms |   0.3524 ms |     0.3297 ms |
|             Indexed_AllColumns_set1_op_date |            Indexed,AllColumns,2fields,op,date |     44.041 ms |   0.7307 ms |     0.6835 ms |
|           Indexed_AllColumns_set1_both_date |          Indexed,AllColumns,5fields,both,date |    161.734 ms |   2.9968 ms |     2.8032 ms |
