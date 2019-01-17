using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoctorPortal.Web.Filters
{
    public sealed class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public enum AdminModule
        {
            Title,
            TitleAttributes,
            TitleType,
            TitleTypeRelation,
            ServiceFields,
            ServiceTerritory,
            ServiceLanguage
        }

        public AdminModule Rights { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            const string userRights = "Title,TitleType";
            return userRights.Contains(Rights.ToString());
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Unauthorised" }));
        }
    }

    public sealed class AjaxErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.Exception == null)
                return;

            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            filterContext.Result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    filterContext.Exception.Message,
                    filterContext.Exception.StackTrace
                }
            };

            filterContext.ExceptionHandled = true;
        }
    }
}