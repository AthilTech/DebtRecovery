using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.statics
{
    public static class DateTimeExtensions
    {
        public static bool InRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck.Date >= startDate.Date && dateToCheck.Date <= endDate.Date;
        }
    }
}
