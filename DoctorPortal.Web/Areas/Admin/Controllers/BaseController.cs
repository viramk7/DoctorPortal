using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DoctorPortal.Web.Areas.Admin.Models;
using log4net;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    [UserAuthorization]
    public abstract class BaseController : Controller
    {
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected virtual void SuccessNotification(string message)
        {
            TempData[NotifyType.Success] = message;
        }

        protected virtual void ErrorNotification(string message)
        {
            TempData[NotifyType.Error] = message;
        }

        protected virtual object GetJson(string message, Enums.NotifyType notifyType)
        {
            return new { IsError = notifyType, Message = message };
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