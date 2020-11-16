using System;
using System.Collections.Generic;

namespace IMPA
{
    public class User : IIdentifiable
    {
        public Guid Id { get; init; }
        public string Username { get; init; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public PersonalityType PersonalityType { get; set; }
        public List<Interest> Interests { get; init; }
        public List<LocationRecord> LocationRecords { get; init; }
        public Habits Habits { get; init; }
        public DateTime CreationTime { get; init; }

        public User(string username)
        {
            Id = Guid.NewGuid();
            Username = username;
            FullName = String.Empty;
            Description = String.Empty;
            PersonalityType = PersonalityType.Unkown;
            Interests = new();
            LocationRecords = new();
            Habits = new();
            CreationTime = DateTime.UtcNow;
        }
    }
}
