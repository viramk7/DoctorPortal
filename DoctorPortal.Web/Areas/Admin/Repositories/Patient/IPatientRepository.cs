using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPortal.Web.Areas.Admin.Repositories.Patient
{
    public interface IPatientRepository : IRepository<PatientMaster>
    {
        IEnumerable<PatientMaster> GetPatientsByIds(string ids);
    }
}
