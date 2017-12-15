using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;

namespace testumbracocontactform.DataAccess.Repositories.Impl
{
    public class SettingsService : ISettingsService
    {
        private UmbracoHelper helper = new UmbracoHelper(UmbracoContext.Current);

        public IEnumerable<string> Recipients
        {
            get
            {
                return helper.TypedContentAtRoot()
                    .FirstOrDefault(x=>x.DocumentTypeAlias == "siteSettings")
                    .GetPropertyValue<string>("recipients")
                    .Split(new char[] { '\n', ',' });
            }
        }

        public IEnumerable<string> Subjects
        {
            get
            {
                return helper
                    .TypedContentAtRoot()
                    .FirstOrDefault(x => x.DocumentTypeAlias == "siteSettings")
                    .GetPropertyValue<string>("subjects").Split(new char[] { '\n' });
            }
        }
    }
}
