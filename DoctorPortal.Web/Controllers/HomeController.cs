using System;
using System.Web.Mvc;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Models;

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

                BaseLayoutModel.AddressLine1 = hospital.AddressLine1;
                BaseLayoutModel.AddressLine2 = hospital.AddressLine2;
                BaseLayoutModel.ContactNo = hospital.ContactNo;
                BaseLayoutModel.Email = hospital.Email;
                BaseLayoutModel.EmergencyNo = hospital.EmergencyNo;
                BaseLayoutModel.Name = hospital.Name;
                BaseLayoutModel.WorkingDays = hospital.WorkingDays;
                BaseLayoutModel.WorkingHours = hospital.WorkingHours;
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