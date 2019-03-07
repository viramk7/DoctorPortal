using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Repositories.Patient
{
    public class PatientRepository : EfRepository<PatientMaster>, IPatientRepository
    {
        public PatientRepository(IDbContext context) : base(context)
        {
            
        }

        public IEnumerable<PatientMaster> GetPatientsByIds(string ids)
        {
            if (string.IsNullOrEmpty(ids))
                throw new ArgumentNullException("ids");

            var idArray = ids.Split(',');
            return Entities.Where(w => idArray.Contains(w.Id.ToString()));
        }


    }
}