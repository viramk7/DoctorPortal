using DoctorPortal.Web.Database;

namespace DoctorPortal.Web.AdminRepositories.Hospital
{
    public interface IHospitalRepository
    {
        HospitalMaster GetHospitalInfo();
    }
}
