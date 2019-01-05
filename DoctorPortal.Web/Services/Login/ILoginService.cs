using DoctorPortal.Web.Models.ViewModels;

namespace DoctorPortal.Web.Services.Login
{
    public interface ILoginService
    {
        bool AuthenticateUser(LoginViewModel model);
    }
}
