using DoctorPortal.Web.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Repositories.Doctor
{
    public interface IDoctorRepository : IRepository<Database.Doctor>
    {
    }
}