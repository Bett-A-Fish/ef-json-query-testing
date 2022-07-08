using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_json_query_testing.Benchmarks.MultiSearch.HardCodedValueTests
{
    public class miscTests : BaseBenchmark
    {
        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "6fields", "both", "bool", "int")]
        public void Media_AllColumns_first_both_bool_int() => Search.TableSearch_Media(TestValueConstants.first_both_bool_int);


        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "7fields", "req", "bool", "int")]
        public void Media_AllColumns_first_req_bool_int() => Search.TableSearch_Media(TestValueConstants.first_req_bool_int);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "4fields", "op", "int")]
        public void Media_AllColumns_first_op_int() => Search.TableSearch_Media(TestValueConstants.first_op_int);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "4fields", "req", "string")]
        public void Media_AllColumns_first_req_string() => Search.TableSearch_Media(TestValueConstants.first_req_string);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "3fields", "op", "string")]
        public void Media_AllColumns_first_op_string() => Search.TableSearch_Media(TestValueConstants.first_op_string);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "1fields", "op", "string")]
        public void Media_AllColumns_first_op_string_single() => Search.TableSearch_Media(TestValueConstants.first_op_string_single);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "1fields", "req", "string")]
        public void Media_AllColumns_first_req_string_single() => Search.TableSearch_Media(TestValueConstants.first_req_string_single);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "9fields", "both", "bool", "int", "date")]
        public void Media_AllColumns_first_both_date_int_bool() => Search.TableSearch_Media(TestValueConstants.first_both_date_int_bool);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "2fields", "req", "string")]
        public void Media_AllColumns_set1_req_string() => Search.TableSearch_Media(TestValueConstants.set1_req_string);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "1fields", "op", "string")]
        public void Media_AllColumns_set1_op_string_single() => Search.TableSearch_Media(TestValueConstants.set1_op_string_single);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "1fields", "req", "string")]
        public void Media_AllColumns_set1_req_string_single() => Search.TableSearch_Media(TestValueConstants.set1_req_string_single);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "2fields", "req", "string")]
        public void Media_AllColumns_set2_req_string() => Search.TableSearch_Media(TestValueConstants.set2_req_string);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "1fields", "req", "string")]
        public void Media_AllColumns_set2_req_string_single() => Search.TableSearch_Media(TestValueConstants.set2_req_string_single);


        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "3fields", "req", "date")]
        public void Media_AllColumns_set1_req_date() => Search.TableSearch_Media(TestValueConstants.set1_req_date);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "2fields", "op", "date")]
        public void Media_AllColumns_set1_op_date() => Search.TableSearch_Media(TestValueConstants.set1_op_date);



        [Benchmark]
        [BenchmarkCategory("media", "AllColumns", "5fields", "both", "date")]
        public void Media_AllColumns_set1_both_date() => Search.TableSearch_Media(TestValueConstants.set1_both_date);






        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "6fields", "both", "bool", "int")]
        public void Media_NoColumns_first_both_bool_int() => Search.TableSearch_Media_NoColumns(TestValueConstants.first_both_bool_int);


        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "7fields", "req", "bool", "int")]
        public void Media_NoColumns_first_req_bool_int() => Search.TableSearch_Media_NoColumns(TestValueConstants.first_req_bool_int);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "4fields", "op", "int")]
        public void Media_NoColumns_first_op_int() => Search.TableSearch_Media_NoColumns(TestValueConstants.first_op_int);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "4fields", "req", "string")]
        public void Media_NoColumns_first_req_string() => Search.TableSearch_Media_NoColumns(TestValueConstants.first_req_string);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "3fields", "op", "string")]
        public void Media_NoColumns_first_op_string() => Search.TableSearch_Media_NoColumns(TestValueConstants.first_op_string);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "1fields", "op", "string")]
        public void Media_NoColumns_first_op_string_single() => Search.TableSearch_Media_NoColumns(TestValueConstants.first_op_string_single);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "1fields", "req", "string")]
        public void Media_NoColumns_first_req_string_single() => Search.TableSearch_Media_NoColumns(TestValueConstants.first_req_string_single);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "9fields", "both", "bool", "int", "date")]
        public void Media_NoColumns_first_both_date_int_bool() => Search.TableSearch_Media_NoColumns(TestValueConstants.first_both_date_int_bool);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "2fields", "req", "string")]
        public void Media_NoColumns_set1_req_string() => Search.TableSearch_Media_NoColumns(TestValueConstants.set1_req_string);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "1fields", "op", "string")]
        public void Media_NoColumns_set1_op_string_single() => Search.TableSearch_Media_NoColumns(TestValueConstants.set1_op_string_single);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "1fields", "req", "string")]
        public void Media_NoColumns_set1_req_string_single() => Search.TableSearch_Media_NoColumns(TestValueConstants.set1_req_string_single);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "2fields", "req", "string")]
        public void Media_NoColumns_set2_req_string() => Search.TableSearch_Media_NoColumns(TestValueConstants.set2_req_string);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "1fields", "req", "string")]
        public void Media_NoColumns_set2_req_string_single() => Search.TableSearch_Media_NoColumns(TestValueConstants.set2_req_string_single);


        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "3fields", "req", "date")]
        public void Media_NoColumns_set1_req_date() => Search.TableSearch_Media_NoColumns(TestValueConstants.set1_req_date);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "2fields", "op", "date")]
        public void Media_NoColumns_set1_op_date() => Search.TableSearch_Media_NoColumns(TestValueConstants.set1_op_date);



        [Benchmark]
        [BenchmarkCategory("media", "NoColumns", "5fields", "both", "date")]
        public void Media_NoColumns_set1_both_date() => Search.TableSearch_Media_NoColumns(TestValueConstants.set1_both_date);








        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "6fields", "both", "bool", "int")]
        public void Indexed_NoColumns_first_both_bool_int() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_both_bool_int);


        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "7fields", "req", "bool", "int")]
        public void Indexed_NoColumns_first_req_bool_int() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_req_bool_int);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "4fields", "op", "int")]
        public void Indexed_NoColumns_first_op_int() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_op_int);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "4fields", "req", "string")]
        public void Indexed_NoColumns_first_req_string() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_req_string);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "3fields", "op", "string")]
        public void Indexed_NoColumns_first_op_string() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_op_string);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "1fields", "op", "string")]
        public void Indexed_NoColumns_first_op_string_single() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_op_string_single);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "1fields", "req", "string")]
        public void Indexed_NoColumns_first_req_string_single() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_req_string_single);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "9fields", "both", "bool", "int", "date")]
        public void Indexed_NoColumns_first_both_date_int_bool() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_both_date_int_bool);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "2fields", "req", "string")]
        public void Indexed_NoColumns_set1_req_string() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set1_req_string);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "1fields", "op", "string")]
        public void Indexed_NoColumns_set1_op_string_single() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set1_op_string_single);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "1fields", "req", "string")]
        public void Indexed_NoColumns_set1_req_string_single() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set1_req_string_single);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "2fields", "req", "string")]
        public void Indexed_NoColumns_set2_req_string() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set2_req_string);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "1fields", "req", "string")]
        public void Indexed_NoColumns_set2_req_string_single() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set2_req_string_single);


        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "3fields", "req", "date")]
        public void Indexed_NoColumns_set1_req_date() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set1_req_date);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "2fields", "op", "date")]
        public void Indexed_NoColumns_set1_op_date() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set1_op_date);



        [Benchmark]
        [BenchmarkCategory("Indexed", "NoColumns", "5fields", "both", "date")]
        public void Indexed_NoColumns_set1_both_date() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set1_both_date);










        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "6fields", "both", "bool", "int")]
        public void Indexed_AllColumns_first_both_bool_int() => Search.JsonSearch_Indexed(TestValueConstants.first_both_bool_int);


        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "7fields", "req", "bool", "int")]
        public void Indexed_AllColumns_first_req_bool_int() => Search.JsonSearch_Indexed(TestValueConstants.first_req_bool_int);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "4fields", "op", "int")]
        public void Indexed_AllColumns_first_op_int() => Search.JsonSearch_Indexed(TestValueConstants.first_op_int);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "4fields", "req", "string")]
        public void Indexed_AllColumns_first_req_string() => Search.JsonSearch_Indexed(TestValueConstants.first_req_string);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "3fields", "op", "string")]
        public void Indexed_AllColumns_first_op_string() => Search.JsonSearch_Indexed(TestValueConstants.first_op_string);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "1fields", "op", "string")]
        public void Indexed_AllColumns_first_op_string_single() => Search.JsonSearch_Indexed(TestValueConstants.first_op_string_single);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "1fields", "req", "string")]
        public void Indexed_AllColumns_first_req_string_single() => Search.JsonSearch_Indexed(TestValueConstants.first_req_string_single);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "9fields", "both", "bool", "int", "date")]
        public void Indexed_AllColumns_first_both_date_int_bool() => Search.JsonSearch_Indexed(TestValueConstants.first_both_date_int_bool);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "2fields", "req", "string")]
        public void Indexed_AllColumns_set1_req_string() => Search.JsonSearch_Indexed(TestValueConstants.set1_req_string);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "1fields", "op", "string")]
        public void Indexed_AllColumns_set1_op_string_single() => Search.JsonSearch_Indexed(TestValueConstants.set1_op_string_single);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "1fields", "req", "string")]
        public void Indexed_AllColumns_set1_req_string_single() => Search.JsonSearch_Indexed(TestValueConstants.set1_req_string_single);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "2fields", "req", "string")]
        public void Indexed_AllColumns_set2_req_string() => Search.JsonSearch_Indexed(TestValueConstants.set2_req_string);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "1fields", "req", "string")]
        public void Indexed_AllColumns_set2_req_string_single() => Search.JsonSearch_Indexed(TestValueConstants.set2_req_string_single);


        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "3fields", "req", "date")]
        public void Indexed_AllColumns_set1_req_date() => Search.JsonSearch_Indexed(TestValueConstants.set1_req_date);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "2fields", "op", "date")]
        public void Indexed_AllColumns_set1_op_date() => Search.JsonSearch_Indexed(TestValueConstants.set1_op_date);



        [Benchmark]
        [BenchmarkCategory("Indexed", "AllColumns", "5fields", "both", "date")]
        public void Indexed_AllColumns_set1_both_date() => Search.JsonSearch_Indexed(TestValueConstants.set1_both_date);


    }
}
