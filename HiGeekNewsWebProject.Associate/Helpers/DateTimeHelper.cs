using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Associate.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime FirstDateofMonth(int year, int month)
        {
            return new DateTime(year, month, 1);
        }

        public static DateTime FirstDateofMonthId(int montId)
        {
            string monthIdText = montId.ToString();

            if (monthIdText.Length != 6)
            {
                throw new ApplicationException("Invalid MonthId");
            }

            return FirstDateofMonth(Int32.Parse(monthIdText.Substring(0, 4)), Int32.Parse(monthIdText.Substring(4, 2)));
        }

        public static DateTime LastDateofMonth(int year, int month)
        {
            return FirstDateofMonth(year, month).AddDays(1).AddDays(-1);
        }

        public static DateTime LastDateofMonthId(int montId)
        {
            string monthIdText = montId.ToString();

            if (monthIdText.Length != 6)
            {
                throw new ApplicationException("Invalid MonthId");
            }

            return LastDateofMonth(Int32.Parse(monthIdText.Substring(0, 4)), Int32.Parse(monthIdText.Substring(4, 2)));
        }

        public static List<DateTime> GetDaysOfMonth(int monthId)
        {
            List<DateTime> days = new List<DateTime>();
            DateTime firstDay = FirstDateofMonthId(monthId);
            DateTime lastDay = LastDateofMonthId(monthId);

            for (DateTime day = firstDay; day <= lastDay; day = day.AddDays(1))
            {
                days.Add(day);
            }

            return days;
        }

        public static string CreateTimeSpan()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
