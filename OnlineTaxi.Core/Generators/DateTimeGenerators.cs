using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OnlineTaxi.Core.Generators
{
    public static class DateTimeGenerators
    {
        static PersianCalendar pc = new PersianCalendar();
        public static string GetShamsiDate()
        {
            var current = DateTime.Now;
            return pc.GetYear(current).ToString("0000") + "/" +
                pc.GetMonth(current).ToString("00") + "/" +
                pc.GetDayOfMonth(current).ToString("00");
        }
        public static string GetShamsiTime()
        {
            var current = DateTime.Now;
            return pc.GetHour(current).ToString("00") + ":" +
                pc.GetMinute(current).ToString("00") + ":" +
                pc.GetSecond(current).ToString("00");
        }
    }
}
