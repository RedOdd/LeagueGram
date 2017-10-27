using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public class UserFacade
    {
        LeagueGram LeagueGram = new LeagueGram();

        public Chat GetChat(Guid chatID)
        {
            return LeagueGram.GetChat(chatID);
        }

        public PrivateChat GetPrivateChat(Guid chatID)
        {
            return (PrivateChat)LeagueGram.GetPrivateChat(chatID);
        }

        public Group GetGroup(Guid chatID)
        {
            return (Group)LeagueGram.GetGroup(chatID);
        }

        public Channel GetChannel(Guid chatID)
        {
            return (Channel)LeagueGram.GetChannel(chatID);
        }

        internal User GetUser(Guid userID)
        {
            return LeagueGram.GetUser(userID);
        }

        public void UserRegistration(string nickName, string phoneNumber, string email)
        {
            LeagueGram.UserRegistration(nickName, phoneNumber, email);
        }

        public ChatList ShowUsersChat(Guid userID)
        {
            return LeagueGram.ShowUsersChat(userID);
        }

        public void CreatePrivateChat(Guid creatorID, Guid inviteMemberID)
        {
            LeagueGram.CreatePrivateChat(creatorID, inviteMemberID);
        }

        public void CreateGroup(Guid creatorID, string creatorNickName, Guid[] invitedMembersID, string[] invitedMembersNickName)
        {
            LeagueGram.CreateGroup(creatorID, creatorNickName, invitedMembersID, invitedMembersNickName);
        }

        public void CreateChannel(Guid creatorID)
        {
            LeagueGram.CreateChannel(creatorID);
        }
    }
}
