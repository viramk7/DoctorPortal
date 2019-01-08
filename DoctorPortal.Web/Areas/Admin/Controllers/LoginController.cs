using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Models.ViewModels;
using DoctorPortal.Web.Areas.Admin.Services.Login;
using Newtonsoft.Json;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index(string returnUrl)
        {
            var authCookie = Request.Cookies["DoctorPortal"];
            if (authCookie != null)
            {
                try
                {
                    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (authTicket != null)
                    {
                        var loginViewModel = JsonConvert.DeserializeObject<LoginViewModel>(authTicket.UserData);

                        var isValidUser = _loginService.AuthenticateUser(loginViewModel);
                        if(!isValidUser)
                            return View(new LoginViewModel());
                    }
                }
                catch
                {
                    Logout();
                }
            }

            if (ProjectSession.LoggedInUser == null)
                return View();

            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index", "AdminHome");

            return new RedirectResult(returnUrl);

        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[NotifyType.Error] = Resources.InvalidUsernameOrPassword;
                return View();
            }
                

            var isValidUser = _loginService.AuthenticateUser(loginViewModel);

            if (!isValidUser)
            {
                TempData[NotifyType.Error] = Resources.InvalidUsernameOrPassword;
                return View();
            }

            if (!loginViewModel.RememberMe)
                return RedirectToAction("Index", "AdminHome");

            var userData = JsonConvert.SerializeObject(loginViewModel);
            var authTicket = new FormsAuthenticationTicket(
                1,
                loginViewModel.UserNameOrEmail,
                DateTime.Now,
                DateTime.Now.AddDays(30),
                loginViewModel.RememberMe, // pass here true, if you want to implement remember me functionality
                userData);

            var encTicket = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie("DoctorPortal", encTicket) {Expires = DateTime.Now.AddDays(30)};
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "AdminHome");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            if (Request.Cookies["DoctorPortal"] == null)
                return RedirectToAction(nameof(Index));

            var myCookie = new HttpCookie("DoctorPortal") {Expires = DateTime.Now.AddDays(-1d)};
            Response.Cookies.Add(myCookie);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                _loginService.SendNewPasswordToEmail(model.Email);
                TempData[NotifyType.Success] = Resources.NewPasswordSent;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData[NotifyType.Error] = ex.Message;
                return View();
            }
        }

        public ActionResult ResetPassword()
        {
            // User must be logged in in order to change pwd
            if (ProjectSession.LoggedInUser == null)
                return RedirectToAction(nameof(Index));

            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[NotifyType.Error] = Resources.InvalidData;
                return View();
            }

            if (ProjectSession.LoggedInUser == null)
            {
                TempData[NotifyType.Error] = Resources.SessionExpired;
                return View("Index");
            }

            try
            {
                var isSuccess = _loginService.ResetPassword(ProjectSession.LoggedInUser.Id, model);
                if(isSuccess)
                {
                    TempData[NotifyType.Success] = Resources.PasswordResetSuccess;
                    return Logout();
                }

                TempData[NotifyType.Error] = Resources.CouldNotResetPassword;
                return View();
            }
            catch (Exception e)
            {
                TempData[NotifyType.Error] = e.Message;
                return View();
            }
        }
    }
}