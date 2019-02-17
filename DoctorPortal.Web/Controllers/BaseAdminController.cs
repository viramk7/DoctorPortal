using System.Web.Mvc;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Caching;
using log4net;

namespace DoctorPortal.Web.Controllers
{
    public class BaseAdminController : Controller
    {

        // ReSharper disable once InconsistentNaming
        protected readonly ILog _logger;

        public BaseAdminController(IHospitalService hospitalService,
                                   ICacheManager cacheManager)
        {
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            ProjectSession.Hospital = cacheManager.Get("HospitalInfo", () =>
            {
                return hospitalService.GetHospitalInfo();
            });

        }
    }
}