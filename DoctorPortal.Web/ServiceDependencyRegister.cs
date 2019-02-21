using Autofac;
using DoctorPortal.Web.AdminRepositories.Appointment;
using DoctorPortal.Web.AdminRepositories.Department;
using DoctorPortal.Web.AdminRepositories.FAQ;
using DoctorPortal.Web.AdminRepositories.Hospital;
using DoctorPortal.Web.AdminRepositories.Speciality;
using DoctorPortal.Web.AdminServices.Appointment;
using DoctorPortal.Web.AdminServices.Department;
using DoctorPortal.Web.AdminServices.Entity;
using DoctorPortal.Web.AdminServices.FAQ;
using DoctorPortal.Web.AdminServices.Hospital;
using DoctorPortal.Web.AdminServices.Speciality;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Areas.Admin.Repositories.Doctor;
using DoctorPortal.Web.Areas.Admin.Repositories.Facility;
using DoctorPortal.Web.Areas.Admin.Repositories.Hospital;
using DoctorPortal.Web.Areas.Admin.Repositories.Testimonials;
using DoctorPortal.Web.Areas.Admin.Services.Doctor;
using DoctorPortal.Web.Areas.Admin.Services.Facility;
using DoctorPortal.Web.Areas.Admin.Services.HospitalInfo;
using DoctorPortal.Web.Areas.Admin.Services.Login;
using DoctorPortal.Web.Areas.Admin.Services.Testimonials;
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
            builder.RegisterType<TestimonialsRepository>().As<ITestimonialsRepository>().InstancePerDependency();
            builder.RegisterType<FacilityRepository>().As<IFacilityRepository>().InstancePerDependency();
            builder.RegisterType<SpecialityRepository>().As<ISpecialityRepository>().InstancePerDependency();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>().InstancePerDependency();
            builder.RegisterType<DoctorRepository>().As<IDoctorRepository>().InstancePerDependency();
            builder.RegisterType<AppointmentRepository>().As<IAppointmentRepository>().InstancePerDependency();
            builder.RegisterType<FAQRepository>().As<IFAQRepository>().InstancePerDependency();

            // Services
            builder.RegisterGeneric(typeof(EntityService<>)).As(typeof(IEntityService<>)).InstancePerDependency();
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<HospitalService>().As<IHospitalService>().InstancePerDependency();
            builder.RegisterType<HospitalInfoService>().As<IHospitalInfoService>().InstancePerDependency();
            builder.RegisterType<TestimonialsService>().As<ITestimonialsService>().InstancePerDependency();
            builder.RegisterType<FacilityService>().As<IFacilityService>().InstancePerDependency();
            builder.RegisterType<SpecialityService>().As<ISpecialityService>().InstancePerDependency();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerDependency();
            builder.RegisterType<DoctorService>().As<IDoctorService>().InstancePerDependency();
            builder.RegisterType<AppointmentService>().As<IAppointmentService>().InstancePerDependency();
            builder.RegisterType<FAQService>().As<IFAQService>().InstancePerDependency();

        }
    }
}