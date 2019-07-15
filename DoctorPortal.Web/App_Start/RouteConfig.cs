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
                "Error - 404",
                "NotFound",
                new { controller = "Error", action = "NotFound" }
            );

            routes.MapRoute(
                "Error - 500",
                "ServerError",
                new { controller = "Error", action = "ServerError" }
            );


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
                name: "client-testimonials",
                url: "client-testimonials",
                defaults: new { controller = "Testimonial", action = "Index" }
            );

            routes.MapRoute(
                name: "contact-us",
                url: "contact-us",
                defaults: new { controller = "ContactUs", action = "Index" }
            );

            routes.MapRoute(
                name: "sport-injury-centre",
                url: "sport-injury-centre",
                defaults: new { controller = "SportInjuries", action = "Index" }
            );

            routes.MapRoute(
               name: "anesthetist-doctor",
               url: "anesthetist-doctor",
               defaults: new { controller = "Department", action = "anesthesia" }
           );

            routes.MapRoute(
               name: "medicine-department-in-hospital",
               url: "medicine-department-in-hospital",
               defaults: new { controller = "Department", action = "medicine" }
           );
            routes.MapRoute(
               name: "Orthopaedic-hospital",
               url: "Orthopaedic-hospital",
               defaults: new { controller = "Department", action = "orthopaedic" }
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
