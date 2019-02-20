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
            var list = _idoctorRepository.Table.Where(m=>m.IsOnHomePage == true).Take(4).ToList();
            return list.Select(s => new DoctorViewModel(s));
        }

        public DoctorViewModel GetById(int id)
        {
            var obj = _idoctorRepository.GetById(id);
            return new DoctorViewModel(obj);
        }

        public DoctorViewModel Save(DoctorViewModel model)
        {
            var obj = model.GetDoctorEntity();

            if (obj.DoctorId > 0)
            {
                _idoctorRepository.Update(obj);
            }
            else
            {
                _idoctorRepository.Insert(obj);
                model.DoctorId = obj.DoctorId;
            }

            return model;
        }

        public void Delete(int id)
        {
            var obj = _idoctorRepository.GetById(id);
            _idoctorRepository.Delete(obj);
        }
    }
}