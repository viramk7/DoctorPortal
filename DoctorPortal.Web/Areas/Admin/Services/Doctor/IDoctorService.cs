using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Services.Doctor
{
    public interface IDoctorService : IEntityService<Database.Doctor>
    {
        IEnumerable<DoctorViewModel> GetAllDoctorList();
        DoctorViewModel GetById(int id);
        DoctorViewModel Save(DoctorViewModel model);
        void Delete(int id);
        IEnumerable<DoctorViewModel> GetHomePageDoctorList();
    }
}