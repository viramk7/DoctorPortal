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
        
        // TODO: Enable this after going live
        //[OutputCache(Location = OutputCacheLocation.Client,
        //             Duration = WebHelper.OutputCacheTime,
        //             VaryByParam = "id",
        //             NoStore =false)]
        public ActionResult Index(int id = 0)
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