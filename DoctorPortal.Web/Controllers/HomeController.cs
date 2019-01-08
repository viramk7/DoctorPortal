using System.Web.Mvc;
using DoctorPortal.Web.Common;

namespace DoctorPortal.Web.Controllers
{
    public class HomeController : BaseAdminController
    {
        public ActionResult Index()
        {
            Logger.log.Info("Home controller called");
            return View();
        }
    }
}