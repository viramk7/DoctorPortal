using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Areas.Admin.Repositories.Patient;
using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Services.Patient
{
    public class PatientService: EntityService<PatientMaster>, IPatientService
    {
        public PatientService(IPatientRepository patientRepository) : base(patientRepository)
        {

        }
    }
}