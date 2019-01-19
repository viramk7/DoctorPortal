using Autofac;
using DoctorPortal.Web.AdminRepositories.Hospital;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Repositories.Hospital;
using DoctorPortal.Web.Areas.Admin.Services.HospitalInfo;
using DoctorPortal.Web.Areas.Admin.Services.Login;
using DoctorPortal.Web.Areas.Admin.Services.User;
using DoctorPortal.Web.Caching;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;

namespace DoctorPortal.Web
{
    public class ServiceDependencyRegister
    {
        public static void Resolve(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>(ConfigItems.PortalName).SingleInstance();
            builder.RegisterType<DoctorPortalDBEntities>().As<IDbContext>().InstancePerDependency();

            // Repos
            builder.RegisterType<HospitalRepository>().As<IHospitalRepository>().InstancePerDependency();
            builder.RegisterType<HospitalInfoRepository>().As<IHospitalInfoRepository>().InstancePerDependency();

            // Services
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<HospitalService>().As<IHospitalService>().InstancePerDependency();
            builder.RegisterType<HospitalInfoService>().As<IHospitalInfoService>().InstancePerDependency();

        }
    }
}