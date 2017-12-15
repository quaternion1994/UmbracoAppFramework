using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Web;

namespace testumbracocontactform
{
    public class AppStartEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var builder = new ContainerBuilder();

            builder.Register(c => UmbracoContext.Current).AsSelf();

            builder.RegisterControllers(typeof(UmbracoApplication).Assembly, Assembly.GetExecutingAssembly());

            var assemblies = BuildManager.GetReferencedAssemblies()
                .Cast<Assembly>().Where(x=>x.FullName.StartsWith("testumbracocontactform"))
                .ToArray();
            builder.RegisterAssemblyModules(assemblies);

            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly, Assembly.GetExecutingAssembly());

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}