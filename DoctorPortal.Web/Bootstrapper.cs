using Autofac;
using Autofac.Integration.Mvc;
using System.Web;
using System.Web.Mvc;

namespace DoctorPortal.Web
{
    public static class Bootstrapper
    {
        ////   public static string assemblyIncludingPattern;

        /// <summary>
        /// Resolves the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void Resolve(ContainerBuilder builder)
        {
            if (HttpContext.Current != null)
            {
                builder.Register(c =>
                 new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
                   .As<HttpContextBase>()
                   .InstancePerDependency();
            }

            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerDependency();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerDependency();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerDependency();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerDependency();

            ////builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => !t.IsAbstract && typeof(ApiController).IsAssignableFrom(t))
            ////    .InstancePerMatchingLifetimeScope();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            ServiceDependencyRegister.Resolve(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
           
            ////// Create the depenedency resolver.
            //var resolver = new AutofacWebApiDependencyResolver(container);

            ////// Configure Web API with the dependency resolver.
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}