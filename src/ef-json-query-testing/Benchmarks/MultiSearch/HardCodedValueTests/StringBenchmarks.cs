using BenchmarkDotNet.Attributes;

namespace ef_json_query_testing.Benchmarks.MultiSearch.HardCodedValueTests
{
    public class StringBenchmarks : BaseBenchmark
    {
        [Benchmark]
        [BenchmarkCategory("media", "one", "req")]
        public void Media_Req_One() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.One_Required);

        [Benchmark]
        [BenchmarkCategory("json", "one", "req")]
        public void Json_Req_One() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.One_Required);



        [Benchmark]
        [BenchmarkCategory("media", "two", "req")]
        public void Media_Req_Two() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Two_Required);

        [Benchmark]
        [BenchmarkCategory("json", "two", "req")]
        public void Json_Req_Two() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Two_Required);



        [Benchmark]
        [BenchmarkCategory("media", "three", "req")]
        public void Media_Req_Three() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Three_Required);

        [Benchmark]
        [BenchmarkCategory("json", "three", "req")]
        public void Json_Req_Three() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Three_Required);



        [Benchmark]
        [BenchmarkCategory("media", "four", "req")]
        public void Media_Req_Four() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Four_Required);

        [Benchmark]
        [BenchmarkCategory("json", "four", "req")]
        public void Json_Req_Four() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Four_Required);




        [Benchmark]
        [BenchmarkCategory("media", "five", "req")]
        public void Media_Req_Five() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Five_Required);

        [Benchmark]
        [BenchmarkCategory("json", "five", "req")]
        public void Json_Req_Five() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Five_Required);



        [Benchmark]
        [BenchmarkCategory("media", "six", "req")]
        public void Media_Req_Six() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Six_Required);

        [Benchmark]
        [BenchmarkCategory("json", "six", "req")]
        public void Json_Req_Six() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Six_Required);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "req")]
        public void Media_Req_Seven() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Seven_Required);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "req")]
        public void Json_Req_Seven() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Seven_Required);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "req")]
        public void Media_Req_Eight() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Eight_Required);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "req")]
        public void Json_Req_Eight() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Eight_Required);








        [Benchmark]
        [BenchmarkCategory("media", "one", "op")]
        public void Media_Op_One() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.One_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "one", "op")]
        public void Json_Op_One() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.One_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "two", "op")]
        public void Media_Op_Two() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Two_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "two", "op")]
        public void Json_Op_Two() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Two_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "three", "op")]
        public void Media_Op_Three() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Three_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "three", "op")]
        public void Json_Op_Three() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Three_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "four", "op")]
        public void Media_Op_Four() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Four_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "four", "op")]
        public void Json_Op_Four() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Four_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "five", "op")]
        public void Media_Op_Five() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Five_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "five", "op")]
        public void Json_Op_Five() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Five_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "six", "op")]
        public void Media_Op_Six() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Six_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "six", "op")]
        public void Json_Op_Six() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Six_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "op")]
        public void Media_Op_Seven() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Seven_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "op")]
        public void Json_Op_Seven() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Seven_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "op")]
        public void Media_Op_Eight() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Eight_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "op")]
        public void Json_Op_Eight() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Eight_Optional);








        [Benchmark]
        [BenchmarkCategory("media", "two", "both")]
        public void Media_Both_Two() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Two_Both);

        [Benchmark]
        [BenchmarkCategory("json", "two", "both")]
        public void Json_Both_Two() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Two_Both);





        [Benchmark]
        [BenchmarkCategory("media", "four", "both")]
        public void Media_Both_Four() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Four_Both);

        [Benchmark]
        [BenchmarkCategory("json", "four", "both")]
        public void Json_Both_Four() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Four_Both);




        [Benchmark]
        [BenchmarkCategory("media", "six", "both")]
        public void Media_Both_Six() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Six_Both);

        [Benchmark]
        [BenchmarkCategory("json", "six", "both")]
        public void Json_Both_Six() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Six_Both);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "both")]
        public void Media_Both_Eight() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Eight_Both);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "both")]
        public void Json_Both_Eight() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Eight_Both);











        [Benchmark]
        [BenchmarkCategory("media", "one", "req", "buildupon")]
        public void Media_Req_One_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.One_Required);

        [Benchmark]
        [BenchmarkCategory("json", "one", "req", "buildupon")]
        public void Json_Req_One_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.One_Required);



        [Benchmark]
        [BenchmarkCategory("media", "two", "req", "buildupon")]
        public void Media_Req_Two_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Two_Required);

        [Benchmark]
        [BenchmarkCategory("json", "two", "req", "buildupon")]
        public void Json_Req_Two_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Two_Required);



        [Benchmark]
        [BenchmarkCategory("media", "three", "req", "buildupon")]
        public void Media_Req_Three_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Three_Required);

        [Benchmark]
        [BenchmarkCategory("json", "three", "req", "buildupon")]
        public void Json_Req_Three_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Three_Required);



        [Benchmark]
        [BenchmarkCategory("media", "four", "req", "buildupon")]
        public void Media_Req_Four_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Four_Required);

        [Benchmark]
        [BenchmarkCategory("json", "four", "req", "buildupon")]
        public void Json_Req_Four_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Four_Required);




        [Benchmark]
        [BenchmarkCategory("media", "five", "req", "buildupon")]
        public void Media_Req_Five_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Five_Required);

        [Benchmark]
        [BenchmarkCategory("json", "five", "req", "buildupon")]
        public void Json_Req_Five_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Five_Required);



        [Benchmark]
        [BenchmarkCategory("media", "six", "req", "buildupon")]
        public void Media_Req_Six_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Six_Required);

        [Benchmark]
        [BenchmarkCategory("json", "six", "req", "buildupon")]
        public void Json_Req_Six_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Six_Required);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "req", "buildupon")]
        public void Media_Req_Seven_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Seven_Required);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "req", "buildupon")]
        public void Json_Req_Seven_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Seven_Required);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "req", "buildupon")]
        public void Media_Req_Eight_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Eight_Required);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "req", "buildupon")]
        public void Json_Req_Eight_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Eight_Required);








        [Benchmark]
        [BenchmarkCategory("media", "one", "op", "buildupon")]
        public void Media_Op_One_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.One_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "one", "op", "buildupon")]
        public void Json_Op_One_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.One_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "two", "op", "buildupon")]
        public void Media_Op_Two_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Two_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "two", "op", "buildupon")]
        public void Json_Op_Two_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Two_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "three", "op", "buildupon")]
        public void Media_Op_Three_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Three_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "three", "op", "buildupon")]
        public void Json_Op_Three_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Three_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "four", "op", "buildupon")]
        public void Media_Op_Four_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Four_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "four", "op", "buildupon")]
        public void Json_Op_Four_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Four_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "five", "op", "buildupon")]
        public void Media_Op_Five_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Five_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "five", "op", "buildupon")]
        public void Json_Op_Five_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Five_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "six", "op", "buildupon")]
        public void Media_Op_Six_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Six_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "six", "op", "buildupon")]
        public void Json_Op_Six_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Six_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "op", "buildupon")]
        public void Media_Op_Seven_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Seven_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "op", "buildupon")]
        public void Json_Op_Seven_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Seven_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "op", "buildupon")]
        public void Media_Op_Eight_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Eight_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "op", "buildupon")]
        public void Json_Op_Eight_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Eight_Optional);








        [Benchmark]
        [BenchmarkCategory("media", "two", "both", "buildupon")]
        public void Media_Both_Two_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Two_Both);

        [Benchmark]
        [BenchmarkCategory("json", "two", "both", "buildupon")]
        public void Json_Both_Two_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Two_Both);





        [Benchmark]
        [BenchmarkCategory("media", "four", "both", "buildupon")]
        public void Media_Both_Four_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Four_Both);

        [Benchmark]
        [BenchmarkCategory("json", "four", "both", "buildupon")]
        public void Json_Both_Four_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Four_Both);




        [Benchmark]
        [BenchmarkCategory("media", "six", "both", "buildupon")]
        public void Media_Both_Six_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Six_Both);

        [Benchmark]
        [BenchmarkCategory("json", "six", "both", "buildupon")]
        public void Json_Both_Six_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Six_Both);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "both", "buildupon")]
        public void Media_Both_Eight_BuildUpon() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_BuildUpon.Eight_Both);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "both", "buildupon")]
        public void Json_Both_Eight_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Eight_Both);










        [Benchmark]
        [BenchmarkCategory("media", "one", "req", "shortstring")]
        public void Media_Req_One_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.One_Required);

        [Benchmark]
        [BenchmarkCategory("json", "one", "req", "shortstring")]
        public void Json_Req_One_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.One_Required);



        [Benchmark]
        [BenchmarkCategory("media", "two", "req", "shortstring")]
        public void Media_Req_Two_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Two_Required);

        [Benchmark]
        [BenchmarkCategory("json", "two", "req", "shortstring")]
        public void Json_Req_Two_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Two_Required);



        [Benchmark]
        [BenchmarkCategory("media", "three", "req", "shortstring")]
        public void Media_Req_Three_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Three_Required);

        [Benchmark]
        [BenchmarkCategory("json", "three", "req", "shortstring")]
        public void Json_Req_Three_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Three_Required);



        [Benchmark]
        [BenchmarkCategory("media", "four", "req", "shortstring")]
        public void Media_Req_Four_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Four_Required);

        [Benchmark]
        [BenchmarkCategory("json", "four", "req", "shortstring")]
        public void Json_Req_Four_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Four_Required);




        [Benchmark]
        [BenchmarkCategory("media", "five", "req", "shortstring")]
        public void Media_Req_Five_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Five_Required);

        [Benchmark]
        [BenchmarkCategory("json", "five", "req", "shortstring")]
        public void Json_Req_Five_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Five_Required);



        [Benchmark]
        [BenchmarkCategory("media", "six", "req", "shortstring")]
        public void Media_Req_Six_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Six_Required);

        [Benchmark]
        [BenchmarkCategory("json", "six", "req", "shortstring")]
        public void Json_Req_Six_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Six_Required);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "req", "shortstring")]
        public void Media_Req_Seven_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Seven_Required);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "req", "shortstring")]
        public void Json_Req_Seven_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Seven_Required);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "req", "shortstring")]
        public void Media_Req_Eight_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Eight_Required);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "req", "shortstring")]
        public void Json_Req_Eight_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Eight_Required);








        [Benchmark]
        [BenchmarkCategory("media", "one", "op", "shortstring")]
        public void Media_Op_One_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.One_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "one", "op", "shortstring")]
        public void Json_Op_One_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.One_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "two", "op", "shortstring")]
        public void Media_Op_Two_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Two_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "two", "op", "shortstring")]
        public void Json_Op_Two_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Two_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "three", "op", "shortstring")]
        public void Media_Op_Three_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Three_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "three", "op", "shortstring")]
        public void Json_Op_Three_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Three_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "four", "op", "shortstring")]
        public void Media_Op_Four_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Four_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "four", "op", "shortstring")]
        public void Json_Op_Four_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Four_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "five", "op", "shortstring")]
        public void Media_Op_Five_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Five_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "five", "op", "shortstring")]
        public void Json_Op_Five_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Five_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "six", "op", "shortstring")]
        public void Media_Op_Six_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Six_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "six", "op", "shortstring")]
        public void Json_Op_Six_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Six_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "op", "shortstring")]
        public void Media_Op_Seven_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Seven_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "op", "shortstring")]
        public void Json_Op_Seven_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Seven_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "op", "shortstring")]
        public void Media_Op_Eight_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Eight_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "op", "shortstring")]
        public void Json_Op_Eight_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Eight_Optional);








        [Benchmark]
        [BenchmarkCategory("media", "two", "both", "shortstring")]
        public void Media_Both_Two_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Two_Both);

        [Benchmark]
        [BenchmarkCategory("json", "two", "both", "shortstring")]
        public void Json_Both_Two_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Two_Both);





        [Benchmark]
        [BenchmarkCategory("media", "four", "both", "shortstring")]
        public void Media_Both_Four_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Four_Both);

        [Benchmark]
        [BenchmarkCategory("json", "four", "both", "shortstring")]
        public void Json_Both_Four_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Four_Both);




        [Benchmark]
        [BenchmarkCategory("media", "six", "both", "shortstring")]
        public void Media_Both_Six_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Six_Both);

        [Benchmark]
        [BenchmarkCategory("json", "six", "both", "shortstring")]
        public void Json_Both_Six_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Six_Both);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "both", "shortstring")]
        public void Media_Both_Eight_ShortString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_ShortString.Eight_Both);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "both", "shortstring")]
        public void Json_Both_Eight_ShortString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_ShortString.Eight_Both);













        [Benchmark]
        [BenchmarkCategory("media", "one", "req", "longstring")]
        public void Media_Req_One_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.One_Required);

        [Benchmark]
        [BenchmarkCategory("json", "one", "req", "longstring")]
        public void Json_Req_One_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.One_Required);



        [Benchmark]
        [BenchmarkCategory("media", "two", "req", "longstring")]
        public void Media_Req_Two_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Two_Required);

        [Benchmark]
        [BenchmarkCategory("json", "two", "req", "longstring")]
        public void Json_Req_Two_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Two_Required);



        [Benchmark]
        [BenchmarkCategory("media", "three", "req", "longstring")]
        public void Media_Req_Three_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Three_Required);

        [Benchmark]
        [BenchmarkCategory("json", "three", "req", "longstring")]
        public void Json_Req_Three_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Three_Required);



        [Benchmark]
        [BenchmarkCategory("media", "four", "req", "longstring")]
        public void Media_Req_Four_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Four_Required);

        [Benchmark]
        [BenchmarkCategory("json", "four", "req", "longstring")]
        public void Json_Req_Four_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Four_Required);




        [Benchmark]
        [BenchmarkCategory("media", "five", "req", "longstring")]
        public void Media_Req_Five_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Five_Required);

        [Benchmark]
        [BenchmarkCategory("json", "five", "req", "longstring")]
        public void Json_Req_Five_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Five_Required);



        [Benchmark]
        [BenchmarkCategory("media", "six", "req", "longstring")]
        public void Media_Req_Six_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Six_Required);

        [Benchmark]
        [BenchmarkCategory("json", "six", "req", "longstring")]
        public void Json_Req_Six_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Six_Required);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "req", "longstring")]
        public void Media_Req_Seven_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Seven_Required);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "req", "longstring")]
        public void Json_Req_Seven_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Seven_Required);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "req", "longstring")]
        public void Media_Req_Eight_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Eight_Required);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "req", "longstring")]
        public void Json_Req_Eight_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Eight_Required);








        [Benchmark]
        [BenchmarkCategory("media", "one", "op", "longstring")]
        public void Media_Op_One_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.One_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "one", "op", "longstring")]
        public void Json_Op_One_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.One_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "two", "op", "longstring")]
        public void Media_Op_Two_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Two_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "two", "op", "longstring")]
        public void Json_Op_Two_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Two_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "three", "op", "longstring")]
        public void Media_Op_Three_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Three_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "three", "op", "longstring")]
        public void Json_Op_Three_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Three_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "four", "op", "longstring")]
        public void Media_Op_Four_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Four_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "four", "op", "longstring")]
        public void Json_Op_Four_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Four_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "five", "op", "longstring")]
        public void Media_Op_Five_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Five_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "five", "op", "longstring")]
        public void Json_Op_Five_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Five_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "six", "op", "longstring")]
        public void Media_Op_Six_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Six_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "six", "op", "longstring")]
        public void Json_Op_Six_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Six_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "op", "longstring")]
        public void Media_Op_Seven_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Seven_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "op", "longstring")]
        public void Json_Op_Seven_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Seven_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "op", "longstring")]
        public void Media_Op_Eight_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Eight_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "op", "longstring")]
        public void Json_Op_Eight_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Eight_Optional);








        [Benchmark]
        [BenchmarkCategory("media", "two", "both", "longstring")]
        public void Media_Both_Two_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Two_Both);

        [Benchmark]
        [BenchmarkCategory("json", "two", "both", "longstring")]
        public void Json_Both_Two_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Two_Both);





        [Benchmark]
        [BenchmarkCategory("media", "four", "both", "longstring")]
        public void Media_Both_Four_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Four_Both);

        [Benchmark]
        [BenchmarkCategory("json", "four", "both", "longstring")]
        public void Json_Both_Four_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Four_Both);




        [Benchmark]
        [BenchmarkCategory("media", "six", "both", "longstring")]
        public void Media_Both_Six_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Six_Both);

        [Benchmark]
        [BenchmarkCategory("json", "six", "both", "longstring")]
        public void Json_Both_Six_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Six_Both);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "both", "longstring")]
        public void Media_Both_Eight_LongString() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_LongString.Eight_Both);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "both", "longstring")]
        public void Json_Both_Eight_LongString() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_LongString.Eight_Both);

















        [Benchmark]
        [BenchmarkCategory("media", "four", "req", "charcount")]
        public void Media_Req_Four_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Four_Required);

        [Benchmark]
        [BenchmarkCategory("json", "four", "req", "charcount")]
        public void Json_Req_Four_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Four_Required);






        [Benchmark]
        [BenchmarkCategory("media", "six", "req", "charcount")]
        public void Media_Req_Six_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Six_Required);

        [Benchmark]
        [BenchmarkCategory("json", "six", "req", "charcount")]
        public void Json_Req_Six_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Six_Required);





        [Benchmark]
        [BenchmarkCategory("media", "eight", "req", "charcount")]
        public void Media_Req_Eight_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Eight_Required);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "req", "charcount")]
        public void Json_Req_Eight_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Eight_Required);



        [Benchmark]
        [BenchmarkCategory("media", "Ten", "req", "charcount")]
        public void Media_Req_Ten_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Ten_Required);

        [Benchmark]
        [BenchmarkCategory("json", "Ten", "req", "charcount")]
        public void Json_Req_Ten_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Ten_Required);




        [Benchmark]
        [BenchmarkCategory("media", "twelve", "req", "charcount")]
        public void Media_Req_Twelve_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Twelve_Required);

        [Benchmark]
        [BenchmarkCategory("json", "twelve", "req", "charcount")]
        public void Json_Req_Twelve_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Twelve_Required);



        [Benchmark]
        [BenchmarkCategory("media", "fourteen", "req", "charcount")]
        public void Media_Req_Fourteen_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Fourteen_Required);

        [Benchmark]
        [BenchmarkCategory("json", "fourteen", "req", "charcount")]
        public void Json_Req_Fourteen_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Fourteen_Required);



        [Benchmark]
        [BenchmarkCategory("media", "sixteen", "req", "charcount")]
        public void Media_Req_Sixteen_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Sixteen_Required);

        [Benchmark]
        [BenchmarkCategory("json", "sixteen", "req", "charcount")]
        public void Json_Req_Sixteen_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Sixteen_Required);






        [Benchmark]
        [BenchmarkCategory("media", "four", "op", "charcount")]
        public void Media_Op_Four_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Four_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "four", "op", "charcount")]
        public void Json_Op_Four_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Four_Optional);






        [Benchmark]
        [BenchmarkCategory("media", "six", "op", "charcount")]
        public void Media_Op_Six_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Six_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "six", "op", "charcount")]
        public void Json_Op_Six_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Six_Optional);





        [Benchmark]
        [BenchmarkCategory("media", "eight", "op", "charcount")]
        public void Media_Op_Eight_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Eight_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "op", "charcount")]
        public void Json_Op_Eight_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Eight_Optional);





        [Benchmark]
        [BenchmarkCategory("media", "Ten", "op", "charcount")]
        public void Media_Op_Ten_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Ten_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "Ten", "op", "charcount")]
        public void Json_Op_Ten_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Ten_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "twelve", "op", "charcount")]
        public void Media_Op_Twelve_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Twelve_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "twelve", "op", "charcount")]
        public void Json_Op_Twelve_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Twelve_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "fourteen", "op", "charcount")]
        public void Media_Op_Fourteen_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Fourteen_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "fourteen", "op", "charcount")]
        public void Json_Op_Fourteen_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Fourteen_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "sixteen", "op", "charcount")]
        public void Media_Op_Sixteen_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Sixteen_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "sixteen", "op", "charcount")]
        public void Json_Op_Sixteen_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Sixteen_Optional);










        [Benchmark]
        [BenchmarkCategory("media", "four", "both", "charcount")]
        public void Media_Both_Four_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Four_Both);

        [Benchmark]
        [BenchmarkCategory("json", "four", "both", "charcount")]
        public void Json_Both_Four_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Four_Both);




        [Benchmark]
        [BenchmarkCategory("media", "six", "both", "charcount")]
        public void Media_Both_Six_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Six_Both);

        [Benchmark]
        [BenchmarkCategory("json", "six", "both", "charcount")]
        public void Json_Both_Six_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Six_Both);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "both", "charcount")]
        public void Media_Both_Eight_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Eight_Both);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "both", "charcount")]
        public void Json_Both_Eight_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Eight_Both);



        [Benchmark]
        [BenchmarkCategory("media", "Ten", "both", "charcount")]
        public void Media_Both_Ten_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Ten_Both);

        [Benchmark]
        [BenchmarkCategory("json", "Ten", "both", "charcount")]
        public void Json_Both_Ten_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Ten_Both);




        [Benchmark]
        [BenchmarkCategory("media", "twelve", "both", "charcount")]
        public void Media_Both_Twelve_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Twelve_Both);

        [Benchmark]
        [BenchmarkCategory("json", "twelve", "both", "charcount")]
        public void Json_Both_Twelve_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Twelve_Both);



        [Benchmark]
        [BenchmarkCategory("media", "fourteen", "both", "charcount")]
        public void Media_Both_Fourteen_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Fourteen_Both);

        [Benchmark]
        [BenchmarkCategory("json", "fourteen", "both", "charcount")]
        public void Json_Both_Fourteen_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Fourteen_Both);



        [Benchmark]
        [BenchmarkCategory("media", "sixteen", "both", "charcount")]
        public void Media_Both_Sixteen_CharCount() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_CharCount.Sixteen_Both);

        [Benchmark]
        [BenchmarkCategory("json", "sixteen", "both", "charcount")]
        public void Json_Both_Sixteen_CharCount() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_CharCount.Sixteen_Both);











        [Benchmark]
        [BenchmarkCategory("media", "one", "req", "withint")]
        public void Media_Req_One_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.One_Required);

        [Benchmark]
        [BenchmarkCategory("json", "one", "req", "withint")]
        public void Json_Req_One_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.One_Required);



        [Benchmark]
        [BenchmarkCategory("media", "two", "req", "withint")]
        public void Media_Req_Two_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Two_Required);

        [Benchmark]
        [BenchmarkCategory("json", "two", "req", "withint")]
        public void Json_Req_Two_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Two_Required);



        [Benchmark]
        [BenchmarkCategory("media", "three", "req", "withint")]
        public void Media_Req_Three_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Three_Required);

        [Benchmark]
        [BenchmarkCategory("json", "three", "req", "withint")]
        public void Json_Req_Three_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Three_Required);



        [Benchmark]
        [BenchmarkCategory("media", "four", "req", "withint")]
        public void Media_Req_Four_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Four_Required);

        [Benchmark]
        [BenchmarkCategory("json", "four", "req", "withint")]
        public void Json_Req_Four_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Four_Required);




        [Benchmark]
        [BenchmarkCategory("media", "five", "req", "withint")]
        public void Media_Req_Five_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Five_Required);

        [Benchmark]
        [BenchmarkCategory("json", "five", "req", "withint")]
        public void Json_Req_Five_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Five_Required);



        [Benchmark]
        [BenchmarkCategory("media", "six", "req", "withint")]
        public void Media_Req_Six_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Six_Required);

        [Benchmark]
        [BenchmarkCategory("json", "six", "req", "withint")]
        public void Json_Req_Six_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Six_Required);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "req", "withint")]
        public void Media_Req_Seven_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Seven_Required);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "req", "withint")]
        public void Json_Req_Seven_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Seven_Required);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "req", "withint")]
        public void Media_Req_Eight_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Eight_Required);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "req", "withint")]
        public void Json_Req_Eight_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Eight_Required);








        [Benchmark]
        [BenchmarkCategory("media", "one", "op", "withint")]
        public void Media_Op_One_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.One_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "one", "op", "withint")]
        public void Json_Op_One_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.One_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "two", "op", "withint")]
        public void Media_Op_Two_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Two_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "two", "op", "withint")]
        public void Json_Op_Two_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Two_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "three", "op", "withint")]
        public void Media_Op_Three_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Three_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "three", "op", "withint")]
        public void Json_Op_Three_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Three_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "four", "op", "withint")]
        public void Media_Op_Four_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Four_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "four", "op", "withint")]
        public void Json_Op_Four_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Four_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "five", "op", "withint")]
        public void Media_Op_Five_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Five_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "five", "op", "withint")]
        public void Json_Op_Five_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Five_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "six", "op", "withint")]
        public void Media_Op_Six_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Six_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "six", "op", "withint")]
        public void Json_Op_Six_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Six_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "op", "withint")]
        public void Media_Op_Seven_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Seven_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "op", "withint")]
        public void Json_Op_Seven_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Seven_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "op", "withint")]
        public void Media_Op_Eight_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Eight_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "op", "withint")]
        public void Json_Op_Eight_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Eight_Optional);








        [Benchmark]
        [BenchmarkCategory("media", "two", "both", "withint")]
        public void Media_Both_Two_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Two_Both);

        [Benchmark]
        [BenchmarkCategory("json", "two", "both", "withint")]
        public void Json_Both_Two_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Two_Both);





        [Benchmark]
        [BenchmarkCategory("media", "four", "both", "withint")]
        public void Media_Both_Four_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Four_Both);

        [Benchmark]
        [BenchmarkCategory("json", "four", "both", "withint")]
        public void Json_Both_Four_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Four_Both);




        [Benchmark]
        [BenchmarkCategory("media", "six", "both", "withint")]
        public void Media_Both_Six_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Six_Both);

        [Benchmark]
        [BenchmarkCategory("json", "six", "both", "withint")]
        public void Json_Both_Six_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Six_Both);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "both", "withint")]
        public void Media_Both_Eight_WithInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithInt.Eight_Both);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "both", "withint")]
        public void Json_Both_Eight_WithInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithInt.Eight_Both);















        [Benchmark]
        [BenchmarkCategory("media", "one", "req", "optionalint")]
        public void Media_Req_One_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.One_Required);

        [Benchmark]
        [BenchmarkCategory("json", "one", "req", "optionalint")]
        public void Json_Req_One_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.One_Required);



        [Benchmark]
        [BenchmarkCategory("media", "two", "req", "optionalint")]
        public void Media_Req_Two_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Two_Required);

        [Benchmark]
        [BenchmarkCategory("json", "two", "req", "optionalint")]
        public void Json_Req_Two_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Two_Required);



        [Benchmark]
        [BenchmarkCategory("media", "three", "req", "optionalint")]
        public void Media_Req_Three_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Three_Required);

        [Benchmark]
        [BenchmarkCategory("json", "three", "req", "optionalint")]
        public void Json_Req_Three_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Three_Required);



        [Benchmark]
        [BenchmarkCategory("media", "four", "req", "optionalint")]
        public void Media_Req_Four_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Four_Required);

        [Benchmark]
        [BenchmarkCategory("json", "four", "req", "optionalint")]
        public void Json_Req_Four_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Four_Required);




        [Benchmark]
        [BenchmarkCategory("media", "five", "req", "optionalint")]
        public void Media_Req_Five_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Five_Required);

        [Benchmark]
        [BenchmarkCategory("json", "five", "req", "optionalint")]
        public void Json_Req_Five_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Five_Required);



        [Benchmark]
        [BenchmarkCategory("media", "six", "req", "optionalint")]
        public void Media_Req_Six_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Six_Required);

        [Benchmark]
        [BenchmarkCategory("json", "six", "req", "optionalint")]
        public void Json_Req_Six_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Six_Required);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "req", "optionalint")]
        public void Media_Req_Seven_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Seven_Required);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "req", "optionalint")]
        public void Json_Req_Seven_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Seven_Required);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "req", "optionalint")]
        public void Media_Req_Eight_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Eight_Required);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "req", "optionalint")]
        public void Json_Req_Eight_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Eight_Required);








        [Benchmark]
        [BenchmarkCategory("media", "one", "op", "optionalint")]
        public void Media_Op_One_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.One_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "one", "op", "optionalint")]
        public void Json_Op_One_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.One_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "two", "op", "optionalint")]
        public void Media_Op_Two_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Two_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "two", "op", "optionalint")]
        public void Json_Op_Two_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Two_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "three", "op", "optionalint")]
        public void Media_Op_Three_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Three_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "three", "op", "optionalint")]
        public void Json_Op_Three_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Three_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "four", "op", "optionalint")]
        public void Media_Op_Four_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Four_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "four", "op", "optionalint")]
        public void Json_Op_Four_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Four_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "five", "op", "optionalint")]
        public void Media_Op_Five_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Five_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "five", "op", "optionalint")]
        public void Json_Op_Five_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Five_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "six", "op", "optionalint")]
        public void Media_Op_Six_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Six_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "six", "op", "optionalint")]
        public void Json_Op_Six_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Six_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "op", "optionalint")]
        public void Media_Op_Seven_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Seven_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "op", "optionalint")]
        public void Json_Op_Seven_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Seven_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "op", "optionalint")]
        public void Media_Op_Eight_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Eight_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "op", "optionalint")]
        public void Json_Op_Eight_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Eight_Optional);








        [Benchmark]
        [BenchmarkCategory("media", "two", "both", "optionalint")]
        public void Media_Both_Two_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Two_Both);

        [Benchmark]
        [BenchmarkCategory("json", "two", "both", "optionalint")]
        public void Json_Both_Two_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Two_Both);





        [Benchmark]
        [BenchmarkCategory("media", "four", "both", "optionalint")]
        public void Media_Both_Four_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Four_Both);

        [Benchmark]
        [BenchmarkCategory("json", "four", "both", "optionalint")]
        public void Json_Both_Four_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Four_Both);




        [Benchmark]
        [BenchmarkCategory("media", "six", "both", "optionalint")]
        public void Media_Both_Six_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Six_Both);

        [Benchmark]
        [BenchmarkCategory("json", "six", "both", "optionalint")]
        public void Json_Both_Six_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Six_Both);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "both", "optionalint")]
        public void Media_Both_Eight_WithOptionalInt() => Search.TableSearch_Media_NoColumns(StringTestValueConstants_WithOptionalInt.Eight_Both);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "both", "optionalint")]
        public void Json_Both_Eight_WithOptionalInt() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_WithOptionalInt.Eight_Both);

    }

    public static class StringTestValueConstants
    {
        public static Dictionary<int, string> One_Required = new Dictionary<int, string>() {
                { 1 , "adipisci" }
            };

        public static Dictionary<int, string> Two_Required = new Dictionary<int, string>() {
                { 2 , "dignissimos" },
                { 3 , "excepturi" },
            };

        public static Dictionary<int, string> Three_Required = new Dictionary<int, string>() {
                { 4 , "molestiae" },
                { 5 , "atque" },
                { 6 , "molestias" },
            };

        public static Dictionary<int, string> Four_Required = new Dictionary<int, string>() {
                { 7 , "fugiat" },
                { 8 , "laboriosam" },
                { 9 , "quisquam" },
                { 10 , "beatae" },
            };

        public static Dictionary<int, string> Five_Required = new Dictionary<int, string>() {
                { 1 , "aspernatur" },
                { 2 , "molestiae" },
                { 3 , "velit" },
                { 4 , "nesciunt" },
                { 5 , "expedita" },
            };

        public static Dictionary<int, string> Six_Required = new Dictionary<int, string>() {
                { 8 , "nostrum" },
                { 9 , "consequatur" },
                { 10 , "tempora" },
                { 11 , "asperiores" },
                { 12 , "laudantium" },
                { 13 , "officia" },
            };

        public static Dictionary<int, string> Seven_Required = new Dictionary<int, string>() {
                { 8 , "nostrum" },
                { 9 , "consequatur" },
                { 10 , "tempora" },
                { 11 , "asperiores" },
                { 12 , "laudantium" },
                { 13 , "officia" },
                { 14 , "sapiente" },
            };

        public static Dictionary<int, string> Eight_Required = new Dictionary<int, string>() {
                { 20 , "voluptatum" },
                { 19 , "reiciendis" },
                { 18 , "placeat" },
                { 17 , "suscipit" },
                { 16 , "velit" },
                { 12 , "quos" },
                { 10 , "dolores" },
                { 7 , "laborum" },
            };





        public static Dictionary<int, string> One_Optional = new Dictionary<int, string>() {
                { 40 , "dolor" }
            };

        public static Dictionary<int, string> Two_Optional = new Dictionary<int, string>() {
                { 40 , "dolores" },
                { 38 , "distinctio" },
            };

        public static Dictionary<int, string> Three_Optional = new Dictionary<int, string>() {
                { 40 , "tempora" },
                { 38 , "maiores" },
                { 31 , "iusto" },
            };

        public static Dictionary<int, string> Four_Optional = new Dictionary<int, string>() {
                { 21 , "impedit" },
                { 23 , "nobis" },
                { 26 , "maxime" },
                { 27 , "quasi" },
            };

        public static Dictionary<int, string> Five_Optional = new Dictionary<int, string>() {
                { 35 , "ipsam" },
                { 34 , "libero" },
                { 33 , "dolorem" },
                { 28 , "nihil" },
                { 27 , "libero" },
            };

        public static Dictionary<int, string> Six_Optional = new Dictionary<int, string>() {
                { 24 , "molestiae" },
                { 25 , "facilis" },
                { 28 , "quisquam" },
                { 29 , "impedit" },
                { 30 , "veritatis" },
                { 33 , "earum" },
            };

        public static Dictionary<int, string> Seven_Optional = new Dictionary<int, string>() {
                { 28 , "qui" },
                { 29 , "dolor" },
                { 32 , "illum" },
                { 33 , "corrupti" },
                { 35 , "sapiente" },
                { 36 , "nulla" },
                { 37 , "soluta" },
            };

        public static Dictionary<int, string> Eight_Optional = new Dictionary<int, string>() {
                { 38 , "possimus" },
                { 37 , "autem" },
                { 36 , "ipsum" },
                { 34 , "quidem" },
                { 33 , "maiores" },
                { 30 , "omnis" },
                { 29 , "aliquid" },
                { 28 , "sequi" },
            };






        public static Dictionary<int, string> Two_Both = new Dictionary<int, string>() {
                { 40 , "veritatis" },
                { 4 , "tempora" },
            };

        public static Dictionary<int, string> Four_Both = new Dictionary<int, string>() {
                { 28 , "enim" },
                { 29 , "eligendi" },
                { 13 , "illo" },
                { 14 , "earum" },
            };

        public static Dictionary<int, string> Six_Both = new Dictionary<int, string>() {
                { 13 , "enim" },
                { 14 , "quisquam" },
                { 12 , "ipsa" },
                { 28 , "voluptate" },
                { 36 , "dolor" },
                { 37 , "beatae" },
            };

        public static Dictionary<int, string> Eight_Both = new Dictionary<int, string>() {
                { 40 , "quas" },
                { 39 , "possimus" },
                { 38 , "voluptas" },
                { 37 , "nihil" },
                { 20 , "porro" },
                { 19 , "facere" },
                { 18 , "debitis" },
                { 17 , "atque" },
            };
    }
}
