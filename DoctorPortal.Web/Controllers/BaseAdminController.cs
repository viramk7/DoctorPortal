using System.Web.Mvc;
using log4net;

namespace DoctorPortal.Web.Controllers
{
    public class BaseAdminController : Controller
    {
        // ReSharper disable once InconsistentNaming
        protected readonly ILog _logger;

        public BaseAdminController()
        {
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}