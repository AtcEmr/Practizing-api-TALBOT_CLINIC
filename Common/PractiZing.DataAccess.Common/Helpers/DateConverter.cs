using System;


namespace PractiZing.DataAccess.Common.Helpers
{
    public class DateConverter
    {
        public static string FormatDateRange(DatePeriod datePeriod, string separator = "-")
        {
            if (string.IsNullOrEmpty(separator)) separator = "*";
            Contract.RequiresNotNull(datePeriod, "datePeriod != null");

            return $"{FormatDate(datePeriod.From)}{separator}{FormatDate(datePeriod.To.Value)}";
        }



        public static string FormatDate(DateTime date)
        {
            return $"{date:MMddyyyy}";
        }

        public static string FormatDateYear(DateTime date)
        {
            return $"{date:yyyyMMdd}";
        }

        public static string FormatTime(DateTime date)
        {
            return $"{date:HHmm}";
        }

        public static string GetTimeInMilliseconds()
        {
            return $"{(long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds}";
        }
    }
}
