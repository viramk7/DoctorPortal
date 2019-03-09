using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Areas.Admin.Models.ViewModels;
using DoctorPortal.Web.Areas.Admin.Repositories.Patient;
using DoctorPortal.Web.Database;
using System;
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

        public IEnumerable<PatientViewModel> GetAllPatient()
        {
            var facilities = _patientRepository.Table.ToList();
            return facilities.Select(s => new PatientViewModel(s));
        }

        public PatientViewModel GetById(int id)
        {
            var obj = _patientRepository.GetById(id);
            return new PatientViewModel(obj);
        }

        public PatientViewModel Save(PatientViewModel model)
        {
            var obj = model.GetPatientModel();

            if (obj.Id > 0)
            {
                _patientRepository.Update(obj);
            }
            else
            {
                _patientRepository.Insert(obj);
                model.Id = obj.Id;
            }

            return model;
        }

        public void Delete(int id)
        {
            var facility = _patientRepository.GetById(id);
            _patientRepository.Delete(facility);
        }

        public void ChangeStatus(int id)
        {
            var obj = _patientRepository.GetById(id);
            if (obj == null)
                throw new Exception("not found");

            obj.Active = !obj.Active;
            _patientRepository.Update(obj);
        }
    }
}