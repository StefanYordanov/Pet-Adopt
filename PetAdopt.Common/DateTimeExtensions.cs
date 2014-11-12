using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Common
{
    public static class DateTimeExtensions
    {
        public static string GetAge(this DateTime BirthDate)
        {
            var age = DateTime.Now - BirthDate;
            int years = age.Days / 365;
            if (years > 0)
            {
                return string.Format("{0} year{1} old", years, years == 1 ? "" : "s");
            }
            int months = age.Days / 30;

            if (months > 0)
            {
                return string.Format("{0} month{1} old", months, months == 1 ? "" : "s");
            }

            return string.Format("{0} day{1} old", age.Days, age.Days == 1 ? "" : "s");
        }
    }
}
