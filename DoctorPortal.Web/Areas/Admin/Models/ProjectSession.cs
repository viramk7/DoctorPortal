﻿using System;
using System.Collections.Generic;
using System.Web;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Models;

namespace DoctorPortal.Web.Areas.Admin.Models
{
    public class ProjectSession
    {
        public static LoggedInUserModel LoggedInUser
        {
            get
            {
                if (HttpContext.Current.Session["User"] == null)
                {
                    return null;
                }

                var userStr = Convert.ToString(HttpContext.Current.Session["User"]);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<LoggedInUserModel>(userStr);
            }

            set => HttpContext.Current.Session["User"] = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }

        public static List<UserAccessPermission> UserAccessPermissions
        {
            get =>
                HttpContext.Current.Session["UserAccessPermission"] == null
                    ? new List<UserAccessPermission>()
                    : HttpContext.Current.Session["UserAccessPermission"] as
                        List<UserAccessPermission>;

            set => HttpContext.Current.Session["UserAccessPermission"] = value;
        }

        public static HospitalViewModel Hospital
        {
            get
            {
                if (HttpContext.Current.Session["Hospital"] == null)
                {
                    return null;
                }

                var userStr = Convert.ToString(HttpContext.Current.Session["Hospital"]);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<HospitalViewModel>(userStr);
            }

            set => HttpContext.Current.Session["Hospital"] = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }
    }
}