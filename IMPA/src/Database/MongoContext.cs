using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace IMPA
{
    public class MongoContext : IDatabaseContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(string connectionString, string databaseName)
        {
            _database = new MongoClient(connectionString).GetDatabase(databaseName);
        }

        public void Insert<T>(T item, string collectionName) where T : IIdentifiable
        {
            _database.GetCollection<T>(collectionName).InsertOne(item);
        }

        public void Update<T>(Guid id, string fieldName, object value, string collectionName) where T : IIdentifiable
        {
            _database.GetCollection<T>(collectionName).UpdateOne(i => i.Id == id, Builders<T>.Update.Set(fieldName, value));
        }

        public void Replace<T>(T item, string collectionName) where T : IIdentifiable
        {
            _database.GetCollection<T>(collectionName).ReplaceOne(i => i.Id == item.Id, item);
        }

        public void Delete<T>(Guid id, string collectionName) where T : IIdentifiable
        {
            _database.GetCollection<T>(collectionName).DeleteOne(i => i.Id == id);
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> expression, string collectionName) where T : IIdentifiable
        {
            return _database.GetCollection<T>(collectionName).Find(expression).ToList();
        }
    }
}
