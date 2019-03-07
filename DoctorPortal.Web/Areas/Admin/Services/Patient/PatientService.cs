using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Areas.Admin.Models.ViewModels;
using DoctorPortal.Web.Areas.Admin.Repositories.Patient;
using DoctorPortal.Web.Database;
using System.Collections.Generic;
using System.Linq;

namespace DoctorPortal.Web.Areas.Admin.Services.Patient
{
    public class PatientService: EntityService<PatientMaster>, IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository) : base(patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<PatientViewModel> GetPatientsByIds(string ids)
        {
            var patients = _patientRepository.GetPatientsByIds(ids);
            return patients.Select(s => new PatientViewModel(s));
        }
    }
}