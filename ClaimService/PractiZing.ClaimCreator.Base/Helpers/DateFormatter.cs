using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Base
{
    public class DateFormatter
    {
        public static string FormatDateRange(DateTime fromDate,DateTime toDate, string separator = "-")
        {
            if (string.IsNullOrEmpty(separator)) separator = "*";
            
            return $"{FormatDate(fromDate)}{separator}{FormatDate(toDate)}";
        }



        public static string FormatDate(DateTime date)
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
