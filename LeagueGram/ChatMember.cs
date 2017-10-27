using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public  class ChatMember
    {
        public Guid ChatMemberID { get; }
        public string NickName { get; }
        public ChatMemberRole Role { get; set; }

        public ChatMember(Guid chatMemberID,string nickName,ChatMemberRole role)
        {
            ChatMemberID = chatMemberID;
            NickName = nickName;
            Role = role;
        }
    }
}
