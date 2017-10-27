using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    class User
    {
        public Guid UserID { get; }
        public string NickName { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public ChatList chatList = new ChatList();

        public User(Guid userID, string nickName, string phoneNumber, string email)
        {
            UserID = userID;
            NickName = nickName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public ChatList GetChatList()
        {
            return chatList;
        }        
    }
}
