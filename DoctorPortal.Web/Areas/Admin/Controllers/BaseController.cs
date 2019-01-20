using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DoctorPortal.Web.Areas.Admin.Models;
using log4net;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    [UserAuthorization]
    public class BaseController : Controller
    {
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true, bool saveInSession = false)
        {
            AddNotification(Enums.NotifyType.Success, message, persistForTheNextRequest, saveInSession);
        }

        protected virtual void ErrorNotification(string message, bool persistForTheNextRequest = true, bool saveInSession = false)
        {
            AddNotification(Enums.NotifyType.Error, message, persistForTheNextRequest, saveInSession);
        }

        protected virtual void ErrorNotification(Exception exception, bool persistForTheNextRequest = true, bool logException = true)
        {
            AddNotification(Enums.NotifyType.Error, exception.Message, persistForTheNextRequest, false);
        }

        protected virtual void AddNotification(Enums.NotifyType type, string message, bool persistForTheNextRequest, bool saveInSession)
        {
            var dataKey = $"tmp.notifications.{type}";

            if (!saveInSession)
            {
                if (persistForTheNextRequest)
                {
                    if (TempData[dataKey] == null)
                        TempData[dataKey] = new List<string>();

                    ((List<string>)TempData[dataKey]).Add(message);
                }
                else
                {
                    if (ViewData[dataKey] == null)
                        ViewData[dataKey] = new List<string>();

                    ((List<string>)ViewData[dataKey]).Add(message);
                }
            }
            else
            {
                if (Session[dataKey] == null)
                    Session[dataKey] = new List<string>();

                ((List<string>)Session[dataKey]).Add(message);
            }
        }
    }

    public sealed class UserAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = HttpContext.Current;

            if (ProjectSession.LoggedInUser == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Items["AjaxPermissionDenied"] = true;
                    return;
                }

                filterContext.Result = new RedirectResult($"~/Admin/Login/Index?returnUrl={ctx.Request.Url}");
                return;
            }

            if (ProjectSession.LoggedInUser.IsSystemGeneratedPassword)
            {
                filterContext.Result = new RedirectResult($"~/Admin/Login/ResetPassword");
            }
        }
    }
}