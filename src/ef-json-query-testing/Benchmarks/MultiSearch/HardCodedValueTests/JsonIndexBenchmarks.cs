using BenchmarkDotNet.Attributes;

namespace ef_json_query_testing.Benchmarks.MultiSearch.HardCodedValueTests
{
    public class JsonIndexBenchmarks : BaseBenchmark
    {
        // run with indexes
        // run without indexes on columns 1 and 2
        // run without indexes on unsearched columns (6, 11-25, 27-45, 47+)

        [Benchmark]
        [BenchmarkCategory("seven", "req", "bool", "int")]
        public void Indexed_first_req_bool_int() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_req_bool_int);

        [Benchmark]
        [BenchmarkCategory("four", "op", "int")]
        public void Indexed_first_op_int() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_op_int);
    }

    public class JsonIndexStringBenchmarks : BaseBenchmark
    {
        // run with indexes
        // run without indexes on columns 1 and 40
        // run without indexes on unsearched columns (4-6, 8-34, 37, 39)

        [Benchmark]
        [BenchmarkCategory("one", "req", "buildupon", "string")]
        public void Json_Req_One_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.One_Required);

        [Benchmark]
        [BenchmarkCategory("four", "req", "buildupon", "string")]
        public void Json_Req_Four_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Four_Required);

        [Benchmark]
        [BenchmarkCategory("one", "op", "buildupon", "string")]
        public void Json_Op_One_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.One_Optional);

        [Benchmark]
        [BenchmarkCategory("four", "op", "buildupon", "string")]
        public void Json_Op_Four_BuildUpon() => Search.JsonSearch_Indexed_NoColumns(StringTestValueConstants_BuildUpon.Four_Optional);
    }
}
