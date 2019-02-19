using System;
using System.Web.Mvc;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Common;

namespace DoctorPortal.Web.Controllers
{
    public class HomeController : BaseAdminController
    {
        public HomeController() 
        {
        }

        public ActionResult Index()
        {
            try
            {
                if (ProjectSession.Hospital == null)
                    throw new Exception("Something went wrong");
                
                return View();
            }
            catch (Exception e)
            {
                Logger.log.Error($"Controller: {nameof(HomeController)} , Action: {nameof(Index)}. Error: {e.Message}");
                return View("Error");
            }
        }
    }
}