using System;
using testumbracocontactform.DataAccess.Entities;
using Umbraco.Core;

namespace testumbracocontactform.DataAccess.Repositories.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DatabaseContext _dbcontext;

        public UnitOfWork()
        {
            _dbcontext = ApplicationContext.Current.DatabaseContext;
        }

        private IRepository<MessageDto> _messageRepository;

        public IRepository<MessageDto> MessageRepository => _messageRepository ?? (_messageRepository = new Repository<MessageDto>(_dbcontext));

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
        }
    }
}