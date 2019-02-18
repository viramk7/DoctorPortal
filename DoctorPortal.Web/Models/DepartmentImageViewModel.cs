using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Models
{
    public class DepartmentImageViewModel
    {
        public DepartmentImageViewModel()
        {

        }

        public DepartmentImageViewModel(DepartmentImages departmentImage)
        {
            Id = departmentImage.Id;
            DepartmentId = departmentImage.DepartmentId;
            ImageName = departmentImage.ImageName;
        }

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string ImageName { get; set; }
    }
}