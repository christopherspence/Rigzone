using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rigzone.Common.Extensions
{
    public static class DataRowExtensions
    {
        public static int AsInt(this DataRow dataRow, string columnName)
        {
            // TODO: some validation, maybe return 0 if null.
            return Convert.ToInt32(dataRow[columnName].ToString());
        }

        public static Guid AsGuid(this DataRow dataRow, string columnName)
        {
            // TODO: some validation, maybe return Guid.Empty if null.
            return Guid.Parse(dataRow[columnName].ToString());
        }

        public static string AsString(this DataRow dataRow, string columnName)
        {
            // Don't want to call toString on null object
            if (!string.IsNullOrEmpty(dataRow[columnName].ToString())) 
                return dataRow[columnName].ToString();

            return null;
        }

        public static DateTime AsDate(this DataRow dataRow, string columnName)
        {
            // TODO: some validation, maybe return epoch (1/1/1970) if null
            return DateTime.Parse(dataRow[columnName].ToString());
        }

        public static DateTime? AsNullableDate(this DataRow dataRow, string columnName)
        {
            if (dataRow[columnName] == null)
                return null;

            // TODO: maybe tryParse
            return DateTime.Parse(dataRow[columnName].ToString());
        }

    }
}
