using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Common
{
    public static class Utility
    {
        public static string GetDayFromDayNo(byte day)
        {
            switch (day)
            {
                case 1:
                    return "Mon";
                case 2:
                    return "Tue";
                case 3:
                    return "Wed";
                case 4:
                    return "Thur";
                case 5:
                    return "Fri";
                case 6:
                    return "Sat";
                case 7:
                    return "Sun";
                default:
                    return "";
            }
        }

        public static string GetCommaSeparatedStringFromListOfString(IList<string> list)
        {
            var str = string.Empty;

            if (list.Any())
            {
                str = list.Aggregate(str, (current, strItem) => current + strItem + ", ");
            }

            if (!string.IsNullOrEmpty(str))
                str = str.TrimEnd(',',' ');

            return str;
        }

        public static string GetShortWorkingDaysString(string workingDays)
        {
            if (string.IsNullOrEmpty(workingDays))
                return workingDays;

            switch (workingDays)
            {
                case "Mon, Tue, Wed, Thur, Fri, Sat, Sun":
                    return "Mon - Sun";
                case "Mon, Tue, Wed, Thur, Fri, Sat":
                    return "Mon - Sat";
                case "Mon, Tue, Wed, Thur, Fri":
                    return "Mon - Fri";
                case "Mon, Tue, Wed, Thur":
                    return "Mon - Thur";
                case "Mon, Tue, Wed":
                    return "Mon - Wed";
                case "Mon, Tue":
                    return "Mon - Tue";
                default:
                    return workingDays;
            }
        }

        public static IList<string> GetWorkingHoursList()
        {
            return new List<string>
            {
                "12:00 AM",
                "12:30 AM",

                "01:00 AM",
                "01:30 AM",

                "02:00 AM",
                "02:30 AM",

                "03:00 AM",
                "03:30 AM",

                "04:00 AM",
                "04:30 AM",

                "05:00 AM",
                "05:30 AM",

                "06:00 AM",
                "06:30 AM",

                "07:00 AM",
                "07:30 AM",

                "08:00 AM",
                "08:30 AM",

                "09:00 AM",
                "09:30 AM",

                "10:00 AM",
                "10:30 AM",

                "11:00 AM",
                "11:30 AM",

                "12:00 PM",
                "12:30 PM",

                "01:00 PM",
                "01:30 PM",

                "02:00 PM",
                "02:30 PM",

                "03:00 PM",
                "03:30 PM",

                "04:00 PM",
                "04:30 PM",

                "05:00 PM",
                "05:30 PM",

                "06:00 PM",
                "06:30 PM",

                "07:00 PM",
                "07:30 PM",

                "08:00 PM",
                "08:30 PM",

                "09:00 PM",
                "09:30 PM",

                "10:00 PM",
                "10:30 PM",

                "11:00 PM",
                "11:30 PM",
            };
        }

        public static List<List<T>> SplitListBySize<T>(List<T> source, int size)
        {
            size = size == 0 ? source.Count : size;

            var ret = new List<List<T>>();
            for (int i = 0; i < source.Count; i += size)
                ret.Add(source.GetRange(i, Math.Min(size, source.Count - i)));

            return ret;
        }

        public static IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static string ReadFileToString(string templatePath)
        {
            return System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath(templatePath));
        }

    }
}