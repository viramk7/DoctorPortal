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
            var loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            HttpCookie authCookie = Request.Cookies["DoctorPortal"];
            if (authCookie != null)
            {
                try
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    loginViewModel = JsonConvert.DeserializeObject<LoginViewModel>(authTicket.UserData);

                    var isValidUser = _loginService.AuthenticateUser(loginViewModel);
                    if(!isValidUser)
                        return View(new LoginViewModel());
                }
                catch
                {
                    Logout();
                }
            }

            if (ProjectSession.LoggedInUser != null)
            {
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction("Index", "Home");
                else
                    return new RedirectResult(returnUrl);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            var isValidUser = _loginService.AuthenticateUser(loginViewModel);

            if (!isValidUser)
                return RedirectToAction(nameof(Index));

            if (loginViewModel.RememberMe)
            {
                string userData = JsonConvert.SerializeObject(loginViewModel);
                var authTicket = new FormsAuthenticationTicket(
                    1,
                    loginViewModel.UserNameOrEmail,
                    DateTime.Now,
                    DateTime.Now.AddDays(30),
                    loginViewModel.RememberMe, // pass here true, if you want to implement remember me functionality
                    userData);

                var encTicket = FormsAuthentication.Encrypt(authTicket);
                var facookie = new HttpCookie("DoctorPortal", encTicket);
                facookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(facookie);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            if (Request.Cookies["DoctorPortal"] != null)
            {
                var myCookie = new HttpCookie("DoctorPortal");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}