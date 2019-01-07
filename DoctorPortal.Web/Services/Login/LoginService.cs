using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;
using DoctorPortal.Web.Models;
using DoctorPortal.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DoctorPortal.Web.Common;

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
                .FindBy(m => m.Email.Equals(model.UserNameOrEmail, StringComparison.OrdinalIgnoreCase) ||
                                m.UserName.Equals(model.UserNameOrEmail, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            if (user == null)
                return false;

            if (user.Password != model.Password)
                return false;

            ProjectSession.LoggedInUser = user;
            ProjectSession.UserAccessPermissions = GetUserPermissions(user.RoleId,user.IsSuperAdmin);

            return true;
        }
        
        public bool SendNewPasswordToEmail(string email)
        {
            var user = _userRepo
                .FindBy(m => m.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            if (user == null)
                throw new Exception(Resources.EmailNotExists);

            var newPassword = GenerateNewPassword();

            // Send new password to user via email 
            EmailUser(email, user.FullName, newPassword);

            // Update new password in db
            user.Password = newPassword;
            user.IsSystemGeneratedPassword = true;
            _userRepo.Update(user);

            return true;
        }

        public bool ResetPassword(int userId, ResetPasswordViewModel model)
        {
            var user = _userRepo.FindBy(m => m.Id == userId).FirstOrDefault();
            if (user == null)
                return false;

            if(user.Password != model.OldPassword)
                throw new Exception(Resources.IncorrectOldPassword);

            user.Password = model.NewPassword;
            user.IsSystemGeneratedPassword = false;
            _userRepo.Update(user);

            return true;
        }

        private static void EmailUser(string email,string fullName, string userPassword)
        {
            try
            {
                var bodyTemplate = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Template/ForgotPassword.html"));

                bodyTemplate = bodyTemplate.Replace("[@PORTAL-NAME]", ConfigItems.PortalName);
                bodyTemplate = bodyTemplate.Replace("[@FULLNAME]", fullName);
                bodyTemplate = bodyTemplate.Replace("[@PASSWORD]", userPassword);

                EmailHelper.SendMail(email, "Forgot Password", bodyTemplate, true);
            }
            catch 
            {
                throw new Exception(Resources.NewPasswordSentFailed);
            }
        }

        private static string GenerateNewPassword()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0,8);
        }

        private List<UserAccessPermission> GetUserPermissions(int userRoleId, bool isAdmin)
        {
            object[] paramList =
            {
                new SqlParameter("RoleId", userRoleId),
                new SqlParameter("IsSuperAdmin", isAdmin)
            };

            var permissions = 
                _userRepo
                    .ExecuteStoredProcedureList<UserAccessPermission>("Get_UserAccessPermissions", paramList)
                    .ToList();

            return permissions;
        }
    }
}