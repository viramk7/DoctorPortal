using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using DoctorPortal.Web.Areas.Admin.Services.User;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController
    {
        private readonly IUserService _userService;

        public AdminHomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KendoRead([DataSourceRequest] DataSourceRequest request)
        {
            if (!request.Sorts.Any())
                request.Sorts.Add(new SortDescriptor("FullName", ListSortDirection.Ascending));

            var users = _userService.GetAllUsers();
            return Json(users.ToDataSourceResult(request),JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}