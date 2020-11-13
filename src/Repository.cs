using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace IMPA
{
    public abstract class Repository<T> : IRepository<T> where T : IIdentifiable
    {
        private readonly IDatabaseContext _dbContext;
        private readonly string _collectionName;

        public Repository(IDatabaseContext dbContext, string collectionName)
        {
            _dbContext = dbContext;
            _collectionName = collectionName;
        }

        public void Insert(T item)
        {
            _dbContext.Insert(item, _collectionName);
        }

        public void Update(T item)
        {
            _dbContext.Update(item, _collectionName);
        }

        public void Delete(Guid id)
        {
            _dbContext.Delete<T>(id, _collectionName);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Find(expression, _collectionName);
        }
    }
}
