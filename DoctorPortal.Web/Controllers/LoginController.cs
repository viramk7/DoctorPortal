using DoctorPortal.Web.Models;
using DoctorPortal.Web.Models.ViewModels;
using DoctorPortal.Web.Services.Login;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DoctorPortal.Web.Controllers
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
                return RedirectToAction("Index", "Home");

            return new RedirectResult(returnUrl);

        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            var isValidUser = _loginService.AuthenticateUser(loginViewModel);

            if (!isValidUser)
                return RedirectToAction(nameof(Index));

            if (!loginViewModel.RememberMe)
                return RedirectToAction("Index", "Home");

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

            return RedirectToAction("Index", "Home");
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
    }
}