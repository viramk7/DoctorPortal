using DoctorPortal.Web.Areas.Admin.Models.ViewModels;

namespace DoctorPortal.Web.Areas.Admin.Services.HospitalInfo
{
    public interface IHospitalInfoService
    {
        void SaveHospitalInfo(HospitalInfoViewModel hospital);

        HospitalInfoViewModel GetHospitalById(int hospitalId);
    }
}
