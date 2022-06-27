﻿using Bogus;
using ef_json_query_testing.Enums;
using ef_json_query_testing.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

// DynamicListTypes - types of list dropdowns 
// DynamicListItems - the items available for each list type
// DynamicFields - list of additional fields a media item can have
// Media_Dynamic - media item with no json, linked to use DynamicMediaInformation

// Media_Json - uses a json field to store all additional fields.

// DynamicMediaInformation - each saved field for a given media item


namespace ef_json_query_testing.Seeders
{
    public static class CreateBogusData
    {
        private const int _ListItemCount_Min = 3;
        private const int _ListItemCount_Max = 20;

        private const int _Media_Dynamic_CreatedDayRange = 10;
        private const int _Media_Dynamic_FileSize_Max = 2097152;
        private const int _Media_Dynamic_FileWidth_Min = 256;
        private const int _Media_Dynamic_FileWidth_Max = 8192;
        private const int _Media_Dynamic_FileHeight_Min = 256;
        private const int _Media_Dynamic_FileHeight_Max = 4096;

        private const int _MaxStringLength = 500;

        private const int FakerSeed = 42;

        public static void LoadAllData(EfTestDbContext context, int fieldsCount = 30, int mediaItemsCount = 500, int listTypeCount = 5)
        {
            Randomizer.Seed = new Random(FakerSeed);
            LoadSharedData(context, fieldsCount, listTypeCount);

            LoadMediaData(context, mediaItemsCount);
        }

        // using halfFieldCount for how many fields should be made for optional and required groups (20 will end up with 40 total fields)
        public static void LoadAllData_StringOnly(EfTestDbContext context, int mediaItemsCount = 500, int halfFieldCount = 20)
        {
            Randomizer.Seed = new Random(FakerSeed);
            LoadSharedData_StringOnly(context, halfFieldCount);

            LoadMediaData(context, mediaItemsCount);
        }

        public static void LoadSharedData(EfTestDbContext context, int fieldsCount = 30, int listTypeCount = 5)
        {
            LoadDynamicListTypes(context, listTypeCount);

            var randomFields = FakerDynamicField.Generate(fieldsCount);
            context.DynamicFields.AddRange(randomFields);
            context.SaveChanges();

            foreach (var field in randomFields)
            {
                AddJsonIndex(context, field.DynamicFieldId.ToString(), field.DataType);
            }
        }

        public static void LoadSharedData_StringOnly(EfTestDbContext context, int halfFieldCount = 20)
        {
            var randomFields = FakerDynamicField_StringRequired.Generate(halfFieldCount);
            randomFields.AddRange(FakerDynamicField_StringOptional.Generate(halfFieldCount));

            context.DynamicFields.AddRange(randomFields);
            context.SaveChanges();

            foreach (var field in randomFields)
            {
                AddJsonIndex(context, field.DynamicFieldId.ToString(), field.DataType);
            }
        }

        public static void LoadMediaData(EfTestDbContext context, int mediaItemsCount = 1000)
        {
            context.Media_Dynamic.AddRange(FakerMedia_Dynamic.Generate(mediaItemsCount));
            context.SaveChanges();


            LoadMediaInformation(context);

            LoadMediaJson(context);
        }

        public static void LoadMediaDataLarge(EfTestDbContext context, int mediaItemsCount = 1000)
        {
            context.Media_Dynamic.AddRange(FakerMedia_Dynamic.Generate(mediaItemsCount));
            context.SaveChanges();


            LoadMediaInformationLarge(context);

            LoadMediaJson(context);
        }

        public static Faker<DynamicField> FakerDynamicField => new Faker<DynamicField>()
            .RuleFor(d => d.DisplayName, f => string.Join(" ", f.Lorem.Words()))
            .RuleFor(d => d.IsQueryable, f => f.Random.Bool())
            .RuleFor(d => d.IsRequired, f => f.Random.Bool())
            .RuleFor(d => d.Description, f => f.Lorem.Paragraph())
            .RuleFor(d => d.DataType, f => f.Random.Enum<DataTypes>());


