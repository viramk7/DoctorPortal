using DoctorPortal.Web.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Repositories.DepartmentImage
{
    public class DepartmentImageRepository : EfRepository<Database.DepartmentImages>, IDepartmentImageRepository
    {
        public DepartmentImageRepository(IDbContext context) : base(context)
        {
        }
    }
}