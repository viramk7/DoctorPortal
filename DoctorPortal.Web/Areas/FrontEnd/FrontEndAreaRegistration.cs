using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.FrontEnd
{
    public class FrontEndAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "FrontEnd";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FrontEnd_default",
                "FrontEnd/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}