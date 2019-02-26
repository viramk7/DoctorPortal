using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.Areas.Admin.Repositories.DepartmentImage;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DoctorPortal.Web.Areas.Admin.Services.DepartmentImage
{
    public class DepartmentImageService : EntityService<Database.DepartmentImages> ,IDepartmentImageService
    {
        private readonly IDepartmentImageRepository _iRepository;

        public DepartmentImageService(IDepartmentImageRepository repository) : base(repository)
        {
            _iRepository = repository;
        }

        public IEnumerable<DepartmentImageViewModel> GetAllDepartmentImages(int departmentid)
        {
            var list = _iRepository.Table.Where(m=>m.DepartmentId == departmentid).ToList();
            return list.Select(s => new DepartmentImageViewModel(s));
        }

        public DepartmentImageViewModel Save(DepartmentImageViewModel model)
        {
            var obj = model.GetDepartmentImagesEntity();

            if (obj.Id > 0)
            {
                _iRepository.Update(obj);
            }
            else
            {
                _iRepository.Insert(obj);
                model.Id = obj.Id;
            }

            return model;
        }

        public void Delete(int id)
        {
            var obj = _iRepository.GetById(id);
            _iRepository.Delete(obj);
        }

        

    }
}