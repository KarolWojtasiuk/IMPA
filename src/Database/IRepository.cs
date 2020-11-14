using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace IMPA
{
    public interface IRepository<T> where T : IIdentifiable
    {
        public void Insert(T item);
        public void Update(T item);
        public void Delete(Guid id);
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}
