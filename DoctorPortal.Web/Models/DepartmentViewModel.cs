﻿using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Models
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel()
        {

        }
        public DepartmentViewModel(Department department)
        {
            DepartmentId = department.DepartmentId;
            HospitalId = department.HospitalId;
            DepartmentName = department.DepartmentName;
            Description = department.Description;
            BannerImage = department.BannerImage;
        }
        public int DepartmentId { get; set; }
        public int HospitalId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string BannerImage { get; set; }
    }
}