        public static Faker<DynamicField> FakerDynamicField_StringRequired => new Faker<DynamicField>()
            .RuleFor(d => d.DisplayName, f => string.Join(" ", f.Lorem.Words()))
            .RuleFor(d => d.IsQueryable, f => f.Random.Bool())
            .RuleFor(d => d.IsRequired, f => true)
            .RuleFor(d => d.Description, f => f.Lorem.Paragraph())
            .RuleFor(d => d.DataType, f => DataTypes.StringValue);


        public static Faker<DynamicField> FakerDynamicField_StringOptional => new Faker<DynamicField>()
            .RuleFor(d => d.DisplayName, f => string.Join(" ", f.Lorem.Words()))
            .RuleFor(d => d.IsQueryable, f => f.Random.Bool())
            .RuleFor(d => d.IsRequired, f => false)
            .RuleFor(d => d.Description, f => f.Lorem.Paragraph())
            .RuleFor(d => d.DataType, f => DataTypes.StringValue);

        public static Faker<Media_Dynamic> FakerMedia_Dynamic => new Faker<Media_Dynamic>()
            .RuleFor(m => m.OriginalFileName, f => f.System.FileName())
            .RuleFor(m => m.FilePath, f => f.System.DirectoryPath())
            .RuleFor(m => m.CreatedDate, f => f.Date.Recent(_Media_Dynamic_CreatedDayRange))
            .RuleFor(m => m.FileSize, f => f.Random.Number(_Media_Dynamic_FileSize_Max))
            .RuleFor(m => m.FileWidth, (f, m) => f.Random.Bool() ? f.Random.Number(_Media_Dynamic_FileWidth_Min, _Media_Dynamic_FileWidth_Max) : null)
            .RuleFor(m => m.FileHeight, (f, m) => m.FileWidth.HasValue ? f.Random.Number(_Media_Dynamic_FileHeight_Min, _Media_Dynamic_FileHeight_Max) : null)
            .RuleFor(m => m.Description, f => f.Lorem.Paragraph())
            .RuleFor(m => m.Hold, f => f.Random.Bool());

        private static void LoadDynamicListTypes(EfTestDbContext context, int listTypeCount)
        {
            // List types
            var faker = new Faker();

            var cats = faker.Commerce.Categories(listTypeCount);
            var dynamicListTypes = new List<DynamicListType>();
            foreach (var c in cats)
            {
                dynamicListTypes.Add(new DynamicListType(c));
            }

            context.DynamicListTypes.AddRange(dynamicListTypes);
            context.SaveChanges();

            // List items
            LoadDynamicListItems(context);

            // adding list fields for each list type.
            var dynamicFields = new List<DynamicField>();
            foreach (var t in dynamicListTypes)
            {
                var field = new DynamicField(t.DisplayName);
                field.IsQueryable = true;
                field.IsRequired = faker.Random.Bool();
                field.Description = faker.Lorem.Paragraph();
                field.DataType = DataTypes.IntValue;
                field.DynamicListTypeId = t.DynamicListTypeId;

                dynamicFields.Add(field);
            }

            context.DynamicFields.AddRange(dynamicFields);
            context.SaveChanges();

            foreach (var field in dynamicFields)
            {
                AddJsonIndex(context, field.DynamicFieldId.ToString(), field.DataType);
            }
        }

        private static void LoadDynamicListItems(EfTestDbContext context)
        {
            var faker = new Faker();
            var dynamicListItems = new List<DynamicListItem>();

            foreach (var t in context.DynamicListTypes.AsNoTracking())
            {
                var itemCount = faker.Random.Number(_ListItemCount_Min, _ListItemCount_Max);
                for (int j = 0; j < itemCount; j++)
                {
                    dynamicListItems.Add(new DynamicListItem(faker.Commerce.ProductName(), t.DynamicListTypeId));
                }
            }

            context.DynamicListItems.AddRange(dynamicListItems);
            context.SaveChanges();
        }

