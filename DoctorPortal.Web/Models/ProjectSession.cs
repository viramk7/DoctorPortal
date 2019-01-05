using DoctorPortal.Web.Database;
using System;
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
                else
                {
                    var userStr = Convert.ToString(HttpContext.Current.Session["User"]);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<UserMaster>(userStr);
                }
            }

            set
            {
                HttpContext.Current.Session["User"] = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            }
        }
    }
}