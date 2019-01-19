using System;
using Autofac;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web;
using DoctorPortal.Web.Filters;

namespace DoctorPortal.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
            GlobalFilters.Filters.Add(new AjaxErrorHandler());
            Bootstrapper.Resolve(new ContainerBuilder());
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    // Code that runs when an unhanded error occurs                        
        //    // Get the exception object.
        //    var exc = Server.GetLastError();

        //    // Log the exception and notify system operators
        //    var log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //    log.Error(HttpContext.Current.Request.Url, exc);

        //    // Clear the error from the server
        //    Server.ClearError();
        //}

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (!(HttpContext.Current.Items["AjaxPermissionDenied"] is bool)) return;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.StatusCode = 401;
        }
    }
}
