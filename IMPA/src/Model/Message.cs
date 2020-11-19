using System;

namespace IMPA
{
    public struct Message
    {
        public Guid Sender;
        public string Content;
        public DateTime CreationDate;

        public Message(Guid sender, string content)
        {
            Sender = sender;
            Content = content;
            CreationDate = DateTime.UtcNow;
        }
    }
}
