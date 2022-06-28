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
        [BenchmarkCategory("json", "adjusted", "one", "req")]
        public void Json_Adjusted_Req_One() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.One_Required);



        [Benchmark]
        [BenchmarkCategory("media", "two", "req")]
        public void Media_Req_Two() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Two_Required);

        [Benchmark]
        [BenchmarkCategory("json", "two", "req")]
        public void Json_Req_Two() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Two_Required);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "two", "req")]
        public void Json_Adjusted_Req_Two() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Two_Required);



        [Benchmark]
        [BenchmarkCategory("media", "three", "req")]
        public void Media_Req_Three() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Three_Required);

        [Benchmark]
        [BenchmarkCategory("json", "three", "req")]
        public void Json_Req_Three() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Three_Required);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "three", "req")]
        public void Json_Adjusted_Req_Three() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Three_Required);



        [Benchmark]
        [BenchmarkCategory("media", "four", "req")]
        public void Media_Req_Four() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Four_Required);

        [Benchmark]
        [BenchmarkCategory("json", "four", "req")]
        public void Json_Req_Four() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Four_Required);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "four", "req")]
        public void Json_Adjusted_Req_Four() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Four_Required);




        [Benchmark]
        [BenchmarkCategory("media", "five", "req")]
        public void Media_Req_Five() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Five_Required);

        [Benchmark]
        [BenchmarkCategory("json", "five", "req")]
        public void Json_Req_Five() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Five_Required);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "five", "req")]
        public void Json_Adjusted_Req_Five() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Five_Required);



        [Benchmark]
        [BenchmarkCategory("media", "six", "req")]
        public void Media_Req_Six() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Six_Required);

        [Benchmark]
        [BenchmarkCategory("json", "six", "req")]
        public void Json_Req_Six() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Six_Required);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "six", "req")]
        public void Json_Adjusted_Req_Six() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Six_Required);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "req")]
        public void Media_Req_Seven() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Seven_Required);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "req")]
        public void Json_Req_Seven() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Seven_Required);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "seven", "req")]
        public void Json_Adjusted_Req_Seven() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Seven_Required);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "req")]
        public void Media_Req_Eight() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Eight_Required);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "req")]
        public void Json_Req_Eight() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Eight_Required);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "eight", "req")]
        public void Json_Adjusted_Req_Eight() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Eight_Required);








        [Benchmark]
        [BenchmarkCategory("media", "one", "op")]
        public void Media_Op_One() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.One_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "one", "op")]
        public void Json_Op_One() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.One_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "one", "op")]
        public void Json_Adjusted_Op_One() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.One_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "two", "op")]
        public void Media_Op_Two() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Two_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "two", "op")]
        public void Json_Op_Two() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Two_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "two", "op")]
        public void Json_Adjusted_Op_Two() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Two_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "three", "op")]
        public void Media_Op_Three() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Three_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "three", "op")]
        public void Json_Op_Three() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Three_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "three", "op")]
        public void Json_Adjusted_Op_Three() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Three_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "four", "op")]
        public void Media_Op_Four() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Four_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "four", "op")]
        public void Json_Op_Four() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Four_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "four", "op")]
        public void Json_Adjusted_Op_Four() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Four_Optional);




        [Benchmark]
        [BenchmarkCategory("media", "five", "op")]
        public void Media_Op_Five() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Five_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "five", "op")]
        public void Json_Op_Five() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Five_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "five", "op")]
        public void Json_Adjusted_Op_Five() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Five_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "six", "op")]
        public void Media_Op_Six() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Six_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "six", "op")]
        public void Json_Op_Six() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Six_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "six", "op")]
        public void Json_Adjusted_Op_Six() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Six_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "seven", "op")]
        public void Media_Op_Seven() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Seven_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "seven", "op")]
        public void Json_Op_Seven() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Seven_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "seven", "op")]
        public void Json_Adjusted_Op_Seven() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Seven_Optional);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "op")]
        public void Media_Op_Eight() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Eight_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "op")]
        public void Json_Op_Eight() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Eight_Optional);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "eight", "op")]
        public void Json_Adjusted_Op_Eight() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Eight_Optional);








        [Benchmark]
        [BenchmarkCategory("media", "two", "both")]
        public void Media_Both_Two() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Two_Both);

        [Benchmark]
        [BenchmarkCategory("json", "two", "both")]
        public void Json_Both_Two() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Two_Both);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "two", "both")]
        public void Json_Adjusted_Both_Two() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Two_Both);





        [Benchmark]
        [BenchmarkCategory("media", "four", "both")]
        public void Media_Both_Four() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Four_Both);

        [Benchmark]
        [BenchmarkCategory("json", "four", "both")]
        public void Json_Both_Four() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Four_Both);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "four", "both")]
        public void Json_Adjusted_Both_Four() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Four_Both);




        [Benchmark]
        [BenchmarkCategory("media", "six", "both")]
        public void Media_Both_Six() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Six_Both);

        [Benchmark]
        [BenchmarkCategory("json", "six", "both")]
        public void Json_Both_Six() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Six_Both);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "six", "both")]
        public void Json_Adjusted_Both_Six() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Six_Both);



        [Benchmark]
        [BenchmarkCategory("media", "eight", "both")]
        public void Media_Both_Eight() => Search.TableSearch_Media_NoColumns(StringTestValueConstants.Eight_Both);

        [Benchmark]
        [BenchmarkCategory("json", "eight", "both")]
        public void Json_Both_Eight() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants.Eight_Both);

        [Benchmark]
        [BenchmarkCategory("json", "adjusted", "eight", "both")]
        public void Json_Adjusted_Both_Eight() => Search.JsonSearch_Indexed_NoColumns_StringAdjustment(StringTestValueConstants.Eight_Both);

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
                { 30 , "maiores" },
                { 27 , "expedita" },
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
