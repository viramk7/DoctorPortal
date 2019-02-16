using System;
using System.Web.Mvc;
using DoctorPortal.Web.AdminServices.Hospital;
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
                var hospital = _hospitalService.GetHospitalInfo();
                if(hospital == null)
                    throw new Exception("Hospital not found.");
                return View(hospital);
            }
            catch (Exception e)
            {
                Logger.log.Error($"Controller: {nameof(HomeController)} , Action: {nameof(Index)}. Error: {e.Message}" );
                return View("Error");
            }
        }
    }
}