﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Bogus;

namespace ef_json_query_testing.Benchmarks
{
    public class IntSearch : BaseBenchmark
    {
        public IEnumerable<object[]> BenchmarkData_IntMatch()
        {
            var intTypeField = Context.DynamicFields.First(m => !m.DynamicListTypeId.HasValue && m.DataType == DataTypes.IntValue);

            var faker = new Faker();
            var item = faker.PickRandom<DynamicMediaInformation>(Context.DynamicMediaInformation.Where(m => m.FieldId == intTypeField.DynamicFieldId));

            yield return new object[] { item.FieldId, item.Value };
        }

        //[Benchmark(OperationsPerInvoke = 20)]
        [Benchmark]
        [BenchmarkCategory("json", "int", "raw")]
        [ArgumentsSource(nameof(BenchmarkData_IntMatch))]
        public void Raw(int i, string str) => Search.JsonSearch_Raw(i, str);

        [Benchmark]
        [BenchmarkCategory("json", "int", "magic")]
        [ArgumentsSource(nameof(BenchmarkData_IntMatch))]
        public void Magic(int i, string str) => Search.JsonSearch_EfMagic(i, str);

        [Benchmark]
        [BenchmarkCategory("table", "int", "info")]
        [ArgumentsSource(nameof(BenchmarkData_IntMatch))]
        public void Info(int i, string str) => Search.TableSearch_Info(i, str);

        [Benchmark]
        [BenchmarkCategory("table", "int", "media")]
        [ArgumentsSource(nameof(BenchmarkData_IntMatch))]
        public void Media(int i, string str) => Search.TableSearch_Media(i, str);
    }
}
