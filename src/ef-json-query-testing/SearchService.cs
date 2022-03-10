﻿using ef_json_query_testing.Enums;
using ef_json_query_testing.Models;
using ef_json_query_testing.Translators;
using Microsoft.EntityFrameworkCore;

namespace ef_json_query_testing
{
    public class SearchService : ISearchService
    {
        private readonly EfTestDbContext _context;

        public SearchService(EfTestDbContext context)
        {
            _context = context;
        }

        #region JSON

        public List<Media_Json> JsonSearch_Raw(int DynamicFieldId, string value)
        {
            var field = _context.DynamicFields.AsNoTracking().FirstOrDefault(f => f.DynamicFieldId == DynamicFieldId);
            if (field == null)
            {
                return new List<Media_Json>();
            }

            // FromSqlInterpolated allows for use of string interpolation but it is handled in a way to avoid sql injection.
            var jsonPath = $"$.\"{field.JsonName}\"";

            if (field.DataType == DataTypes.StringValue)
            {
                var containsString = "%" + value + "%";
                return _context.Media_Json
                    .FromSqlInterpolated($"SELECT * FROM [dbo].[Media_Json] WHERE JSON_VALUE([Details], {jsonPath}) LIKE {containsString}")
                    .AsNoTracking()
                    .ToList();
            }
            else
            {
                return _context.Media_Json
                    .FromSqlInterpolated($"SELECT * FROM [dbo].[Media_Json] WHERE JSON_VALUE([Details], {jsonPath}) = {value}")
                    .AsNoTracking()
                    .ToList();
            }
        }


        public List<Media_Json> JsonSearch_Raw(Dictionary<int, string> searchFields)
        {
            if (searchFields == null || !searchFields.Any())
            {
                return new List<Media_Json>();
            }

            var fieldList = _context.DynamicFields.AsNoTracking().ToList();

            var sqlStatement = "SELECT * FROM [dbo].[Media_Json] WHERE 1=1 ";

            var count = 0;
            var parameters = new List<object>();
            foreach (var searchField in searchFields)
            {
                var field = fieldList.FirstOrDefault(f => f.DynamicFieldId == searchField.Key);
                if (field == null)
                {
                    continue;
                }

                parameters.Add($"$.\"{field.JsonName}\"");
                sqlStatement += $" AND JSON_VALUE([Details], {{{count}}}) ";
                count++;

                if (field.DataType == DataTypes.StringValue)
                {
                    var containsString = "%" + searchField.Value + "%";
                    parameters.Add(containsString);
                    sqlStatement += $" LIKE {{{count}}}";
                }
                else
                {
                    parameters.Add(searchField.Value);
                    sqlStatement += $" = {{{count}}}";
                }

                count++;
            }

            return _context.Media_Json
                .FromSqlRaw(sqlStatement, parameters.ToArray())
                .AsNoTracking()
                .ToList();
        }



        public List<Media_Json> JsonSearch_EfMagic(int DynamicFieldId, string value)
        {
            var field = _context.DynamicFields
                .AsNoTracking()
                .FirstOrDefault(f => f.DynamicFieldId == DynamicFieldId);

            if (field == null)
            {
                return new List<Media_Json>();
            }

            var jsonPath = $"$.\"{field.JsonName}\"";
            if (field.DataType == DataTypes.StringValue)
            {
                return _context.Media_Json
                    .AsNoTracking()
                    .Where(m => EF.Functions.JsonValue(m.Details, jsonPath).Contains(value))
                    .ToList();
            }
            else
            {
                return _context.Media_Json
                    .AsNoTracking()
                    .Where(m => EF.Functions.JsonValue(m.Details, jsonPath) == value)
                    .ToList();
            }
        }

        public List<Media_Json> JsonSearch_EfMagic(Dictionary<int, string> searchFields)
        {
            if (searchFields == null || !searchFields.Any())
            {
                return new List<Media_Json>();
            }

            var fieldList = _context.DynamicFields.AsNoTracking().ToList();
            var query = _context.Media_Json.AsNoTracking().AsQueryable();
            foreach (var searchField in searchFields)
            {
                var field = fieldList.FirstOrDefault(f => f.DynamicFieldId == searchField.Key);
                if (field == null)
                {
                    continue;
                }

                var jsonPath = $"$.\"{field.JsonName}\"";
                if (field.DataType == DataTypes.StringValue)
                {
                    query = query.Where(q => EF.Functions.JsonValue(q.Details, jsonPath).Contains(searchField.Value));
                }
                else
                {
                    query = query.Where(q => EF.Functions.JsonValue(q.Details, jsonPath) == searchField.Value);
                }
            }

            return query.ToList();
        }

