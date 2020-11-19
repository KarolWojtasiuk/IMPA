using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace IMPA
{
    public interface IDatabaseContext
    {
        public void Insert<T>(T item, string collectionName) where T : IIdentifiable;
        public void Update<T>(Guid id, string fieldName, object value, string collectionName) where T : IIdentifiable;
        public void Replace<T>(T item, string collectionName) where T : IIdentifiable;
        public void Delete<T>(Guid id, string collectionName) where T : IIdentifiable;
        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> expression, string collectionName) where T : IIdentifiable;
    }
}
