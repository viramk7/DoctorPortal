using DoctorPortal.Web.Areas.Admin.Models.ViewModels;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;

namespace DoctorPortal.Web.Areas.Admin.Repositories.Hospital
{
    public interface IHospitalInfoRepository : IRepository<HospitalMaster>
    {
        HospitalMaster GetHospitalById(int hospitalId);

        void SaveHospitalInfo(HospitalInfoViewModel hospital);
    }
}