using System;
using DoctorPortal.Web.AdminServices.Department;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.Caching;
using System.Web.Mvc;
using log4net;

namespace DoctorPortal.Web.Controllers
{
    public class DepartmentController : BaseAdminController
    {
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service) 
        {
            _service = service;
        }

        public ActionResult Index(int id = 0)
        {
            try
            {
                var department = id == 0 ? _service.GetFirstDept() : _service.GetDepartmentById(id);
                return View(department);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return RedirectToAction(nameof(Index));
            }
            
        }
    }
}