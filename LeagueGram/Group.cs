using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public class Group : Chat, IMessageSender, IInviterUser
    {
        public Guid tempMessageID;
        public Group(Guid creatorID, string creatorNickName,Guid[] invitedMembersID,string[] invitedMembersNickName, Guid chatID)
        {
            Members.Add(creatorID, new ChatMember(creatorID, creatorNickName, ChatMemberRole.Creator));
            for (int count = 0; count < invitedMembersID.Length; count++)
            {
                Members.Add(invitedMembersID[count], new ChatMember(invitedMembersID[count], invitedMembersNickName[count], ChatMemberRole.User));
            }
            chatStatus = ChatStatus.Group;
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
            if (!Members[senderID].Equals(null))
            {
                tempMessageID = Guid.NewGuid();
                Messages.Add(tempMessageID, new Message(senderID, text));
            }
        }
    }
}
