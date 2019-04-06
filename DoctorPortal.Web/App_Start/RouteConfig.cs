using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoctorPortal.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "faq",
                url: "faq",
                defaults: new { controller = "FAQ", action = "Index" },
                new[] { "DoctorPortal.Web.Controllers" }
            );

            routes.MapRoute(
                name: "about-us",
                url: "about-us",
                defaults: new { controller = "AboutUs", action = "Index" },
                new[] { "DoctorPortal.Web.Controllers" }
            );

            routes.MapRoute(
                name: "departments",
                url: "departments/{id}",
                defaults: new { controller = "Department", action = "Index", id = UrlParameter.Optional },
                new[] { "DoctorPortal.Web.Controllers" }
            );

            routes.MapRoute(
                name: "doctors",
                url: "doctors",
                defaults: new { controller = "Doctor", action = "Index" },
                new[] { "DoctorPortal.Web.Controllers" }
            );

            routes.MapRoute(
                name: "testimonials",
                url: "testimonials",
                defaults: new { controller = "Testimonial", action = "Index" }
            );

            routes.MapRoute(
                name: "contact-us",
                url: "contact-us",
                defaults: new { controller = "ContactUs", action = "Index" }
            );

            routes.MapRoute(
                name: "sport-injuries",
                url: "sport-injuries",
                defaults: new { controller = "SportInjuries", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "DoctorPortal.Web.Controllers" }
            );

            
        }
    }
}
