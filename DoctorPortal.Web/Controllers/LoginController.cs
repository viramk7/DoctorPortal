using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;
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
            var users = _userRepo.Table.ToList();
            return View();
        }
    }
}