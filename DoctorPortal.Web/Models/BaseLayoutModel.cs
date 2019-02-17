using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Models
{
    public static class BaseLayoutModel
    {
        public static string Name { get; set; }
        public static string Email { get; set; }
        public static string EmergencyNo { get; set; }
        public static string ContactNo { get; set; }
        public static string AddressLine1 { get; set; }
        public static string AddressLine2 { get; set; }
        public static string WorkingHours { get;  set; }
        public static string WorkingDays { get; set; }
    }
}