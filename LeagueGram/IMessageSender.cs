using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public interface IMessageSender
    {
       void SendMessage(Guid senderID,string text);
    }
}
