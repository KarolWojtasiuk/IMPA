using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MongoDB.Bson.Serialization.Attributes;

namespace IMPA
{
    public record User : IIdentifiable, IEquatable<User>
    {
        internal List<Interest> _interests = new();
        [BsonElement("LocationRecords")]
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
        public Habits Habits { get; init; }
        public DateTime CreationDate { get; init; }

        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            VerifyUsername();
            VerifyPassword(password);
            FullName = String.Empty;
            Description = String.Empty;
            _password = new Password(password);
            PersonalityType = PersonalityType.Unkown;
            VisibilityDistance = 50;
            Interests = new(new List<Interest>());
            Habits = new();
            CreationDate = DateTime.UtcNow;
        }

        private void VerifyUsername()
        {
            if (Username.Length < 5)
            {
                throw new ModelVerificationException(Id, typeof(User), "Username should contain at least 5 characters.");
            }
        }

        private void VerifyPassword(string password)
        {
            if (password.Length < 5)
            {
                throw new ModelVerificationException(Id, typeof(User), "Password should contain at least 5 characters.");
            }
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
