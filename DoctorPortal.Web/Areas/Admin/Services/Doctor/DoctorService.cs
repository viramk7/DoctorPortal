using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Areas.Admin.Repositories.Doctor;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;
using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Services.Doctor
{
    public class DoctorService : EntityService<Database.Doctor>, IDoctorService
    {
        private readonly IDoctorRepository _idoctorRepository;

        public DoctorService(IDoctorRepository repository) : base(repository)
        {
            _idoctorRepository = repository;
        }

        public IEnumerable<DoctorViewModel> GetAllDoctorList()
        {
            var list = _idoctorRepository.Table.ToList();
            return list.Select(s => new DoctorViewModel(s));
        }

        public IEnumerable<DoctorViewModel> GetHomePageDoctorList()
        {
            var list = _idoctorRepository.Table.Where(m=>m.IsOnHomePage == true && m.IsActive == true).Take(4).ToList();
            return list.Select(s => new DoctorViewModel(s));
        }

        public DoctorViewModel GetById(int id)
        {
            var obj = _idoctorRepository.GetById(id);
            if (obj == null)
                throw new Exception("not found");

            return new DoctorViewModel(obj);
        }

        public DoctorViewModel Save(DoctorViewModel model)
        {
            if (model.DoctorId > 0)
            {
                var doctor = _idoctorRepository.GetById(model.DoctorId);
                if(doctor == null)
                    throw  new Exception("Not found");

                doctor.Name = model.Name;
                doctor.Position = model.Position;
                doctor.ContactNo = model.ContactNo;
                doctor.EmailAddress = model.EmailAddress;
                doctor.ImageName = model.ImageName;
                doctor.SpecialityId = model.SpecialityId;
                doctor.IsOnHomePage = model.IsOnHomePage;
                doctor.IsActive = model.IsActive;

                _idoctorRepository.Update(doctor);
            }
            else
            {
                var doctor = model.GetDoctorEntity();
                _idoctorRepository.Insert(doctor);
                model.DoctorId = doctor.DoctorId;
            }

            return model;
        }

        public void Delete(int id)
        {
            var obj = _idoctorRepository.GetById(id);
            _idoctorRepository.Delete(obj);
        }

        public void ChangeStatus(int id)
        {
            var doctor = _idoctorRepository.GetById(id);
            if(doctor == null)
                throw new Exception("not found");

            doctor.IsActive = !doctor.IsActive;
            _idoctorRepository.Update(doctor);
        }

    }
}