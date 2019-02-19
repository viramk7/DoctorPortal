using DoctorPortal.Web.AdminRepositories.Department;
using DoctorPortal.Web.Models;

namespace DoctorPortal.Web.AdminServices.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public DepartmentViewModel GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            return new DepartmentViewModel(department);
        }

        public DepartmentViewModel GetFirstDept()
        {
            var department = _departmentRepository.GetFirstDept();
            return new DepartmentViewModel(department);
        }
    }
}