        #endregion


        #region Dynamic Table Store

        public List<Media_Dynamic> TableSearch_Info(int DynamicFieldId, string value)
        {
            var field = _context.DynamicFields
                .AsNoTracking()
                .FirstOrDefault(f => f.DynamicFieldId == DynamicFieldId);

            if (field == null)
            {
                return new List<Media_Dynamic>();
            }

            //change search based on data type
            var ids = new List<int>();
            if (DataTypes.StringValue == field.DataType)
            {
                // contains search
                ids = _context.DynamicMediaInformation
                    .AsNoTracking()
                    .Where(d => d.FieldId == DynamicFieldId && d.Value.Contains(value))
                    .Select(d => d.MediaId)
                    .ToList();
            }
            else
            {
                // exact match search
                ids = _context.DynamicMediaInformation
                    .AsNoTracking()
                    .Where(d => d.FieldId == DynamicFieldId && d.Value.Equals(value))
                    .Select(d => d.MediaId)
                    .ToList();
            }

            return _context.Media_Dynamic
                .AsNoTracking()
                .Include(m => m.DynamicMediaInformation)
                .Where(m => ids.Contains(m.Media_DynamicId))
                .ToList();
        }

        public List<Media_Dynamic> TableSearch_Media(int DynamicFieldId, string value)
        {
            var field = _context.DynamicFields.AsNoTracking().FirstOrDefault(f => f.DynamicFieldId == DynamicFieldId);

            if (field == null)
            {
                return new List<Media_Dynamic>();
            }

            //change search based on data type
            if (DataTypes.StringValue == field.DataType)
            {
                // contains search
                return _context.Media_Dynamic
                    .AsNoTracking()
                    .Include(d => d.DynamicMediaInformation)
                    .Where(d => d.DynamicMediaInformation.FirstOrDefault(i => i.FieldId == DynamicFieldId && i.Value.Contains(value)) != null)
                    .ToList();
            }
            else
            {
                // exact match search
                return _context.Media_Dynamic
                    .AsNoTracking()
                    .Include(d => d.DynamicMediaInformation)
                    .Where(d => d.DynamicMediaInformation.FirstOrDefault(i => i.FieldId == DynamicFieldId && i.Value.Equals(value)) != null)
                    .ToList();
            }
        }


        public List<Media_Dynamic> TableSearch_Media(Dictionary<int, string> searchFields)
        {
            if (searchFields == null || !searchFields.Any())
            {
                return new List<Media_Dynamic>();
            }

            var fieldList = _context.DynamicFields.AsNoTracking().ToList();
            var query = _context.Media_Dynamic.AsNoTracking().Include(d => d.DynamicMediaInformation).AsQueryable();
            foreach (var searchField in searchFields)
            {
                var field = fieldList.FirstOrDefault(f => f.DynamicFieldId == searchField.Key);
                if (field == null)
                {
                    continue;
                }
                var jsonPath = $"$.\"{field.JsonName}\"";
                if (field.DataType == DataTypes.StringValue)
                {
                    query = query.Where(m => m.DynamicMediaInformation.Any(i => i.FieldId == field.DynamicFieldId && i.Value.Contains(searchField.Value)));
                }
                else
                {
                    query = query.Where(m => m.DynamicMediaInformation.Any(i => i.FieldId == field.DynamicFieldId && i.Value == searchField.Value));
                }
            }

            return query.ToList();
        }

        #endregion
    }

    public interface ISearchService
    {
        List<Media_Json> JsonSearch_Raw(int DynamicFieldId, string value);
        List<Media_Json> JsonSearch_Raw(Dictionary<int, string> searchFields);

        List<Media_Json> JsonSearch_EfMagic(int DynamicFieldId, string value);
        List<Media_Json> JsonSearch_EfMagic(Dictionary<int, string> searchFields);


        List<Media_Dynamic> TableSearch_Info(int DynamicFieldId, string value);

        List<Media_Dynamic> TableSearch_Media(int DynamicFieldId, string value);
        List<Media_Dynamic> TableSearch_Media(Dictionary<int, string> searchFields);
    }
}
