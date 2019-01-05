using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;
using DoctorPortal.Web.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepository<UserMaster> _userRepo;

        public LoginController(IRepository<UserMaster> userRepo)
        {
            _userRepo = userRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            return View();
        }
    }
}