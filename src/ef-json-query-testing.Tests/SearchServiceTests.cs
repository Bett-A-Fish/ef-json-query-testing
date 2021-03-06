using ef_json_query_testing.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NaughtyStrings.Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ef_json_query_testing.Tests
{
    [Collection("Database collection")]
    public class SearchServiceTests
    {
        private DatabaseFixture _fixture;

        public SearchServiceTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        #region Test cases


        public static IEnumerable<object[]> NoMatch_TestCases()
        {
            // no fields given
            yield return new object[] { new Dictionary<int, string>() };

            // DynamicFields doesnt exist
            yield return new object[] { new Dictionary<int, string>() {
                { 500, "d" },
                { 0, "d" }
            } };

            // DynamicFields exists, but no match
            yield return new object[] { new Dictionary<int, string>() {
                { 1, "0" },
                { 2, "0" }
            } };

            // DynamicFields exists, but no media has the field.
            yield return new object[] { new Dictionary<int, string>() {
                { 11, "asd" },
                { 13, "0" },
                { 17, "0" }
            } };

            // DynamicFields exists, value exists but dont match exactly
            yield return new object[] { new Dictionary<int, string>() {
                { 4, "1" },
                { 8, "11" }
            } };

            // DynamicFields exists, value exists but dont match exactly
            yield return new object[] { new Dictionary<int, string>() {
                { 18, "9148-05-20T18:30:49.0000000" },
                { 20, "8057-02-14T20:43:14.0000000" }
            } };
        }
        

        public static IEnumerable<object[]> Exact_TestCases()
        {
            yield return new object[] { new Dictionary<int, string>() {
                { 1, "1" }
            }, new int[] { 1 } };
            yield return new object[] { new Dictionary<int, string>() {
                { 7, "444" },
                { 2, "6" }
            }, new int[] { 4 } };
            yield return new object[] { new Dictionary<int, string>() {
                { 7, "444" },
                { 5, "21" }
            }, new int[] { 4, 5 } };
        }


        public static IEnumerable<object[]> Contains_TestCases()
        {
            yield return new object[] { new Dictionary<int, string>() {
                { 10, "my" }
            }, new int[] { 1, 2 } };
            yield return new object[] { new Dictionary<int, string>() {
                { 10, "time" },
                { 12, "I" }
            }, new int[] { 1 } };
            yield return new object[] { new Dictionary<int, string>() {
                { 10, "B" },
                { 11, "this" }
            }, new int[] { 2, 3, 4 } };
            yield return new object[] { new Dictionary<int, string>() {
                { 12, "i" },
                { 10, "t" }
            }, new int[] { 1, 2, 3, 4 } };
            yield return new object[] { new Dictionary<int, string>() {
                { 12, "wind;" }
            }, new int[] { 5 } };
            yield return new object[] { new Dictionary<int, string>() {
                { 10, "B" },
                { 12, "'" }
            }, new int[] { 2, 4 } };
            yield return new object[] { new Dictionary<int, string>() {
                { 12, "chain of command" }
            }, new int[] { 2 } };
        }


        public static IEnumerable<object[]> Any_TestCases()
        {
            // exact and contains matches
            yield return new object[] { new Dictionary<int, string>() {
                { 7, "444" },
                { 12, "ten" }
            }, new int[] { 4 } };

            // exact and contains matches
            yield return new object[] { new Dictionary<int, string>() {
                { 12, "the" },
                { 18, "0130-05-09T07:18:21.0000000" }
            }, new int[] { 5 } };

            // lots of fields
            yield return new object[] { new Dictionary<int, string>() {
                { 3, "11" },
                { 6, "123" },
                { 10, "b" },
                { 14, "0" },
                { 2, "6" },
                { 11, "alone" },
            }, new int[] { 3 } };

            // all
            yield return new object[] { new Dictionary<int, string>() {
                { 1, "5" },
                { 3, "13" },
                { 4, "20" },
                { 6, "999" },
                { 8, "333" },
                { 10, "pew" },
                { 12, "leaf" },
                { 14, "0" },
                { 16, "1" },
                { 2, "7" },
                { 5, "21" },
                { 7, "444" },
                { 9, "50" },
                { 11, "are" },
                { 13, "true" },
                { 15, "0" },
                { 17, "1" },
            }, new int[] { 5 } };
        }



        public static IEnumerable<object[]> HasDynamicInformation_TestCases()
        {
            yield return new object[] { new Dictionary<int, string>() {
                { 1, "1" }
            }, 1 };
            yield return new object[] { new Dictionary<int, string>() {
                { 12, "Inevitable Betrayal" }
            }, 3 };
        }


        public static IReadOnlyList<string> SQLInjectionJson = new List<string>
        {
            "1;DROP TABLE Media_Json",
            "1\'; DROP TABLE Media_Json-- 1",
            "\'; EXEC sp_MSForEachTable \'DROP TABLE ?\'; --",
        };

        public static IReadOnlyList<string> SQLInjectionMedia = new List<string>
        {
            "1;DROP TABLE Media_Dynamic",
            "1\'; DROP TABLE Media_Dynamic-- 1",
            "\'; EXEC sp_MSForEachTable \'DROP TABLE ?\'; --",
        };

        #endregion

        #region Json

        #region Raw Single


        [Theory]
        [InlineData(0, "asd")] // DynamicFields doesnt exist
        [InlineData(1, "0")] // DynamicFields exists, but no match
        [InlineData(6, "22")] // DynamicFields exists, value exists but doesnt match exactly
        public void Raw_Single_NoMatch(int FieldId, string searchValue)
        {
            var media = _fixture.SearchService.JsonSearch_Raw(FieldId, searchValue);

            media.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1, "1", new[] { 1 })]
        [InlineData(6, "2", new[] { 1 })]
        [InlineData(6, "222", new[] { 2 })]
        [InlineData(16, "1", new[] { 1, 3, 5 })]
        public void Raw_Single_Exact(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.JsonSearch_Raw(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }

        [Theory]
        [InlineData(10, "my", new[] { 1, 2 })]
        [InlineData(10, "time", new[] { 1 })]
        [InlineData(10, "B", new[] { 2, 3, 4 })] // case doesnt matter for search
        [InlineData(12, "i", new[] { 1, 2, 3, 4, 5 })] // anywhere in sentence works
        [InlineData(12, "is?", new[] { 2 })] // special characters
        [InlineData(12, "'", new[] { 2, 4 })] // sql string char
        [InlineData(12, "chain of command", new[] { 2 })] // multiple words
        public void Raw_Single_Contains(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.JsonSearch_Raw(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }

        [Theory]
        [InlineData(1, "1", 1)]
        [InlineData(10, "time", 1)]
        public void Raw_Single_HasDynamicInformation(int fieldId, string str, int expectedId)
        {
            var media = _fixture.SearchService.JsonSearch_Raw(fieldId, str).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToDictionary(i => i.Field.DynamicFieldId.ToString(), i => (object)i.Value);


            Assert.Equal(expectedId, media?.Media_JsonId);
            Assert.NotNull(media?.Details);
            Assert.All(media?.Details, l => expectedInfo.Contains(l));
        }

        #endregion

        #region Raw Dictionary


        [Theory]
        [MemberData(nameof(NoMatch_TestCases))]
        public void Raw_Multi_NoMatch(Dictionary<int, string> searchFields)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Raw(searchFields);

            Assert.Empty(media);
        }



        [Theory]
        [MemberData(nameof(Exact_TestCases))]
        public void Raw_Multi_Exact(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Raw(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }


        [Theory]
        [MemberData(nameof(Contains_TestCases))]
        public void Raw_Multi_Contains(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Raw(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }


        [Theory]
        [MemberData(nameof(Any_TestCases))]
        public void Raw_Multi_Any(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Raw(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }


        [Theory]
        [MemberData(nameof(HasDynamicInformation_TestCases))]
        public void Raw_Multi_HasDynamicInformation(Dictionary<int, string> searchFields, int expectedId)
        {
            var media = _fixture.SearchService.JsonSearch_Raw(searchFields).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToDictionary(i => i.Field.DynamicFieldId.ToString(), i => (object)i.Value);


            Assert.Equal(expectedId, media?.Media_JsonId);
            Assert.NotEmpty(media?.Details);
            Assert.All(media?.Details, l => expectedInfo.Contains(l));
        }

        #endregion

        #region Indexed Dictionary

        [Theory]
        [MemberData(nameof(NoMatch_TestCases))]
        public void Indexed_Multi_NoMatch(Dictionary<int, string> searchFields)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Indexed(searchFields, false);

            Assert.Empty(media);
        }


        [Theory]
        [MemberData(nameof(Exact_TestCases))]
        public void Indexed_Multi_Exact(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Indexed(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }



        [Theory]
        [MemberData(nameof(Contains_TestCases))]
        public void Indexed_Multi_Contains(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Indexed(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }

        [Theory]
        [MemberData(nameof(Any_TestCases))]
        public void Indexed_Multi_Any(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Indexed(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }

        [Theory]
        [MemberData(nameof(HasDynamicInformation_TestCases))]
        public void Indexed_Multi_HasDynamicInformation(Dictionary<int, string> searchFields, int expectedId)
        {
            var media = _fixture.SearchService.JsonSearch_Indexed(searchFields).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToDictionary(i => i.Field.DynamicFieldId.ToString(), i => (object)i.Value);


            Assert.Equal(expectedId, media?.Media_JsonId);
            Assert.NotEmpty(media?.Details);
            Assert.All(media?.Details, l => expectedInfo.Contains(l));
        }

        #endregion

        #region Indexed Dictionary No Columns

        [Theory]
        [MemberData(nameof(NoMatch_TestCases))]
        public void Indexed_NoColumns_NoMatch(Dictionary<int, string> searchFields)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Indexed_NoColumns(searchFields, false);

            Assert.Empty(media);
        }


        [Theory]
        [MemberData(nameof(Exact_TestCases))]
        public void Indexed_NoColumns_Exact(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Indexed_NoColumns(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.Empty(item.Details);
            }
        }



        [Theory]
        [MemberData(nameof(Contains_TestCases))]
        public void Indexed_NoColumns_Contains(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Indexed_NoColumns(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.Empty(item.Details);
            }
        }

        [Theory]
        [MemberData(nameof(Any_TestCases))]
        public void Indexed_NoColumns_Any(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_Indexed_NoColumns(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.Empty(item.Details);
            }
        }

        [Theory]
        [MemberData(nameof(HasDynamicInformation_TestCases))]
        public void Indexed_NoColumns_HasNoDynamicInformation(Dictionary<int, string> searchFields, int expectedId)
        {
            var media = _fixture.SearchService.JsonSearch_Indexed_NoColumns(searchFields).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToDictionary(i => i.Field.DynamicFieldId.ToString(), i => (object)i.Value);


            Assert.Equal(expectedId, media?.Media_JsonId);
            Assert.Empty(media?.Details);
        }

        #endregion

        #region Magic Single


        [Theory]
        [InlineData(0, "asd")] // DynamicFields doesnt exist
        [InlineData(1, "asd")] // DynamicFields exists, but no match
        [InlineData(2, "asd")] // DynamicFields exists, but no media has the field.
        [InlineData(6, "22")] // DynamicFields exists, value exists but doesnt match exactly
        public void Magic_Single_NoMatch(int FieldId, string searchValue)
        {
            var media = _fixture.SearchService.JsonSearch_EfMagic(FieldId, searchValue);

            media.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1, "1", new[] { 1 })]
        [InlineData(6, "2", new[] { 1 })]
        [InlineData(6, "222", new[] { 2 })]
        [InlineData(16, "1", new[] { 1, 3, 5 })]
        public void Magic_Single_Exact(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.JsonSearch_EfMagic(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }

        [Theory]
        [InlineData(10, "my", new[] { 1, 2 })]
        [InlineData(10, "time", new[] { 1 })]
        [InlineData(10, "B", new[] { 2, 3, 4 })] // case doesnt matter for search
        [InlineData(12, "i", new[] { 1, 2, 3, 4, 5 })] // anywhere in sentence works
        [InlineData(12, "is?", new[] { 2 })] // special characters
        [InlineData(12, "'", new[] { 2, 4 })] // sql string char
        [InlineData(12, "chain of command", new[] { 2 })] // multiple words
        public void Magic_Single_Contains(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.JsonSearch_EfMagic(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }

        [Theory]
        [InlineData(1, "1", 1)]
        [InlineData(10, "time", 1)]
        public void Magic_Single_HasDynamicInformation(int fieldId, string str, int expectedId)
        {
            var media = _fixture.SearchService.JsonSearch_EfMagic(fieldId, str).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToDictionary(i => i.Field.DynamicFieldId.ToString(), i => (object)i.Value);


            Assert.Equal(expectedId, media?.Media_JsonId);
            Assert.NotEmpty(media?.Details);
            Assert.All(media?.Details, l => expectedInfo.Contains(l));
        }

        #endregion

        #region Magic Dictionary


        [Theory]
        [MemberData(nameof(NoMatch_TestCases))]
        public void Magic_Multi_NoMatch(Dictionary<int, string> searchFields)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_EfMagic(searchFields);

            Assert.Empty(media);
        }


        [Theory]
        [MemberData(nameof(Exact_TestCases))]
        public void Magic_Multi_Exact(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_EfMagic(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }

        [Theory]
        [MemberData(nameof(Contains_TestCases))]
        public void Magic_Multi_Contains(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_EfMagic(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }

        [Theory]
        [MemberData(nameof(Any_TestCases))]
        public void Magic_Multi_Any(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            List<Media_Json>? media = _fixture.SearchService.JsonSearch_EfMagic(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.Details);
            }
        }


        [Theory]
        [MemberData(nameof(HasDynamicInformation_TestCases))]
        public void Magic_Multi_HasDynamicInformation(Dictionary<int, string> searchFields, int expectedId)
        {
            var media = _fixture.SearchService.JsonSearch_EfMagic(searchFields).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToDictionary(i => i.Field.DynamicFieldId.ToString(), i => (object)i.Value);


            Assert.Equal(expectedId, media?.Media_JsonId);
            Assert.NotEmpty(media?.Details);
            Assert.All(media?.Details, l => expectedInfo.Contains(l));
        }

        #endregion

        #endregion

        #region Table

        #region Info Single


        [Theory]
        [InlineData(0, "asd")] // DynamicFields doesnt exist
        [InlineData(1, "asd")] // DynamicFields exists, but no match
        [InlineData(2, "asd")] // DynamicFields exists, but no media has the field.
        [InlineData(6, "22")] // DynamicFields exists, value exists but doesnt match exactly
        public void Info_Single_NoMatch(int FieldId, string searchValue)
        {
            var media = _fixture.SearchService.TableSearch_Info(FieldId, searchValue);

            media.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1, "1", new[] { 1 })]
        [InlineData(6, "2", new[] { 1 })]
        [InlineData(6, "222", new[] { 2 })]
        [InlineData(16, "1", new[] { 1, 3, 5 })]
        public void Info_Single_Exact(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Info(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
            }
        }

        [Theory]
        [InlineData(10, "my", new[] { 1, 2 })]
        [InlineData(10, "time", new[] { 1 })]
        [InlineData(10, "B", new[] { 2, 3, 4 })] // case doesnt matter for search
        [InlineData(12, "i", new[] { 1, 2, 3, 4, 5 })] // anywhere in sentence works
        [InlineData(12, "is?", new[] { 2 })] // special characters
        [InlineData(12, "'", new[] { 2, 4 })] // sql string char
        [InlineData(12, "chain of command", new[] { 2 })] // multiple words
        public void Info_Single_Contains(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Info(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
            }
        }

        [Theory]
        [InlineData(1, "1", 1)]
        [InlineData(10, "time", 1)]
        public void Info_Single_HasDynamicInformation(int fieldId, string str, int expectedId)
        {
            var media = _fixture.SearchService.TableSearch_Info(fieldId, str).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToList();


            Assert.Equal(expectedId, media?.Media_DynamicId);
            Assert.NotEmpty(media?.DynamicMediaInformation);
            Assert.All(media?.DynamicMediaInformation, l => expectedInfo.Contains(l));
        }

        #endregion

        #region Media Single


        [Theory]
        [InlineData(0, "asd")] // DynamicFields doesnt exist
        [InlineData(1, "asd")] // DynamicFields exists, but no match
        [InlineData(2, "asd")] // DynamicFields exists, but no media has the field.
        [InlineData(6, "22")] // DynamicFields exists, value exists but doesnt match exactly
        public void Media_Single_NoMatch(int FieldId, string searchValue)
        {
            var media = _fixture.SearchService.TableSearch_Media(FieldId, searchValue);

            media.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1, "1", new[] { 1 })]
        [InlineData(6, "2", new[] { 1 })]
        [InlineData(6, "222", new[] { 2 })]
        [InlineData(16, "1", new[] { 1, 3, 5 })]
        public void Media_Single_Exact(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
            }
        }

        [Theory]
        [InlineData(10, "my", new[] { 1, 2 })]
        [InlineData(10, "time", new[] { 1 })]
        [InlineData(10, "B", new[] { 2, 3, 4 })] // case doesnt matter for search
        [InlineData(12, "i", new[] { 1, 2, 3, 4, 5 })] // anywhere in sentence works
        [InlineData(12, "is?", new[] { 2 })] // special characters
        [InlineData(12, "'", new[] { 2, 4 })] // sql string char
        [InlineData(12, "chain of command", new[] { 2 })] // multiple words
        public void Media_Single_Contains(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
            }
        }

        [Theory]
        [InlineData(1, "1", 1)]
        [InlineData(10, "time", 1)]
        public void Media_Single_HasDynamicInformation(int fieldId, string str, int expectedId)
        {
            var media = _fixture.SearchService.TableSearch_Media(fieldId, str).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToList();


            Assert.Equal(expectedId, media?.Media_DynamicId);
            Assert.NotEmpty(media.DynamicMediaInformation);
            Assert.All(media?.DynamicMediaInformation, l => expectedInfo.Contains(l));
        }
        #endregion

        #region Media Dictionary


        [Theory]
        [MemberData(nameof(NoMatch_TestCases))]
        public void Media_Multi_NoMatch(Dictionary<int, string> searchFields)
        {
            var media = _fixture.SearchService.TableSearch_Media(searchFields, false);

            Assert.Empty(media);
        }


        [Theory]
        [MemberData(nameof(Exact_TestCases))]
        public void Media_Multi_Exact(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
                foreach (var info in item.DynamicMediaInformation)
                {
                    Assert.NotEmpty(info.Value);
                }
            }
        }

        [Theory]
        [MemberData(nameof(Contains_TestCases))]
        public void Media_Multi_Contains(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
                foreach (var info in item.DynamicMediaInformation)
                {
                    Assert.NotEmpty(info.Value);
                }
            }
        }



        [Theory]
        [MemberData(nameof(Any_TestCases))]
        public void Media_Multi_Any(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
                foreach (var info in item.DynamicMediaInformation)
                {
                    Assert.NotEmpty(info.Value);
                }
            }
        }


        [Theory]
        [MemberData(nameof(HasDynamicInformation_TestCases))]
        public void Media_Multi_HasDynamicInformation(Dictionary<int, string> searchFields, int expectedId)
        {
            var media = _fixture.SearchService.TableSearch_Media(searchFields).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToList();

            Assert.Equal(expectedId, media?.Media_DynamicId);
            Assert.NotEmpty(media?.DynamicMediaInformation);
            Assert.All(media?.DynamicMediaInformation, l => expectedInfo.Contains(l));
            foreach (var info in media.DynamicMediaInformation)
            {
                Assert.NotEmpty(info.Value);
            }
        }

        #endregion

        #region Media Dictionary no columns

        [Theory]
        [MemberData(nameof(NoMatch_TestCases))]
        public void Media_NoColumns_NoMatch(Dictionary<int, string> searchFields)
        {
            var media = _fixture.SearchService.TableSearch_Media_NoColumns(searchFields, false);

            Assert.Empty(media);
        }


        [Theory]
        [MemberData(nameof(Exact_TestCases))]
        public void Media_NoColumns_Exact(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media_NoColumns(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.Empty(item.DynamicMediaInformation);
            }
        }

        [Theory]
        [MemberData(nameof(Contains_TestCases))]
        public void Media_NoColumns_Contains(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media_NoColumns(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.Empty(item.DynamicMediaInformation);
            }
        }


        [Theory]
        [MemberData(nameof(Any_TestCases))]
        public void Media_NoColumns_Any(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media_NoColumns(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.Empty(item.DynamicMediaInformation);
            }
        }


        [Theory]
        [MemberData(nameof(HasDynamicInformation_TestCases))]
        public void Media_NoColumns_HasNoDynamicInformation(Dictionary<int, string> searchFields, int expectedId)
        {
            var media = _fixture.SearchService.TableSearch_Media_NoColumns(searchFields).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToList();

            Assert.Equal(expectedId, media?.Media_DynamicId);
            Assert.Empty(media?.DynamicMediaInformation);
        }

        #endregion

        #region Media Dictionary split queries

        [Theory]
        [MemberData(nameof(NoMatch_TestCases))]
        public void MediaSplit_Multi_NoMatch(Dictionary<int, string> searchFields)
        {
            var media = _fixture.SearchService.TableSearch_Media_SplitQuery(searchFields, false);

            Assert.Empty(media);
        }



        [Theory]
        [MemberData(nameof(Exact_TestCases))]
        public void MediaSplit_Multi_Exact(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media_SplitQuery(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
                foreach (var info in item.DynamicMediaInformation)
                {
                    Assert.NotEmpty(info.Value);
                }
            }
        }


        [Theory]
        [MemberData(nameof(Contains_TestCases))]
        public void MediaSplit_Multi_Contains(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media_SplitQuery(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
                foreach (var info in item.DynamicMediaInformation)
                {
                    Assert.NotEmpty(info.Value);
                }
            }
        }

        [Theory]
        [MemberData(nameof(Any_TestCases))]
        public void MediaSplit_Multi_Any(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media_SplitQuery(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
                foreach (var info in item.DynamicMediaInformation)
                {
                    Assert.NotEmpty(info.Value);
                }
            }
        }


        [Theory]
        [MemberData(nameof(HasDynamicInformation_TestCases))]
        public void MediaSplit_Multi_HasDynamicInformation(Dictionary<int, string> searchFields, int expectedId)
        {
            var media = _fixture.SearchService.TableSearch_Media_SplitQuery(searchFields).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToList();

            Assert.Equal(expectedId, media?.Media_DynamicId);
            Assert.NotEmpty(media?.DynamicMediaInformation);
            Assert.All(media?.DynamicMediaInformation, l => expectedInfo.Contains(l));
            foreach (var info in media.DynamicMediaInformation)
            {
                Assert.NotEmpty(info.Value);
            }
        }

        #endregion

        #region Media Dictionary two queries

        [Theory]
        [MemberData(nameof(NoMatch_TestCases))]
        public void Media2_Multi_NoMatch(Dictionary<int, string> searchFields)
        {
            var media = _fixture.SearchService.TableSearch_Media_TwoQueries(searchFields, false);

            Assert.Empty(media);
        }



        [Theory]
        [MemberData(nameof(Exact_TestCases))]
        public void Media2_Multi_Exact(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media_TwoQueries(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
                foreach (var info in item.DynamicMediaInformation)
                {
                    Assert.NotEmpty(info.Value);
                }
            }
        }


        [Theory]
        [MemberData(nameof(Contains_TestCases))]
        public void Media2_Multi_Contains(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media_TwoQueries(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
                foreach (var info in item.DynamicMediaInformation)
                {
                    Assert.NotEmpty(info.Value);
                }
            }
        }

        [Theory]
        [MemberData(nameof(Any_TestCases))]
        public void Media2_Multi_Any(Dictionary<int, string> searchFields, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media_TwoQueries(searchFields);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
            foreach (var item in media)
            {
                Assert.NotEmpty(item.DynamicMediaInformation);
                foreach (var info in item.DynamicMediaInformation)
                {
                    Assert.NotEmpty(info.Value);
                }
            }
        }


        [Theory]
        [MemberData(nameof(HasDynamicInformation_TestCases))]
        public void Media2_Multi_HasDynamicInformation(Dictionary<int, string> searchFields, int expectedId)
        {
            var media = _fixture.SearchService.TableSearch_Media_TwoQueries(searchFields).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToList();

            Assert.Equal(expectedId, media?.Media_DynamicId);
            Assert.NotEmpty(media?.DynamicMediaInformation);
            Assert.All(media?.DynamicMediaInformation, l => expectedInfo.Contains(l));
            foreach (var info in media.DynamicMediaInformation)
            {
                Assert.NotEmpty(info.Value);
            }
        }

        #endregion

        #endregion

        #region bad data

        [Fact]
        public void SearchJsonWithBadData()
        {
            foreach (var naughtyString in TheNaughtyStrings.SQLInjection)
            {
                var expectedCount = _fixture.Context.Media_Json.Count();
                var badSearch = new Dictionary<int, string>() { { 10, naughtyString } };

                _fixture.SearchService.JsonSearch_Indexed(badSearch, false);

                Assert.Equal(expectedCount, _fixture.Context.Media_Json.Count());
            }
        }


        [Fact]
        public void SearchMediaWithBadData()
        {
            foreach (var naughtyString in TheNaughtyStrings.SQLInjection)
            {
                var expectedCount = _fixture.Context.Media_Dynamic.Count();
                var badSearch = new Dictionary<int, string>() { { 10, naughtyString } };

                _fixture.SearchService.TableSearch_Media(badSearch, false);

                Assert.Equal(expectedCount, _fixture.Context.Media_Dynamic.Count());
            }
        }

        [Fact]
        public void SearchJsonWithCustomBadData()
        {
            foreach (var naughtyString in SQLInjectionJson)
            {
                var expectedCount = _fixture.Context.Media_Json.Count();
                var badSearch = new Dictionary<int, string>() { { 10, naughtyString } };

                _fixture.SearchService.JsonSearch_Indexed(badSearch, false);

                Assert.Equal(expectedCount, _fixture.Context.Media_Json.Count());
            }
        }

        [Fact]
        public void SearchMediaWithCustomBadData()
        {
            foreach (var naughtyString in SQLInjectionMedia)
            {
                var expectedCount = _fixture.Context.Media_Dynamic.Count();
                var badSearch = new Dictionary<int, string>() { { 10, naughtyString } };

                _fixture.SearchService.TableSearch_Media(badSearch, false);

                Assert.Equal(expectedCount, _fixture.Context.Media_Dynamic.Count());
            }
        }

        #endregion

    }

}
