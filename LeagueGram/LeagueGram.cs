using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("UnitTestProject1")]
namespace LeagueGram
{
    internal class LeagueGram
    {
        private static readonly Dictionary<Guid, User> _users = new Dictionary<Guid, User>();
        private static readonly Dictionary<Guid, Chat> _chats = new Dictionary<Guid, Chat>();
        public Guid tempGuid;

        public Dictionary<Guid,User> GetUsers()
        {
            return _users;
        }

        public Dictionary<Guid,Chat> GetChats()
        {
            return _chats;
        }

        public Chat GetChat(Guid chatID)
        {
            return _chats[chatID];
        }

        public PrivateChat GetPrivateChat(Guid chatID)
        {
            return (PrivateChat) _chats[chatID];
        }

        public Group GetGroup(Guid chatID)
        {
            return (Group) _chats[chatID];
        }

        public Channel GetChannel(Guid chatID)
        {
            return (Channel) _chats[chatID];
        }

        public User GetUser(Guid userID)
        {
            return _users[userID];
        }

        public void UserRegistration(string nickName, string phoneNumber, string email)
        {
            tempGuid = Guid.NewGuid();
            _users.Add(tempGuid, new User(tempGuid,nickName,phoneNumber,email));
        }

        public ChatList ShowUsersChat(Guid userID)
        {
            return _users[userID].GetChatList();
        }

        public void CreatePrivateChat(Guid creatorID, Guid inviteMemberID)
        {
            tempGuid = Guid.NewGuid();
            _chats.Add(tempGuid, new ChatFactory().CreatePrivateChat(creatorID, _users[creatorID].NickName, inviteMemberID, _users[inviteMemberID].NickName, tempGuid));
            _users[creatorID].chatList.Add(tempGuid);
            _users[inviteMemberID].chatList.Add(tempGuid);
        }

        public void CreateGroup(Guid creatorID, string creatorNickName, Guid[] invitedMembersID, string[] invitedMembersNickName)
        {
            tempGuid = Guid.NewGuid();
            _chats.Add(tempGuid, new ChatFactory().CreateGroup(creatorID, creatorNickName, invitedMembersID, invitedMembersNickName, tempGuid));
            _users[creatorID].chatList.Add(tempGuid);
            foreach (var tempInvitedMembersID in invitedMembersID)
            {
                _users[tempInvitedMembersID].chatList.Add(tempGuid);
            }
        }

        public void CreateChannel(Guid creatorID)
        {
            tempGuid = Guid.NewGuid();
            _chats.Add(tempGuid, new ChatFactory().CreateChannel(creatorID, _users[creatorID].NickName, tempGuid));
            _users[creatorID].chatList.Add(tempGuid);
        }
        
    }
}
