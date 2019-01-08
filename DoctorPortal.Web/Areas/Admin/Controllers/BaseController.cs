using System.Web;
using System.Web.Mvc;
using DoctorPortal.Web.Areas.Admin.Models;
using log4net;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    [UserAuthorization]
    public class BaseController : Controller
    {
        // ReSharper disable once InconsistentNaming
        protected readonly ILog _logger;

        public BaseController()
        {
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
    
    public sealed class UserAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = HttpContext.Current;

            if(ProjectSession.LoggedInUser == null)
            {
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