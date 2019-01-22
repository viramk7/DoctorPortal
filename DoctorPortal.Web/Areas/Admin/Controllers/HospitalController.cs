using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Models.ViewModels;
using DoctorPortal.Web.Areas.Admin.Services.HospitalInfo;
using DoctorPortal.Web.Common;
using System;
using System.Web.Mvc;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class HospitalController : BaseController
    {
        private readonly IHospitalInfoService _hospitalInfoService;

        public HospitalController(IHospitalInfoService hospitalInfoService)
        {
            _hospitalInfoService = hospitalInfoService;
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