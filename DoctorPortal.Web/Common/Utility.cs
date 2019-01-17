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

    }
}