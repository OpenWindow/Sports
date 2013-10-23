using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scorer.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeekend(this DateTime dt, DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday ? date : 
                                                          date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(-1) : 
                                                                                               DateTime.Now.StartOfWeekend(date.AddDays(1));
        }
    }
}