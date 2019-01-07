using System.Configuration;
using System.Web;

namespace DoctorPortal.Web.Models
{
    public static class ConfigItems
    {
        public static string PortalName => ConfigurationManager.AppSettings["PORTAL-NAME"];
        public static string SmtpEmail => ConfigurationManager.AppSettings["EMAIL"];
        public static string SmtpPassword => ConfigurationManager.AppSettings["PASSWORD"];
        public static string HostName => ConfigurationManager.AppSettings["HOSTNAME"];
        public static string PortNumber => ConfigurationManager.AppSettings["PORT-NUMBER"];

        public static string SiteRootPathUrl
        {
            get
            {
                string msRootUrl;
                if (HttpContext.Current.Request.ApplicationPath != null && string.IsNullOrEmpty(HttpContext.Current.Request.ApplicationPath.Split('/')[1]))
                {
                    msRootUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host +
                                ":" +
                                HttpContext.Current.Request.Url.Port;
                }
                else
                {
                    msRootUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath;
                }

                return msRootUrl;
            }
        }
    }
}