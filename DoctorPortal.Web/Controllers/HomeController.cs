using System;
using System.Web.Mvc;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Caching;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Models;

namespace DoctorPortal.Web.Controllers
{
    public class HomeController : BaseAdminController
    {
        private readonly IHospitalService _hospitalService;
        private readonly ICacheManager _cacheManager;

        public HomeController(IHospitalService hospitalService,
                             ICacheManager cacheManager) : base(hospitalService,cacheManager)
        {
            _hospitalService = hospitalService;
            _cacheManager = cacheManager;
        }

        public ActionResult Index()
        {
            try
            {
                if (ProjectSession.Hospital == null)
                    throw new Exception("Something went wrong");

                //var hospital = ProjectSession.Hospital;

                var homeinfo = _hospitalService.GetHomePageInfo();

                //if (hospital == null)
                //    throw new Exception("Hospital not found.");

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