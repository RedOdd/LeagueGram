using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public class Message
    {
        public Guid MessageID { get; }
        public string Text { get; set; }
        public Guid SenderID { get; }
        public DateTimeOffset SentOn { get; }

        public Message(Guid senderID, string text)
        {
            MessageID = Guid.NewGuid();
            SenderID = senderID;
            Text = text;
            SentOn = DateTimeOffset.Now;
        }
    }
}
