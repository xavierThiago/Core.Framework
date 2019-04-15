using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Framework.Utils
{
    public static class DateTimeHelper
    {
        public static bool IsBusinessDay(this DateTime date, List<DateTime> holidays = null)
        {
            if (date == default) throw new InvalidOperationException("Invalid date and time");

            if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday ||
                (holidays != null && holidays.Any() && holidays.Contains(date)))
                return false;

            return true;
        }

        public static DateTime GetNextBusinessDay(this DateTime date, List<DateTime> holidays = null)
        {
            if (date == default) throw new InvalidOperationException("Invalid date and time");

            while (!IsBusinessDay(date, holidays))
                date = date.AddDays(1.0);

            return date;
        }
    }
}
