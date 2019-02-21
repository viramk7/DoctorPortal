using DoctorPortal.Web.Areas.Admin.Services.Facility;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class ServicesController : BaseAdminController
    {
        private readonly IFacilityService _servicefacility;

        public ServicesController(IFacilityService servicefacility)
        {
            _servicefacility = servicefacility;
        }

        public ActionResult GetServicesPartialView()
        {
            var services = _servicefacility.GetAllFacility();
            return PartialView("_Facility", services);
        }
    }
}