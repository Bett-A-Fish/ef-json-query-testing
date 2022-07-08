using BenchmarkDotNet.Attributes;

namespace ef_json_query_testing.Benchmarks.MultiSearch.HardCodedValueTests
{
    public class DateFieldBenchmarks : BaseBenchmark
    {
        [Benchmark]
        [BenchmarkCategory("json", "hascolumns", "indexed", "first", "dates")]
        public void Indexed_first_both_date_int_bool() => Search.JsonSearch_Indexed(TestValueConstants.first_both_date_int_bool);

        [Benchmark]
        [BenchmarkCategory("table", "hascolumns", "media", "first", "dates")]
        public void Media_first_both_date_int_bool() => Search.TableSearch_Media(TestValueConstants.first_both_date_int_bool);

        [Benchmark]
        [BenchmarkCategory("json", "nocolumns", "indexed", "first", "dates")]
        public void Indexed_noColumns_first_both_date_int_bool() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.first_both_date_int_bool);

        [Benchmark]
        [BenchmarkCategory("table", "nocolumns", "media", "first", "dates")]
        public void Media_noColumns_first_both_date_int_bool() => Search.TableSearch_Media_NoColumns(TestValueConstants.first_both_date_int_bool);




        [Benchmark]
        [BenchmarkCategory("json", "hascolumns", "indexed", "set1", "dates")]
        public void Indexed_set1_req_date() => Search.JsonSearch_Indexed(TestValueConstants.set1_req_date);

        [Benchmark]
        [BenchmarkCategory("table", "hascolumns", "media", "set1", "dates")]
        public void Media_set1_req_date() => Search.TableSearch_Media(TestValueConstants.set1_req_date);

        [Benchmark]
        [BenchmarkCategory("json", "nocolumns", "indexed", "set1", "dates")]
        public void Indexed_noColumns_set1_req_date() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set1_req_date);

        [Benchmark]
        [BenchmarkCategory("table", "nocolumns", "media", "set1", "dates")]
        public void Media_noColumns_set1_req_date() => Search.TableSearch_Media_NoColumns(TestValueConstants.set1_req_date);




        [Benchmark]
        [BenchmarkCategory("json", "hascolumns", "indexed", "set2", "dates")]
        public void Indexed_set1_op_date() => Search.JsonSearch_Indexed(TestValueConstants.set1_op_date);

        [Benchmark]
        [BenchmarkCategory("table", "hascolumns", "media", "set2", "dates")]
        public void Media_set1_op_date() => Search.TableSearch_Media(TestValueConstants.set1_op_date);

        [Benchmark]
        [BenchmarkCategory("json", "nocolumns", "indexed", "set2", "dates")]
        public void Indexed_noColumns_set1_op_date() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set1_op_date);

        [Benchmark]
        [BenchmarkCategory("table", "nocolumns", "media", "set2", "dates")]
        public void Media_noColumns_set1_op_date() => Search.TableSearch_Media_NoColumns(TestValueConstants.set1_op_date);




        [Benchmark]
        [BenchmarkCategory("json", "hascolumns", "indexed", "set3", "dates")]
        public void Indexed_set1_both_date() => Search.JsonSearch_Indexed(TestValueConstants.set1_both_date);

        [Benchmark]
        [BenchmarkCategory("table", "hascolumns", "media", "set3", "dates")]
        public void Media_set1_both_date() => Search.TableSearch_Media(TestValueConstants.set1_both_date);

        [Benchmark]
        [BenchmarkCategory("json", "nocolumns", "indexed", "set3", "dates")]
        public void Indexed_noColumns_set1_both_date() => Search.JsonSearch_Indexed_NoColumns(TestValueConstants.set1_both_date);

        [Benchmark]
        [BenchmarkCategory("table", "nocolumns", "media", "set3", "dates")]
        public void Media_noColumns_set1_both_date() => Search.TableSearch_Media_NoColumns(TestValueConstants.set1_both_date);
    }
}
