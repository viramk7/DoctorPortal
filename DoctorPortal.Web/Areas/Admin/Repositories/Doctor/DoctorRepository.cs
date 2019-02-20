using DoctorPortal.Web.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Repositories.Doctor
{
    public class DoctorRepository : EfRepository<Database.Doctor>, IDoctorRepository
    {
        public DoctorRepository(IDbContext context) : base(context)
        {
        }
    }
}