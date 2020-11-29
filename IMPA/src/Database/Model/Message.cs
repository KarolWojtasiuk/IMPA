using System;

namespace IMPA
{
    public class Message
    {
        public Guid Sender { get; private set; }
        public string Content { get; private set; }
        public DateTime CreationDate { get; private set; }

        public Message(Guid sender, string content)
        {
            Sender = sender;
            Content = content;
            CreationDate = DateTime.UtcNow;
        }
    }
}
