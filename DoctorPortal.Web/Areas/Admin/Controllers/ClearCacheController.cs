using DoctorPortal.Web.Caching;
using DoctorPortal.Web.Common;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace DoctorPortal.Web.Areas.Admin.Controllers
{
    public class ClearCacheController : BaseController
    {
        private readonly ICacheManager _cacheManager;

        public ClearCacheController(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public ActionResult Index()
        {
            var values = Utility.GetEnumValues<CacheKeys>();
            values.ForEach(s => _cacheManager.Remove(s.ToString())); 
            
            SuccessNotification("Cache cleared successfully.");
            return RedirectToAction("Index", "AdminHome");
        }
    }
}