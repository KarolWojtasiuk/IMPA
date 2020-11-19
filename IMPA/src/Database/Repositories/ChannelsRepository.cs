using System;
using System.Collections.ObjectModel;

namespace IMPA
{
    public class ChannelsRepository : Repository<Channel>
    {
        public ChannelsRepository(IDatabaseContext dbContext) : base(dbContext, "Channels") { }

        public void ChangeMessages(Guid id, ReadOnlyCollection<Message> messages)
        {
            _dbContext.Update<Channel>(id, "Messages", messages, _collectionName);
        }

        public void AddMessage(Guid id, Message message)
        {
            var channel = Get(id);
            channel._messages.Add(message);

            _dbContext.Update<Channel>(id, "Messages", channel.Messages, _collectionName);
        }

        public void RemoveMessage(Guid id, Message message)
        {
            var channel = Get(id);
            channel._messages.Remove(message);

            _dbContext.Update<Channel>(id, "Messages", channel.Messages, _collectionName);
        }
    }
}
