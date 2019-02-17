using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.AdminServices.Speciality;
using DoctorPortal.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ISpecialityService _SpecialityService;

        public DoctorController(ISpecialityService specialityService)
        {
            _SpecialityService = specialityService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var facilitylist = _SpecialityService.GetAllSpeciality();
                return View(facilitylist);
            }
            catch (Exception e)
            {
                Logger.log.Error($"Controller: {nameof(DoctorController)} , Action: {nameof(Index)}. Error: {e.Message}");
                return View("Error");
            }
        }
    }
}