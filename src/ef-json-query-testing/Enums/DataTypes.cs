using System.Data;

namespace ef_json_query_testing.Enums
{
    public enum DataTypes
    {
        IntValue = 0, // exact match
        StringValue = 1, // contains match
        BoolValue = 2, // exact match
        DateTimeValue = 3, //??
        DecimalValue = 4, //??
        //ListSingleValue = 5, // exact
    }

    static class DataTypesExtensions
    {
        public static string GetSqlType(this DataTypes dataType, int maxStringLength)
        {
            switch (dataType)
            {
                case DataTypes.IntValue: return "INT";
                case DataTypes.StringValue: return $"VARCHAR({maxStringLength})";
                case DataTypes.BoolValue: return "BIT";
                case DataTypes.DateTimeValue: return "datetime2";
                case DataTypes.DecimalValue: return "DECIMAL(14, 4)";
                default: throw new ArgumentOutOfRangeException("dataType");
            }
        }

        public static SqlDbType GetSqlType(this DataTypes dataType)
        {
            switch (dataType)
            {
                case DataTypes.IntValue: return SqlDbType.Int;
                case DataTypes.StringValue: return SqlDbType.VarChar; // $"VARCHAR({maxStringLength})";
                case DataTypes.BoolValue: return SqlDbType.Bit;
                case DataTypes.DateTimeValue: return SqlDbType.DateTime2;
                case DataTypes.DecimalValue: return SqlDbType.Decimal; // "DECIMAL(14, 4)";
                default: throw new ArgumentOutOfRangeException("dataType");
            }
        }
    }
}
