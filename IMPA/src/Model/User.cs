using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MongoDB.Bson.Serialization.Attributes;
using System.Security.Cryptography;

namespace IMPA
{
    public record User : IIdentifiable, IEquatable<User>
    {
        internal List<Interest> _interests = new();
        internal List<LocationRecord> _locationRecords = new();
        [BsonElement("Password")]
        internal Password _password;

        public Guid Id { get; init; }
        public string Username { get; init; }
        public string FullName { get; init; }
        public string Description { get; init; }
        public PersonalityType PersonalityType { get; init; }
        public uint VisibilityDistance { get; init; }
        public ReadOnlyCollection<Interest> Interests
        {
            get => _interests.AsReadOnly();
            init => _interests = value.ToList();
        }
        public ReadOnlyCollection<LocationRecord> LocationRecords
        {
            get => _locationRecords.AsReadOnly();
            init => _locationRecords = value.ToList();
        }
        public Habits Habits { get; init; }
        public DateTime CreationDate { get; init; }

        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            FullName = String.Empty;
            Description = String.Empty;
            _password = new Password(password);
            PersonalityType = PersonalityType.Unkown;
            VisibilityDistance = 50;
            Interests = new(new List<Interest>());
            LocationRecords = new(new List<LocationRecord>());
            Habits = new();
            CreationDate = DateTime.UtcNow;
        }

        public virtual bool Equals(User? other)
        {
            if (other is null)
            {
                return false;
            }

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
