using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Repositories.Facility
{
    public class FacilityRepository : EfRepository<Database.Facility>, IFacilityRepository
    {
        public FacilityRepository(IDbContext context) : base(context)
        {

        }
    }
}