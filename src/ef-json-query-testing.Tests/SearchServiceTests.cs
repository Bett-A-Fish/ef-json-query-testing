using FluentAssertions;
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

        #region Json

        #region Raw Single
                
        
        [Theory]
        [InlineData(0, "asd")] // DynamicFields doesnt exist
        [InlineData(1, "asd")] // DynamicFields exsits, but no match
        [InlineData(2, "asd")] // DynamicFields exists, but no media has the field.
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
        }

        [Theory]
        [InlineData(10, "my", new[] { 1, 2 })]
        [InlineData(10, "time", new[] { 1 })]
        [InlineData(10, "B", new[] { 2, 3, 4 })] // case doesnt matter for search
        [InlineData(12, "i", new[] { 1, 2, 3, 4, 5 })] // anywhere in sentence works
        [InlineData(12, "is?", new[] { 2 })] // special charecers
        [InlineData(12, "'", new[] { 2, 4 })] // sql string char
        [InlineData(12, "chain of command", new[] { 2 })] // multiple words
        public void Raw_Single_Contains(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.JsonSearch_Raw(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
        }

        [Theory]
        [InlineData(1, "1", 1)]
        [InlineData(10, "time", 1 )]
        public void Raw_Single_HasDynamicInformation(int fieldId, string str, int expectedId)
        {
            var media = _fixture.SearchService.JsonSearch_Raw(fieldId, str).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId ).ToDictionary(i => i.Field.JsonName, i => (object)i.Value);


            Assert.Equal(expectedId, media?.Media_JsonId);
            Assert.All(media?.Details, l => expectedInfo.Contains(l));
        }

        #endregion

        #region Raw Dictionary

        #endregion

        #region Magic Single


        [Theory]
        [InlineData(0, "asd")] // DynamicFields doesnt exist
        [InlineData(1, "asd")] // DynamicFields exsits, but no match
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
        }

        [Theory]
        [InlineData(10, "my", new[] { 1, 2 })]
        [InlineData(10, "time", new[] { 1 })]
        [InlineData(10, "B", new[] { 2, 3, 4 })] // case doesnt matter for search
        [InlineData(12, "i", new[] { 1, 2, 3, 4, 5 })] // anywhere in sentence works
        [InlineData(12, "is?", new[] { 2 })] // special charecers
        [InlineData(12, "'", new[] { 2, 4 })] // sql string char
        [InlineData(12, "chain of command", new[] { 2 })] // multiple words
        public void Magic_Single_Contains(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.JsonSearch_EfMagic(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_JsonId).ToArray());
        }

        [Theory]
        [InlineData(1, "1", 1)]
        [InlineData(10, "time", 1)]
        public void Magic_Single_HasDynamicInformation(int fieldId, string str, int expectedId)
        {
            var media = _fixture.SearchService.JsonSearch_EfMagic(fieldId, str).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToDictionary(i => i.Field.JsonName, i => (object)i.Value);


            Assert.Equal(expectedId, media?.Media_JsonId);
            Assert.All(media?.Details, l => expectedInfo.Contains(l));
        }

        #endregion

        #region Magic Dictionary
        #endregion

        #endregion

        #region Table

        #region Info Single


        [Theory]
        [InlineData(0, "asd")] // DynamicFields doesnt exist
        [InlineData(1, "asd")] // DynamicFields exsits, but no match
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
        }

        [Theory]
        [InlineData(10, "my", new[] { 1, 2 })]
        [InlineData(10, "time", new[] { 1 })]
        [InlineData(10, "B", new[] { 2, 3, 4 })] // case doesnt matter for search
        [InlineData(12, "i", new[] { 1, 2, 3, 4, 5 })] // anywhere in sentence works
        [InlineData(12, "is?", new[] { 2 })] // special charecers
        [InlineData(12, "'", new[] { 2, 4 })] // sql string char
        [InlineData(12, "chain of command", new[] { 2 })] // multiple words
        public void Info_Single_Contains(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Info(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
        }

        [Theory]
        [InlineData(1, "1", 1)]
        [InlineData(10, "time", 1)]
        public void Info_Single_HasDynamicInformation(int fieldId, string str, int expectedId)
        {
            var media = _fixture.SearchService.TableSearch_Info(fieldId, str).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToList();


            Assert.Equal(expectedId, media?.Media_DynamicId);
            Assert.All(media?.DynamicMediaInformation, l => expectedInfo.Contains(l));
        }
        #endregion

        #region Media Single


        [Theory]
        [InlineData(0, "asd")] // DynamicFields doesnt exist
        [InlineData(1, "asd")] // DynamicFields exsits, but no match
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
        }

        [Theory]
        [InlineData(10, "my", new[] { 1, 2 })]
        [InlineData(10, "time", new[] { 1 })]
        [InlineData(10, "B", new[] { 2, 3, 4 })] // case doesnt matter for search
        [InlineData(12, "i", new[] { 1, 2, 3, 4, 5 })] // anywhere in sentence works
        [InlineData(12, "is?", new[] { 2 })] // special charecers
        [InlineData(12, "'", new[] { 2, 4 })] // sql string char
        [InlineData(12, "chain of command", new[] { 2 })] // multiple words
        public void Media_Single_Contains(int fieldId, string str, int[] expectedIds)
        {
            var media = _fixture.SearchService.TableSearch_Media(fieldId, str);

            Assert.Equal(expectedIds.Count(), media.Count());
            Assert.Equal(expectedIds, media.Select(m => m.Media_DynamicId).ToArray());
        }

        [Theory]
        [InlineData(1, "1", 1)]
        [InlineData(10, "time", 1)]
        public void Media_Single_HasDynamicInformation(int fieldId, string str, int expectedId)
        {
            var media = _fixture.SearchService.TableSearch_Media(fieldId, str).FirstOrDefault();
            var expectedInfo = _fixture.Context.DynamicMediaInformation.Where(i => i.MediaId == expectedId).ToList();


            Assert.Equal(expectedId, media?.Media_DynamicId);
            Assert.All(media?.DynamicMediaInformation, l => expectedInfo.Contains(l));
        }
        #endregion

        #region Media Dictionary
        #endregion

        #endregion

    }
}
