using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace IMPA
{
    public abstract class Repository<T> : IRepository<T> where T : IIdentifiable
    {
        protected readonly IDatabaseContext _dbContext;
        protected readonly string _collectionName;

        public Repository(IDatabaseContext dbContext, string collectionName)
        {
            _dbContext = dbContext;
            _collectionName = collectionName;
        }

        public void Insert(T item)
        {
            _dbContext.Insert(item, _collectionName);
        }

        public void Replace(T item)
        {
            _dbContext.Replace(item, _collectionName);
        }

        public void Delete(Guid id)
        {
            _dbContext.Delete<T>(id, _collectionName);
        }

        public T Get(Guid id)
        {
            var item = _dbContext.Find<T>(i => i.Id == id, _collectionName).FirstOrDefault();

            if (item is null)
            {
                throw new ItemDoesNotExistException(id, typeof(T));
            }

            return item;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Find(expression, _collectionName);
        }
    }
}
