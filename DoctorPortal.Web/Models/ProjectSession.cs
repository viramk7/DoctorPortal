using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Web;

namespace DoctorPortal.Web.Models
{
    public class ProjectSession
    {
        public static UserMaster LoggedInUser
        {
            get
            {
                if (HttpContext.Current.Session["User"] == null)
                {
                    return null;
                }

                var userStr = Convert.ToString(HttpContext.Current.Session["User"]);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<UserMaster>(userStr);
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
    }
}