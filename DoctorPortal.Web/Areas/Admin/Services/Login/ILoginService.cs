using DoctorPortal.Web.Areas.Admin.Models.ViewModels;

namespace DoctorPortal.Web.Areas.Admin.Services.Login
{
    public interface ILoginService
    {
        bool AuthenticateUser(LoginViewModel model);

        bool SendNewPasswordToEmail(string email);

        bool ResetPassword(int userId, ResetPasswordViewModel model);
    }
}
