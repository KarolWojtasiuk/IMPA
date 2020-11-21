using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace IMPA
{
    public class UsersRepository : Repository<User>
    {
        public UsersRepository(IDatabaseContext dbContext) : base(dbContext, "Users") { }

        public User Login(string username, string password)
        {
            var user = Find(u => u.Username == username).FirstOrDefault();
            if (user is null)
            {
                throw new LoginFailedException("User with given username not found.");
            }

            if (!user._password.VerifyPassword(password))
            {
                throw new LoginFailedException(user.Id, "Incorrect password");
            }

            return user;
        }

        public void ChangeFullName(Guid id, string fullName)
        {
            _dbContext.Update<User>(id, "FullName", fullName, _collectionName);
        }

        public void ChangeDescription(Guid id, string description)
        {
            _dbContext.Update<User>(id, "Description", description, _collectionName);
        }

        public void ChangePassword(Guid id, string password)
        {
            _dbContext.Update<User>(id, "Password", new Password(password), _collectionName);
        }

        public void ChangePersonalityType(Guid id, PersonalityType personalityType)
        {
            _dbContext.Update<User>(id, "PersonalityType", personalityType, _collectionName);
        }

        public void ChangeInterests(Guid id, ReadOnlyCollection<Interest> interests)
        {
            _dbContext.Update<User>(id, "Interests", interests, _collectionName);
        }

        public void AddInterest(Guid id, Interest interest)
        {
            var user = Get(id);
            user._interests.Add(interest);

            _dbContext.Update<User>(id, "Interests", user.Interests, _collectionName);
        }

        public void RemoveInterest(Guid id, Interest interest)
        {
            var user = Get(id);
            user._interests.Remove(interest);

            _dbContext.Update<User>(id, "Interests", user.Interests, _collectionName);
        }

        public void ChangeLocationRecord(Guid id, ReadOnlyCollection<LocationRecord> locationRecords)
        {
            _dbContext.Update<User>(id, "LocationRecords", locationRecords, _collectionName);
        }

        public void AddLocationRecord(Guid id, LocationRecord record)
        {
            var user = Get(id);
            user._locationRecords.Add(record);

            _dbContext.Update<User>(id, "LocationRecords", user.LocationRecords, _collectionName);
        }

        public void RemoveLocationRecord(Guid id, LocationRecord record)
        {
            var user = Get(id);
            user._locationRecords.Remove(record);

            _dbContext.Update<User>(id, "LocationRecords", user.LocationRecords, _collectionName);
        }

        public void ChangeHabits(Guid id, Habits habits)
        {
            _dbContext.Update<User>(id, "Habits", habits, _collectionName);
        }
    }
}
