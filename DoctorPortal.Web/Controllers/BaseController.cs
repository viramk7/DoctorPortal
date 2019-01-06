using DoctorPortal.Web.Models;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    [UserAuthorization]
    public class BaseController : Controller
    {

    }
    
    public sealed class UserAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = HttpContext.Current;

            if(ProjectSession.LoggedInUser == null)
            {
                filterContext.Result = new RedirectResult($"~/Login/Index?returnUrl={ctx.Request.Url}");
                return;
            }

            if (ProjectSession.LoggedInUser.IsSystemGeneratedPassword)
            {
                filterContext.Result = new RedirectResult($"~/Login/ResetPassword");
            }
        }
    }
}