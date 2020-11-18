using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMPA
{
    public class User : IIdentifiable
    {
        internal List<Interest> _interests = new List<Interest>();
        internal List<LocationRecord> _locationRecords = new List<LocationRecord>();

        public Guid Id { get; init; }
        public string Username { get; init; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public PersonalityType PersonalityType { get; set; }
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
        public DateTime CreationTime { get; init; }

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
            CreationTime = DateTime.UtcNow;
        }
    }
}
