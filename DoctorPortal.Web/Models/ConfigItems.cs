using System.Configuration;

namespace DoctorPortal.Web.Models
{
    public static class ConfigItems
    {
        public static string PortalName => ConfigurationManager.AppSettings["PORTAL-NAME"];
        public static string SmtpEmail => ConfigurationManager.AppSettings["EMAIL"];
        public static string SmtpPassword => ConfigurationManager.AppSettings["PASSWORD"];
        public static string HostName => ConfigurationManager.AppSettings["HOSTNAME"];
        public static string PortNumber => ConfigurationManager.AppSettings["PORT-NUMBER"];
    }
}