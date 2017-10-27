using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public class ChatFactory
    {
        public PrivateChat CreatePrivateChat(Guid creatorID, string creatorNickName, Guid invitedMemberID, string invitedMemberNickName, Guid chatID)
        {
            return new PrivateChat(creatorID, creatorNickName, invitedMemberID, invitedMemberNickName, chatID);
        }

        public Group CreateGroup(Guid creatorID, string creatorNickName, Guid[] invitedMembersID, string[] invitedMembersNickName, Guid chatID)
        {
            return new Group(creatorID, creatorNickName, invitedMembersID, invitedMembersNickName, chatID);
        }

        public Channel CreateChannel(Guid creatorID, string creatorNickName, Guid chatID)
        {
            return new Channel(creatorID, creatorNickName, chatID);
        }

    }
}