        public static void LoadMediaInformation(EfTestDbContext context)
        {
            var requiredFields = context.DynamicFields.AsNoTracking().Where(f => f.IsRequired).ToList();
            var optionalFields = context.DynamicFields.AsNoTracking().Where(f => !f.IsRequired).ToList();

            var listItemsCounts = GetListItemCounts(context);

            var faker = new Faker();
            var mediaItems = context.Media_Dynamic.ToList();
            foreach (var item in mediaItems)
            {
                var infoItems = new List<DynamicMediaInformation>();
                infoItems.AddRange(GenerateFieldValues(item, requiredFields, faker, listItemsCounts));

                var randomCount = faker.Random.Number(0, optionalFields.Count());
                infoItems.AddRange(GenerateFieldValues(item, faker.PickRandom(optionalFields, randomCount), faker, listItemsCounts));

                item.DynamicMediaInformation = infoItems;
            }

            context.SaveChanges();
        }

        public static void LoadMediaInformationLarge(EfTestDbContext context)
        {
            var requiredFields = context.DynamicFields.AsNoTracking().Where(f => f.IsRequired).ToList();
            var optionalFields = context.DynamicFields.AsNoTracking().Where(f => !f.IsRequired).ToList();

            var listItemsCounts = GetListItemCounts(context);
            var hasItems = true;
            while (hasItems)
            {

                GenerateMediaInformationGroup(context, requiredFields, listItemsCounts, optionalFields);
                hasItems = context.Media_Dynamic.AsNoTracking().Include(d => d.DynamicMediaInformation).FirstOrDefault(d => !d.DynamicMediaInformation.Any()) != null;
                Thread.Sleep(30000);// let cpu rest for a couple seconds. then do another batch.
            }
        }

        private static void GenerateMediaInformationGroup(EfTestDbContext context, List<DynamicField> requiredFields, Dictionary<int, int> listItemsCounts, List<DynamicField> optionalFields)
        {
            var faker = new Faker();
            var mediaItems = context.Media_Dynamic.AsNoTracking().Include(d => d.DynamicMediaInformation).OrderBy(d => d.Media_DynamicId).Take(10000).ToList();
            foreach (var item in mediaItems)
            {
                var infoItems = new List<DynamicMediaInformation>();
                infoItems.AddRange(GenerateFieldValues(item, requiredFields, faker, listItemsCounts));

                var randomCount = faker.Random.Number(0, optionalFields.Count());
                infoItems.AddRange(GenerateFieldValues(item, faker.PickRandom(optionalFields, randomCount), faker, listItemsCounts));

                item.DynamicMediaInformation = infoItems;
            }

            context.SaveChanges();
        }

        public static void LoadMediaJson(EfTestDbContext context)
        {
            var mediaItems = context.Media_Dynamic
                .AsNoTracking()
                .Include(d => d.DynamicMediaInformation)
                .ThenInclude(i => i.Field);

            using (context.Database.BeginTransaction())
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Media_Json] ON");
                var mediaJson = new List<Media_Json>();
                foreach (var item in mediaItems)
                {
                    mediaJson.Add(item.GetMediaJsonCopy(true));
                }

                context.Media_Json.AddRange(mediaJson);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Media_Json] OFF");

