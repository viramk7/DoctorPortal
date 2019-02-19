using System.Web.Mvc;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Caching;
using log4net;

namespace DoctorPortal.Web.Controllers
{
    public class BaseAdminController : Controller
    {
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseAdminController()
        {
            var hospitalService = EngineContext.Resolve<IHospitalService>();
            var cacheManager = EngineContext.Resolve<ICacheManager>();

            ProjectSession.Hospital = cacheManager.Get("HospitalInfo", () =>
            {
                return hospitalService.GetHospitalInfo();
            });
        }
    }
}