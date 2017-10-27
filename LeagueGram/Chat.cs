using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public abstract class Chat
    {
        public Guid ChatID { get; set; }
        public Dictionary<Guid, Message> Messages = new Dictionary<Guid, Message>();
        public Dictionary<Guid, ChatMember> Members = new Dictionary<Guid, ChatMember>();
        public ChatStatus chatStatus;

        public void UpRole(Guid heighteningID, Guid upperID)
        {
            if (Members[heighteningID].Role == ChatMemberRole.Creator)
            {
                Members[upperID].Role = ChatMemberRole.Admin;
            }   
        }

        public void DownRole(Guid loweringID, Guid downID)
        {
            if (Members[loweringID].Role == ChatMemberRole.Creator)
            {
                Members[downID].Role = ChatMemberRole.User;
            }
        }

        public void EditMessage(Guid editorID, Guid messagesID,string text) 
        {
            if (Messages[messagesID].SenderID == Members[editorID].ChatMemberID)
            {
                Messages[messagesID].Text = text;
            }
        }

        public void DeleteMessage(Guid killerID, Guid messagesID)
        {
            if ((Messages[messagesID].SenderID == Members[killerID].ChatMemberID) || (Members[killerID].Role == ChatMemberRole.Admin) || (Members[killerID].Role==ChatMemberRole.Creator))
            {
                Messages.Remove(messagesID);
            }
        }
    }
}
