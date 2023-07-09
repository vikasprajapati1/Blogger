using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Extensions
    {
        public static string Truncate(this string input, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;
            return input.Substring(0, Math.Min(input.Length, maxLength));
        }

        #region helps us to conver datarow fields

        public static int ToInt32(this DataRow row, string ColumnName)
        {
            int ColumnValue = 0;
            Int32.TryParse(row[ColumnName].ToString(), out ColumnValue);
            return ColumnValue;
        }

        public static bool ToBoolean(this DataRow row, string ColumnName)
        {
            bool ColumnValue = false;
            Boolean.TryParse(row[ColumnName].ToString(), out ColumnValue);
            return ColumnValue;
        }

        public static DateTime ToDateTime(this DataRow row, string ColumnName)
        {
            DateTime ColumnValue = default(DateTime);
            DateTime.TryParse(row[ColumnName].ToString(), out ColumnValue);
            return ColumnValue;
        }

        #endregion helps us to conver datarow fields

        /// <summary>
        /// Convert TimeSpan Leave Total Hours to Decimal hours
        /// </summary>
        /// <param name="totalHours"></param>
        /// <returns></returns>
        public static decimal ToHours(this TimeSpan totalHours)
        {
            if (totalHours == default(TimeSpan))
                return default(Decimal);

            Decimal _TotalTime = default(Decimal);
            Decimal.TryParse(totalHours.TotalHours.ToString(), out _TotalTime);
            return _TotalTime;
        }

        /// <summary>
        /// Convert Leave total Hours from Decimal to Timespan
        /// </summary>
        /// <param name="totalHours"></param>
        /// <returns></returns>
        public static TimeSpan ToHours(this Decimal totalHours)
        {
            if (totalHours == 0)
                return default(TimeSpan);

            return TimeSpan.FromHours((double)totalHours);
        }
    }
}
