using System.Collections.Generic;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace testumbracocontactform.DataAccess.Repositories.Impl
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DatabaseContext _dbcontext;
        public Repository(DatabaseContext context)
        {
            _dbcontext = context;
        }

        public void Add(TEntity entity)
        {
            _dbcontext.Database.Insert(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbcontext.Database.Fetch<TEntity>(new Sql().Select("*").From<TEntity>()); //TODO find newer solution
        }

        public TEntity GetById(int id)
        {
            return _dbcontext.Database.Single<TEntity>(id);
        }

        public void Remove(TEntity entity)
        {
            _dbcontext.Database.Delete<TEntity>(entity);
        }

        public void Update(TEntity entity)
        {
            _dbcontext.Database.Save(entity);
        }
    }
}