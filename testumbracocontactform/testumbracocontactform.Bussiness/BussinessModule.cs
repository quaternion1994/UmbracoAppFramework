using Autofac;
using testumbracocontactform.Bussiness.Impl;
using testumbracocontactform.Bussiness.Services;
using testumbracocontactform.Bussiness.Services.Impl;

namespace testumbracocontactform.Bussiness
{
    public class BussinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SendMessageProvider>().As<ISendMessageProvider>().InstancePerRequest();
            builder.RegisterType<ContactFormService>().As<IContactFormService>().InstancePerRequest();
        }
    }
}
