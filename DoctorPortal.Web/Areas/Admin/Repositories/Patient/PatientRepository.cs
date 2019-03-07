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
    }
}