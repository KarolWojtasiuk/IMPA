using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IMPA
{
    public record Channel : IIdentifiable, IEquatable<Channel>
    {
        internal List<Message> _messages = new();

        public Guid Id { get; init; }
        public ReadOnlyCollection<Guid> Users { get; init; }
        public ReadOnlyCollection<Message> Messages
        {
            get => _messages.AsReadOnly();
            init => _messages = value.ToList();
        }
        public DateTime CreationDate { get; init; }

        public Channel(Guid firstUser, Guid secondUser)
        {
            Id = Guid.NewGuid();
            Users = new(new List<Guid> { firstUser, secondUser });
            Messages = new(new List<Message>());
            CreationDate = DateTime.UtcNow;
        }

        public virtual bool Equals(Channel? other)
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
