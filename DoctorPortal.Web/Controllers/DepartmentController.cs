using DoctorPortal.Web.AdminServices.Department;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.Areas.Admin.Services.Facility;
using DoctorPortal.Web.Caching;
using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class DepartmentController : BaseAdminController
    {
        private readonly IDepartmentService _service;
        private readonly IFacilityService _servicefacility;

        public DepartmentController(IDepartmentService service, IFacilityService servicefacility ,IHospitalService hospitalService,
                             ICacheManager cacheManager) : base(hospitalService, cacheManager)
        {
            _service = service;
            _servicefacility = servicefacility;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DepartmentById(int id)
        {
            DepartmentViewModel departmnet = _service.GetDepartmentById(id);
            departmnet.serviceslist = _servicefacility.GetAllFacility();
            return View("Index", departmnet);
        }
    }
}