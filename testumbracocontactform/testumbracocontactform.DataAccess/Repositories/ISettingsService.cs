using System.Collections.Generic;

namespace testumbracocontactform.DataAccess.Repositories
{
    public interface ISettingsService
    {
        IEnumerable<string> Recipients { get; }
        IEnumerable<string> Subjects { get; }
    }
}
