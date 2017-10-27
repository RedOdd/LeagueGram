using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public class ChatList
    {
        private static readonly Dictionary<Guid, Chat> usersChats = new Dictionary<Guid, Chat>();

        public void Add(Guid chatID)
        {
            if (!usersChats.ContainsValue(new LeagueGram().GetChat(chatID)))
            {
                usersChats.Add(chatID, new LeagueGram().GetChat(chatID));
            }
        }
        
        public Chat GetChat(Guid chatID)
        {
            return usersChats[chatID];
        }
    }
}
