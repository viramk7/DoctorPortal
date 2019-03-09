using System;
using Autofac;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web;
using DoctorPortal.Web.Filters;
using DoctorPortal.Web.Controllers;
using System.Threading;
using System.Globalization;

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

        protected void Application_BeginRequest()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-IN");
            CultureInfo info = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.ToString());
            info.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy hh:mm tt";
            //info.DateTimeFormat.FullDateTimePattern = "dd/MM/yyyy hh:mm tt";
            System.Threading.Thread.CurrentThread.CurrentCulture = info;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhanded error occurs                        
            // Get the exception object.
            var exception = Server.GetLastError();

            // Log the exception and notify system operators
            var log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.Error(HttpContext.Current.Request.Url, exception);

            Response.Clear();

            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Errors");

            if (!(exception is HttpException httpException))
            {
                routeData.Values.Add("action", "Index");
            }
            else //It's an Http Exception, Let's handle it.
            {
                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // Page not found.
                        routeData.Values.Add("action", "HttpError404");
                        break;
                    case 500:
                        // Server error.
                        routeData.Values.Add("action", "HttpError500");
                        break;

                    // Here you can handle Views to other error codes.
                    // I choose a General error template  
                    default:
                        routeData.Values.Add("action", "General");
                        break;
                }
            }

            // Pass exception details to the target error View.
            routeData.Values.Add("error", exception);

            // Clear the error on server.
            Server.ClearError();

            // Avoid IIS getting in the middle
            Response.TrySkipIisCustomErrors = true;

            // Call target Controller and pass the routeData.
            IController errorController = new ErrorsController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (!(HttpContext.Current.Items["AjaxPermissionDenied"] is bool)) return;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.StatusCode = 401;
        }
    }
}
