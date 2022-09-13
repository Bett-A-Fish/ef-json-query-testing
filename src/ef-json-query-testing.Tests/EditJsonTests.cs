using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace ef_json_query_testing.Tests
{
    [Collection("Database collection")]
    public class EditJsonTests
    {
        private DatabaseFixture _fixture;

        public EditJsonTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldUpdateExpectedField()
        {
            var item = _fixture.Context.Media_Json.FirstOrDefault();
            var originalDict = item.Details.ToDictionary(k => k.Key, k => k.Value);
            var changeField = _fixture.Context.DynamicFields.FirstOrDefault(d => d.IsRequired && d.DataType == Enums.DataTypes.IntValue);
            var detailEditKey = changeField.DynamicFieldId.ToString();
            var foundValue = originalDict.TryGetValue(detailEditKey, out var originalValue);

            if (!foundValue)
            {
                throw new Exception("Did not find required detail");
            }

            var expectedValue = int.Parse((string)originalValue) + 5;
            item.Details[detailEditKey] = expectedValue.ToString();

            _fixture.Context.Entry(item).State = EntityState.Modified;
            _fixture.Context.SaveChanges();


            var savedItem = _fixture.Context.Media_Json.FirstOrDefault(j => j.Media_JsonId == item.Media_JsonId);
            var savedDict = savedItem.Details.ToDictionary(k => k.Key, k => k.Value);
            var foundSavedValue = savedItem.Details.TryGetValue(detailEditKey, out var savedValue);
            Assert.True(foundSavedValue);
            Assert.Equal(expectedValue.ToString(), savedValue.ToString());

            originalDict.Remove(detailEditKey);
            savedDict.Remove(detailEditKey);
            originalDict.Should().BeEquivalentTo(savedDict);
        }


        [Fact]
        public void ShouldUpdateExpectedFields()
        {
            var item = _fixture.Context.Media_Json.FirstOrDefault();
            var originalDict = item.Details.ToDictionary(k => k.Key, k => k.Value);

            var fields = originalDict.Select(o => o.Key);
            var existingFields = _fixture.Context.DynamicFields.Where(d => fields.Contains(d.DynamicFieldId.ToString()));


            var intFieldId = existingFields.FirstOrDefault(e => e.DataType == Enums.DataTypes.IntValue).DynamicFieldId.ToString();
            var newInt = int.Parse(item.Details[intFieldId].ToString()) + 12;
            item.Details[intFieldId] = newInt;

            var stringFieldId = existingFields.FirstOrDefault(e => e.DataType == Enums.DataTypes.StringValue).DynamicFieldId.ToString();
            var newString = item.Details[stringFieldId].ToString() + " MORE TEXT";
            item.Details[stringFieldId] = newString;

            var boolFieldId = existingFields.FirstOrDefault(e => e.DataType == Enums.DataTypes.BoolValue).DynamicFieldId.ToString();
            var newBool = int.Parse(item.Details[boolFieldId].ToString()) == 0 ? 1 : 0; // flip bit
            item.Details[boolFieldId] = newBool;

            var dateFieldId = existingFields.FirstOrDefault(e => e.DataType == Enums.DataTypes.DateTimeValue).DynamicFieldId.ToString();
            var newDate = DateTime.Parse(item.Details[dateFieldId].ToString()).AddDays(5);
            item.Details[dateFieldId] = newDate;


            _fixture.Context.Entry(item).State = EntityState.Modified;
            _fixture.Context.SaveChanges();




            var savedItem = _fixture.Context.Media_Json.FirstOrDefault(j => j.Media_JsonId == item.Media_JsonId);
            var savedDict = savedItem.Details.ToDictionary(k => k.Key, k => k.Value);


            var foundSavedInt = savedItem.Details.TryGetValue(intFieldId, out var savedIntValue);
            Assert.True(foundSavedInt);
            Assert.Equal(newInt.ToString(), savedIntValue.ToString());

            var foundSavedString = savedItem.Details.TryGetValue(stringFieldId, out var savedStringValue);
            Assert.True(foundSavedString);
            Assert.Equal(newString.ToString(), savedStringValue.ToString());

            var foundSavedBool = savedItem.Details.TryGetValue(boolFieldId, out var savedBoolValue);
            Assert.True(foundSavedBool);
            Assert.Equal(newBool.ToString(), savedBoolValue.ToString());

            var foundSavedDate = savedItem.Details.TryGetValue(dateFieldId, out var savedDateValue);
            Assert.True(foundSavedDate);
            Assert.Equal(newDate.ToString(), savedDateValue.ToString());


            originalDict.Remove(intFieldId);
            originalDict.Remove(stringFieldId);
            originalDict.Remove(boolFieldId);
            originalDict.Remove(dateFieldId);
            savedDict.Remove(intFieldId);
            savedDict.Remove(stringFieldId);
            savedDict.Remove(boolFieldId);
            savedDict.Remove(dateFieldId);

            originalDict.Should().BeEquivalentTo(savedDict);
        }



        [Fact]
        public void ShouldRemoveExpectedField()
        {
            var item = _fixture.Context.Media_Json.FirstOrDefault();
            var originalDict = item.Details.ToDictionary(k => k.Key, k => k.Value);
            var changeField = _fixture.Context.DynamicFields.FirstOrDefault(d => d.IsRequired && d.DataType == Enums.DataTypes.IntValue);
            var detailEditKey = changeField.DynamicFieldId.ToString();
            var foundValue = originalDict.TryGetValue(detailEditKey, out var _);

            if (!foundValue)
            {
                throw new Exception("Did not find required detail");
            }

            item.Details.Remove(detailEditKey);

            _fixture.Context.Entry(item).State = EntityState.Modified;
            _fixture.Context.SaveChanges();


            var savedItem = _fixture.Context.Media_Json.FirstOrDefault(j => j.Media_JsonId == item.Media_JsonId);
            var savedDict = savedItem.Details.ToDictionary(k => k.Key, k => k.Value);
            var foundSavedValue = savedItem.Details.TryGetValue(detailEditKey, out var _);
            Assert.False(foundSavedValue);

            originalDict.Remove(detailEditKey);
            originalDict.Should().BeEquivalentTo(savedDict);
        }
    }
}
