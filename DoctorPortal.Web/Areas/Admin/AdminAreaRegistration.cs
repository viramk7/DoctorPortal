﻿using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Hospital", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}