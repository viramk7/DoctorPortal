using System;
using System.Web.Mvc;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Common;

namespace DoctorPortal.Web.Controllers
{
    public class HomeController : BaseAdminController
    {
        private readonly IHospitalService _hospitalService;
        
        public HomeController(IHospitalService hospitalService) 
        {
            _hospitalService = hospitalService;
        }

        public ActionResult Index()
        {
            try
            {
                if (ProjectSession.Hospital == null)
                    throw new Exception("Something went wrong");
                
                var homeinfo = _hospitalService.GetHomePageInfo();
                return View(homeinfo);
            }
            catch (Exception e)
            {
                Logger.log.Error($"Controller: {nameof(HomeController)} , Action: {nameof(Index)}. Error: {e.Message}");
                return View("Error");
            }
        }
    }
}