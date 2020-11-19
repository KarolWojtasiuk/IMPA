using System;
using System.Linq;
using Xunit;

namespace IMPA.Tests
{
    public record TestObject : IIdentifiable
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; }
    }

    public class TestRepository : Repository<TestObject>
    {
        public TestRepository() : base(DatabaseTests.TestMongoContext, "TestCollection") { }

        public void ChangeName(Guid id, string name)
        {
            _dbContext.Update<TestObject>(id, "Name", name, _collectionName);
        }
    }

    public class DatabaseTests
    {
        public static MongoContext TestMongoContext = new MongoContext("mongodb+srv://testUser:testPassword@cluster-ktbsc.azure.mongodb.net", "TestDatabase");

        [Fact]
        public void MongoContextTest()
        {
            const string MongoCollectionName = "TestCollection";

            var obj = new TestObject { Name = "TestObject" };

            TestMongoContext.Insert(obj, MongoCollectionName);
            Assert.Equal(obj, TestMongoContext.Find<TestObject>(i => i.Id == obj.Id, MongoCollectionName).FirstOrDefault());

            TestMongoContext.Update<TestObject>(obj.Id, "Name", "NewValue", MongoCollectionName);
            Assert.Equal("NewValue", TestMongoContext.Find<TestObject>(i => i.Id == obj.Id, MongoCollectionName).FirstOrDefault()?.Name);

            obj = obj with { Name = "NewValue2" };
            TestMongoContext.Replace(obj, MongoCollectionName);
            Assert.Equal(obj, TestMongoContext.Find<TestObject>(i => i.Id == obj.Id, MongoCollectionName).FirstOrDefault());

            TestMongoContext.Delete<TestObject>(obj.Id, MongoCollectionName);
            Assert.Empty(TestMongoContext.Find<TestObject>(i => i.Id == obj.Id, MongoCollectionName));
        }

        [Fact]
        public void RepositoryTest()
        {
            var repository = new TestRepository();

            var obj = new TestObject();
            repository.Insert(obj);
            Assert.Equal(obj, repository.Get(obj.Id));

            repository.ChangeName(obj.Id, "Test");
            Assert.Equal("Test", repository.Get(obj.Id).Name);

            obj = obj with { Name = "Test2" };
            repository.Replace(obj);
            Assert.Equal(obj, repository.Get(obj.Id));
            Assert.Equal(obj, repository.Find(i => i.Name == "Test2").FirstOrDefault());

            repository.Delete(obj.Id);
            Assert.Throws<ItemDoesNotExistException>(() => repository.Get(obj.Id));
        }

        [Fact]
        public void DatabaseControllerTest()
        {
            var controller = new DatabaseController(TestMongoContext);

            Assert.NotNull(controller.Users);
            Assert.NotNull(controller.Channels);
        }
    }
}
