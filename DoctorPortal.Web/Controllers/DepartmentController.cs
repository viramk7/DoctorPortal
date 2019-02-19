using DoctorPortal.Web.AdminServices.Department;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.Caching;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class DepartmentController : BaseAdminController
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IHospitalService hospitalService,
                                    ICacheManager cacheManager,
                                    IDepartmentService service) 
                                    : base(hospitalService, cacheManager)
        {
            _service = service;
        }

        public ActionResult Index(int id = 0)
        {
            var department = id == 0 ? _service.GetFirstDept() : _service.GetDepartmentById(id);
            return View(department);
        }
    }
}