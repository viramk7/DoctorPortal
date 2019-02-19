using DoctorPortal.Web.AdminRepositories.Department;
using DoctorPortal.Web.Areas.Admin.Services.Facility;
using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.AdminServices.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFacilityService _servicefacility;

        public DepartmentService(IDepartmentRepository departmentRepository, 
                                 IFacilityService servicefacility)
        {
            _departmentRepository = departmentRepository;
            _servicefacility = servicefacility;
        }

        public DepartmentViewModel GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            var departmentViewModel = new DepartmentViewModel(department)
            {
                serviceslist = _servicefacility.GetAllFacility()
            };
            return departmentViewModel;
        }

        public DepartmentViewModel GetFirstDept()
        {
            var department = _departmentRepository.GetFirstDept();
            var departmentViewModel = new DepartmentViewModel(department)
            {
                serviceslist = _servicefacility.GetAllFacility()
            };
            return departmentViewModel;
        }
    }
}