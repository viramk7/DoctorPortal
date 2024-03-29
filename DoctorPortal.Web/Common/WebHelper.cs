﻿using System.Collections.Generic;
using System.Web;

namespace DoctorPortal.Web.Common
{
    public static class WebHelper
    {
        public const int PageSize = 10;

        public const int HospitalId = 1;

        public const int OutputCacheTime = 60 * 60 * 24; // 1 day

        public static int[] PageSizes = { 10, 20, 50, 100, 500 };

        public static string[] ValidImageFileTypes = { ".jpeg", ".jpg", ".png" };

        public const string PleaseSelect = "--Select--";

        public static readonly Dictionary<string, object> ActionCenterColumnStyleWithCanEdit = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center;vertical-align:middle !important;" }, { "width", "80px" } };

        public static readonly Dictionary<string, object> ActionCenterColumnStyleWithCanStatus = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center;vertical-align:middle !important;" }, { "width", "120px" } };

        public static readonly Dictionary<string, object> StatusColumnStyle = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center;vertical-align:middle !important;" }, { "width", "60px" } };

        public static readonly Dictionary<string, object> SmallColumnStyle = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center;vertical-align:middle !important;" }, { "width", "30px" } };

        public const string DateFormate = "dd/MM/yyyy";

        public const string TimeFormate = "HH:mm";

        public const string DateTimeFormat = "dd/MM/yyyy hh:mm tt";

    }
}