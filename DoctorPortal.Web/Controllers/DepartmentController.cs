﻿using DoctorPortal.Web.AdminServices.Department;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.Caching;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class DepartmentController : BaseAdminController
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service) 
        {
            _service = service;
        }

        public ActionResult Index(int id = 0)
        {
            var department = id == 0 ? _service.GetFirstDept() : _service.GetDepartmentById(id);
            return View(department);
        }

        public ActionResult GetDepartmentPartialView()
        {
            var departments = _service.GetAllDepartment();
            return PartialView("_Departments", departments);
        }

    }
}