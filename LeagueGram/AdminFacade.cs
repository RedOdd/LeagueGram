using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public class AdminFacade
    {
        LeagueGram LeagueGram = new LeagueGram();

        internal Dictionary<Guid, User> GetUsers()
        {
            return LeagueGram.GetUsers();
        }

        internal Dictionary<Guid, Chat> GetChats()
        {
            return LeagueGram.GetChats();
        }
    }
}
