using testumbracocontactform.DataAccess.Entities;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace testumbracocontactform.DataAccess
{
    public class DbEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            DatabaseContext ctx = ApplicationContext.Current.DatabaseContext;
            DatabaseSchemaHelper dbSchema = new DatabaseSchemaHelper(ctx.Database, ApplicationContext.Current.ProfilingLogger.Logger, ctx.SqlSyntax);

            if (!dbSchema.TableExist("messagesCustomTable"))
                dbSchema.CreateTable<MessageDto>(true);
        }
    }
}
