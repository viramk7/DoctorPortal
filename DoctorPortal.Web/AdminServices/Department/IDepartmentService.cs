﻿using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.AdminServices.Department
{
    public interface IDepartmentService
    {
        DepartmentViewModel GetDepartmentById(int id);

        DepartmentViewModel GetFirstDept();

        List<DepartmentViewModel> GetAllDepartment();

        DepartmentViewModel Save(DepartmentViewModel model);

        void Delete(int id);

        List<DepartmentViewModel> GetAllActiveDepartment();

        void ChangeStatus(int id);

    }
}