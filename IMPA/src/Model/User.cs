using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMPA
{
    public class User : IIdentifiable, IEquatable<User>
    {
        internal List<Interest> _interests = new();
        internal List<LocationRecord> _locationRecords = new();

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

        public User(string username)
        {
            Id = Guid.NewGuid();
            Username = username;
            FullName = String.Empty;
            Description = String.Empty;
            PersonalityType = PersonalityType.Unkown;
            VisibilityDistance = 50;
            Interests = new(new List<Interest>());
            LocationRecords = new(new List<LocationRecord>());
            Habits = new();
            CreationDate = DateTime.UtcNow;
        }

        public bool Equals(User? other)
        {
            if (other is null)
            {
                return false;
            }

            return Id == other.Id;
        }

        public override bool Equals(object? obj) => Equals(obj as User);
        public override int GetHashCode() => Id.GetHashCode();
    }
}
