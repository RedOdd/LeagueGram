using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public class PrivateChat : Chat, IMessageSender
    {
        public Guid tempMessageID;
        public PrivateChat(Guid creatorID, string creatorNickName, Guid invitedMemberID, string invitedMemberNickName, Guid chatID)
        {
            Members.Add(creatorID, new ChatMember(creatorID, creatorNickName, ChatMemberRole.User));
            Members.Add(invitedMemberID, new ChatMember(invitedMemberID, invitedMemberNickName, ChatMemberRole.User));
            chatStatus = ChatStatus.PrivateChat;
            ChatID = chatID;
        }
        

        public void SendMessage(Guid senderID,string text)
        {
            if (!Members[senderID].Equals(null))
            {
                tempMessageID = Guid.NewGuid();
                Messages.Add(tempMessageID, new Message(senderID, text));
            }
        }
    }
}
