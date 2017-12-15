using System;
using testumbracocontactform.DataAccess.Entities;

namespace testumbracocontactform.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<MessageDto> MessageRepository { get; }
    }
}
