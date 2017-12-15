using Autofac;
using testumbracocontactform.DataAccess.Repositories;
using testumbracocontactform.DataAccess.Repositories.Impl;

namespace testumbracocontactform.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterType<SettingsService>().As<ISettingsService>().InstancePerRequest();
        }
    }
}