                context.Database.CommitTransaction();
            }
        }

        public static void LoadMediaJsonLarge(EfTestDbContext context)
        {
            var maxJsonId = context.Media_Json.AsNoTracking().Any() ? context.Media_Json.AsNoTracking().Max(j => j.Media_JsonId) : 0;
            var hasItems = context.Media_Dynamic.AsNoTracking().Max(d => d.Media_DynamicId) > maxJsonId;
            while (hasItems)
            {
                GenerateJson(context, maxJsonId);

                maxJsonId = context.Media_Json.AsNoTracking().Max(j => j.Media_JsonId);
                hasItems = context.Media_Dynamic.AsNoTracking().Max(d => d.Media_DynamicId) > maxJsonId;
                //Thread.Sleep(10000);// let cpu rest for a couple seconds. then do another batch.
            }
        }

        private static void GenerateJson(EfTestDbContext context, int maxJsonId)
        {
            var mediaItems = context.Media_Dynamic
                .AsNoTracking()
                .Include(d => d.DynamicMediaInformation)
                .ThenInclude(i => i.Field)
                .Where(d => d.Media_DynamicId > maxJsonId)
                .Take(10000)
                .ToList();

            using (context.Database.BeginTransaction())
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Media_Json] ON");
                var mediaJson = new List<Media_Json>();
                foreach (var item in mediaItems)
                {
                    mediaJson.Add(item.GetMediaJsonCopy(true));
                }

                context.Media_Json.AddRange(mediaJson);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Media_Json] OFF");

                context.Database.CommitTransaction();
            }
        }

        private static Dictionary<int, int> GetListItemCounts(EfTestDbContext context)
        {
            return context.DynamicListItems.AsNoTracking()
                .GroupBy(d => d.DynamicListTypeId)
                .Select(g => new { g.Key, Count = g.Count() })
                .ToDictionary(g => g.Key, g => g.Count);
        }

        private static List<DynamicMediaInformation> GenerateFieldValues(Media_Dynamic item, IEnumerable<DynamicField> fields, Faker faker, Dictionary<int, int> listItemsCounts)
        {
            var infoItems = new List<DynamicMediaInformation>();
            foreach (var field in fields)
            {
                string value;
                if (field.DynamicListTypeId.HasValue)
                {
                    listItemsCounts.TryGetValue(field.DynamicListTypeId.Value, out int maxCount);
                    value = faker.Random.Number(maxCount).ToString();
                }
                else
                {
                    value = GenerateFieldValue(field.DataType, faker);
                }

                infoItems.Add(new DynamicMediaInformation(
                                    item.Media_DynamicId,
                                    field.DynamicFieldId,
                                    value));
            }

            return infoItems;
        }

        public static string GenerateFieldValue(DataTypes dataType, Faker faker) => dataType switch
        {
            DataTypes.IntValue => faker.Random.Number(int.MaxValue).ToString(),
            DataTypes.StringValue => faker.Lorem.Text().Truncate(_MaxStringLength),
            DataTypes.BoolValue => faker.Random.Bool() ? "1" : "0",
            DataTypes.DateTimeValue => faker.Date.Between(DateTime.MinValue, DateTime.MaxValue).ToString("o", CultureInfo.InvariantCulture),
            DataTypes.DecimalValue => faker.Random.Decimal(0.0m, 9999999999.9999m).ToString(),
            _ => string.Empty
        };

        public static void AddJsonIndex(EfTestDbContext context, string keyName, DataTypes keyType, bool recreate = true)
        {
            //@keyName NVARCHAR(200), --json prop name
            //@keyType NVARCHAR(200), --sql type
            //@alias NVARCHAR(200), --what will be used to name the new index and column
            //@recreate BIT -- if pre-existing index/columns should be deleted and remade
            context.Database.ExecuteSqlRaw("stp_Add_Json_Index {0}, {1}, {2}, {3}", keyName, keyType.GetSqlType(_MaxStringLength), keyName, recreate);
        }

        public static void ReGenerateDateColumns(EfTestDbContext context)
        {
            var dateColumns = context.DynamicFields.Where(df => df.DataType == DataTypes.DateTimeValue).Select(df => df.DynamicFieldId).ToList();

            foreach (var item in context.Media_Dynamic.Include(m => m.DynamicMediaInformation).ToList())
            {
                foreach (var date in item.DynamicMediaInformation.Where(dm => dateColumns.Contains(dm.FieldId)).ToList())
                {
                    var parsedDate = DateTime.Parse(date.Value);
                    date.Value = parsedDate.ToString("o", CultureInfo.InvariantCulture);
                }
            }
            context.SaveChanges();

            foreach (var item in context.Media_Json)
            {
                foreach (var key in dateColumns)
                {
                    if (item.Details.ContainsKey(key.ToString()))
                    {
                        var parsedDate = DateTime.Parse(item.Details[key.ToString()].ToString());
                        item.Details[key.ToString()] = parsedDate.ToString("o", CultureInfo.InvariantCulture);
                    }
                }

                context.Entry(item).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }

    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            return value.Length > maxLength
                ? value.Substring(0, maxLength)
                : value;
        }
    }
}
