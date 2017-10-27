using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public class Channel : Chat, IMessageSender, IInviterUser
    {
        public Guid tempMessageID;
        public Channel(Guid creatorID, string creatorNickName, Guid chatID)
        {
            Members.Add(creatorID, new ChatMember(creatorID, creatorNickName, ChatMemberRole.Creator));
            chatStatus = ChatStatus.Channel;
            ChatID = chatID;
        }

        public void InviteUser(Guid inviterID, Guid inviteUserID)
        {
            if ((Members.ContainsKey(inviterID)) && (!(Members.ContainsKey(inviteUserID))))
            {
                Members.Add(inviteUserID, new ChatMember(inviteUserID, new LeagueGram().GetUser(inviteUserID).NickName, ChatMemberRole.User));
                new LeagueGram().GetUser(inviteUserID).chatList.Add(ChatID);
            }
        }

        public void SendMessage(Guid senderID, string text)
        {
            if ((Members[senderID].Role == ChatMemberRole.Creator) || (Members[senderID].Role == ChatMemberRole.Admin))
            {
                tempMessageID = Guid.NewGuid();
                Messages.Add(tempMessageID, new Message(senderID, text));
            }
        }
    }
}
