using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Models.ViewModels;
using DoctorPortal.Web.Areas.Admin.Services.HospitalInfo;
using DoctorPortal.Web.Caching;
using DoctorPortal.Web.Common;
using System;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class HospitalController : BaseController
    {
        private readonly IHospitalInfoService _hospitalInfoService;
        private readonly ICacheManager _cacheManager;

        public HospitalController(IHospitalInfoService hospitalInfoService, ICacheManager cacheManager)
        {
            _hospitalInfoService = hospitalInfoService;
            _cacheManager = cacheManager;
        }

        public ActionResult Index()
        {
            var model = _hospitalInfoService.GetHospitalById(ProjectSession.LoggedInUser.HospitalId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HospitalInfoViewModel model,string create = null)
        {
            try
            {
                _hospitalInfoService.SaveHospitalInfo(model);

                // Clear the cache
                _cacheManager.Remove(CacheKeys.HospitalInfo.ToString());

                SuccessNotification(Resources.SaveSuccess);
            }
            catch (Exception e)
            {
                Logger.log.Error($"Save Hospital: {e.Message}");
                ErrorNotification(Resources.SaveFailed);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}