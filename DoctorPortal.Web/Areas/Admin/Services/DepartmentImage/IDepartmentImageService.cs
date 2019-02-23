using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Services.DepartmentImage
{
    public interface IDepartmentImageService : IEntityService<DepartmentImages>
    {
        DepartmentImageViewModel Save(DepartmentImageViewModel model);
        void Delete(int id);
        IEnumerable<DepartmentImageViewModel> GetAllDepartmentImages(int departmentid);
    }
}