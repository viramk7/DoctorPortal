using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;
using DoctorPortal.Web.Models;
using DoctorPortal.Web.Models.ViewModels;
using System.Linq;

namespace DoctorPortal.Web.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<UserMaster> _userRepo;

        public LoginService(IRepository<UserMaster> userRepo)
        {
            _userRepo = userRepo;
        }

        public bool AuthenticateUser(LoginViewModel model)
        {
            var user = _userRepo
                .FindBy(m => m.Email.Equals(model.UserNameOrEmail, System.StringComparison.OrdinalIgnoreCase) ||
                                m.UserName.Equals(model.UserNameOrEmail, System.StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            if (user == null)
                return false;

            if (user.Password != model.Password)
                return false;

            ProjectSession.LoggedInUser = user;

            return true;
        }
    }
}