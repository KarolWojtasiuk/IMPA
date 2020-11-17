using System;
using System.Collections.Generic;

namespace IMPA
{
    public class UsersRepository : Repository<User>
    {
        public UsersRepository(IDatabaseContext dbContext) : base(dbContext, "Users") { }

        public void ChangeFullName(Guid id, string fullName)
        {
            _dbContext.Update<User>(id, "FullName", fullName, _collectionName);
        }

        public void ChangeDescription(Guid id, string description)
        {
            _dbContext.Update<User>(id, "Description", description, _collectionName);
        }

        public void ChangePersonalityType(Guid id, PersonalityType personalityType)
        {
            _dbContext.Update<User>(id, "PersonalityType", personalityType, _collectionName);
        }

        public void ChangeInterests(Guid id, List<Interest> interests)
        {
            _dbContext.Update<User>(id, "Interests", interests, _collectionName);
        }

        public void AddInterest(Guid id, Interest interest)
        {
            var user = Get(id);
            user.Interests.Add(interest);

            _dbContext.Update<User>(id, "Interests", user.Interests, _collectionName);
        }

        public void RemoveInterest(Guid id, Interest interest)
        {
            var user = Get(id);
            user.Interests.Remove(interest);

            _dbContext.Update<User>(id, "Interests", user.Interests, _collectionName);
        }

        public void ChangeLocationRecord(Guid id, List<LocationRecord> locationRecords)
        {
            _dbContext.Update<User>(id, "LocationRecords", locationRecords, _collectionName);
        }

        public void AddLocationRecord(Guid id, LocationRecord record)
        {
            var user = Get(id);
            user.LocationRecords.Add(record);

            _dbContext.Update<User>(id, "LocationRecords", user.LocationRecords, _collectionName);
        }

        public void RemoveLocationRecord(Guid id, LocationRecord record)
        {
            var user = Get(id);
            user.LocationRecords.Remove(record);

            _dbContext.Update<User>(id, "LocationRecords", user.LocationRecords, _collectionName);
        }

        public void ChangeHabits(Guid id, Habits habits)
        {
            _dbContext.Update<User>(id, "Habits", habits, _collectionName);
        }
    }
}
