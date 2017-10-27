using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueGram;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

[assembly: InternalsVisibleToAttribute("LeagueGram")]
namespace UnitTests
{
    [TestClass]
    public class UnitTestLeagueGram
    {

        [TestMethod]
        public void LeagueGram_GetChats()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            Assert.IsFalse(lg.GetChats().Equals(null));
        }

        [TestMethod]
        public void LeagueGram_GetUsers()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            Assert.IsFalse(lg.GetUsers().Equals(null));
        }

        [TestMethod]
        public void LeagueGram_ShowUsersChat()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            Assert.IsFalse(lg.ShowUsersChat(testUserGyidFirst).Equals(null));
        }

        [TestMethod]
        public void LeagueGram_UserRegistration()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyid = lg.tempGuid;

            Assert.IsTrue(lg.GetUser(testUserGyid).UserID.Equals(testUserGyid));
        }

        [TestMethod]
        public void LeagueGram_PrivateChatCreate()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.CreatePrivateChat(testUserGyidFirst, testUserGyidSecound);
            Guid privateChatGuid = lg.tempGuid;

            Assert.IsTrue(lg.GetPrivateChat(privateChatGuid).ChatID.Equals(privateChatGuid));
        }

        [TestMethod]
        public void LeagueGram_GroupeCreate()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            Assert.IsTrue(lg.GetGroup(testGroupID).Members[testUserGyidThird].ChatMemberID.Equals(testUserGyidThird));
        }

        [TestMethod]
        public void LeagueGram_ChannelCreate()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.CreateChannel(testUserGyidFirst);
            Guid testChannelGuid = lg.tempGuid;

            Assert.IsTrue(lg.GetChannel(testChannelGuid).ChatID.Equals(testChannelGuid));
        }

        [TestMethod]
        public void User_GetChatList()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            Assert.IsFalse(lg.GetUser(testUserGyidFirst).GetChatList().Equals(null));
        }

        [TestMethod]
        public void PrivateChat_Send()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.CreatePrivateChat(testUserGyidFirst, testUserGyidSecound);
            Guid privateChatGuid = lg.tempGuid;
            lg.GetPrivateChat(privateChatGuid).SendMessage(testUserGyidFirst, "test");
            Guid tempMessageID = lg.GetPrivateChat(privateChatGuid).tempMessageID;
            Assert.AreEqual(lg.GetPrivateChat(privateChatGuid).Messages[tempMessageID].Text, "test");
        }

        [TestMethod]
        public void Chat_UpRoleGroupCreator()
        {

            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidRole = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidRole };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidRole).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).UpRole(testUserGyidFirst, testUserGyidRole);

            Assert.IsTrue(lg.GetGroup(testGroupID).Members[testUserGyidRole].Role == ChatMemberRole.Admin);
        }

        [TestMethod]
        public void Chat_UpRoleGroupAdmin()
        {

            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidRole = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidRole };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidRole).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).UpRole(testUserGyidFirst, testUserGyidRole);

            lg.GetGroup(testGroupID).UpRole(testUserGyidRole, testUserGyidSecound);

            Assert.IsFalse(lg.GetGroup(testGroupID).Members[testUserGyidSecound].Role == ChatMemberRole.Admin);
        }

        [TestMethod]
        public void Chat_UpRoleGroupUser()
        {

            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidRole = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidRole };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidRole).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).UpRole(testUserGyidSecound, testUserGyidRole);

            Assert.IsFalse(lg.GetGroup(testGroupID).Members[testUserGyidRole].Role == ChatMemberRole.Admin);
        }

        [TestMethod]
        public void Chat_DownRoleGroupCreator()
        {

            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidRole = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidRole };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidRole).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).UpRole(testUserGyidFirst, testUserGyidRole);

            lg.GetGroup(testGroupID).DownRole(testUserGyidFirst, testUserGyidRole);

            Assert.IsTrue(lg.GetGroup(testGroupID).Members[testUserGyidRole].Role == ChatMemberRole.User);
        }

        [TestMethod]
        public void Chat_DownRoleGroupAdmin()
        {

            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidRole = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidRole };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidRole).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).UpRole(testUserGyidFirst, testUserGyidRole);
            lg.GetGroup(testGroupID).UpRole(testUserGyidFirst, testUserGyidSecound);

            lg.GetGroup(testGroupID).DownRole(testUserGyidRole, testUserGyidSecound);

            Assert.IsTrue(lg.GetGroup(testGroupID).Members[testUserGyidSecound].Role == ChatMemberRole.Admin);
        }

        [TestMethod]
        public void Chat_DownRoleGroupUser()
        {

            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidRole = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidRole };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidRole).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).UpRole(testUserGyidFirst, testUserGyidRole);

            lg.GetGroup(testGroupID).DownRole(testUserGyidSecound, testUserGyidRole);

            Assert.IsFalse(lg.GetGroup(testGroupID).Members[testUserGyidRole].Role == ChatMemberRole.User);
        }

        [TestMethod]
        public void Group_InviteCreator()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.UserRegistration("g3", "83", "i3");
            Guid testUserGyidInvite = lg.tempGuid;

            lg.GetGroup(testGroupID).InviteUser(testUserGyidFirst, testUserGyidInvite);

            Assert.IsFalse(lg.GetGroup(testGroupID).Members[testUserGyidInvite].Equals(null));
        }

        [TestMethod]
        public void Group_InviteAdmin()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.UserRegistration("g3", "83", "i3");
            Guid testUserGyidInvite = lg.tempGuid;

            lg.GetGroup(testGroupID).UpRole(testUserGyidFirst, testUserGyidSecound);

            lg.GetGroup(testGroupID).InviteUser(testUserGyidSecound, testUserGyidInvite);

            Assert.IsFalse(lg.GetGroup(testGroupID).Members[testUserGyidInvite].Equals(null));
        }

        [TestMethod]
        public void Group_InviteUser()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.UserRegistration("g3", "83", "i3");
            Guid testUserGyidInvite = lg.tempGuid;

            lg.GetGroup(testGroupID).InviteUser(testUserGyidSecound, testUserGyidInvite);

            Assert.IsFalse(lg.GetGroup(testGroupID).Members[testUserGyidInvite].Equals(null));
        }

        [TestMethod]
        public void Group_SendMessage()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).SendMessage(testUserGyidFirst, "test");
            Guid testMessageID = lg.GetGroup(testGroupID).tempMessageID;

            Assert.AreEqual(lg.GetGroup(testGroupID).Messages[testMessageID].Text, ("test"));
        }

        [TestMethod]
        public void Channel_InviteCreator()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.CreateChannel(testUserGyidFirst);
            Guid testChannelGuid = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidInvite = lg.tempGuid;

            lg.GetChannel(testChannelGuid).InviteUser(testUserGyidFirst, testUserGyidInvite);

            Assert.IsTrue(lg.GetChannel(testChannelGuid).Members.ContainsKey(testUserGyidInvite));
        }

        [TestMethod]
        public void Channel_InviteUser()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.CreateChannel(testUserGyidFirst);
            Guid testChannelGuid = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.GetChannel(testChannelGuid).InviteUser(testUserGyidFirst, testUserGyidSecound);

            lg.UserRegistration("g3", "83", "i3");
            Guid testUserGyidInvite = lg.tempGuid;

            lg.GetChannel(testChannelGuid).InviteUser(testUserGyidSecound, testUserGyidInvite);

            Assert.IsTrue(lg.GetChannel(testChannelGuid).Members.ContainsKey(testUserGyidInvite));
        }

        [TestMethod]
        public void Channel_UpRoleCreator()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.CreateChannel(testUserGyidFirst);
            Guid testChannelGuid = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.GetChannel(testChannelGuid).InviteUser(testUserGyidFirst, testUserGyidSecound);
            lg.GetChannel(testChannelGuid).UpRole(testUserGyidFirst, testUserGyidSecound);

            Assert.IsTrue(lg.GetChannel(testChannelGuid).Members[testUserGyidSecound].Role == ChatMemberRole.Admin);
        }

        [TestMethod]
        public void Channel_UpRoleAdmin()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.CreateChannel(testUserGyidFirst);
            Guid testChannelGuid = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.GetChannel(testChannelGuid).InviteUser(testUserGyidFirst, testUserGyidSecound);
            lg.GetChannel(testChannelGuid).UpRole(testUserGyidFirst, testUserGyidSecound);

            lg.UserRegistration("g3", "83", "i33");
            Guid testUserGyidTirhd = lg.tempGuid;

            lg.GetChannel(testChannelGuid).InviteUser(testUserGyidSecound, testUserGyidTirhd);
            lg.GetChannel(testChannelGuid).UpRole(testUserGyidSecound, testUserGyidTirhd);

            Assert.IsTrue(lg.GetChannel(testChannelGuid).Members[testUserGyidTirhd].Role == ChatMemberRole.User);
        }

        [TestMethod]
        public void Channel_SendMessageCreator()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.CreateChannel(testUserGyidFirst);
            Guid testChannelGuid = lg.tempGuid;

            lg.GetChannel(testChannelGuid).SendMessage(testUserGyidFirst, "test");
            Guid testMessageID = lg.GetChannel(testChannelGuid).tempMessageID;
            Assert.AreEqual(lg.GetChannel(testChannelGuid).Messages[testMessageID].Text, "test");
        }

        [TestMethod]
        public void Channel_SendMessageAdmin()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.CreateChannel(testUserGyidFirst);
            Guid testChannelGuid = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.GetChannel(testChannelGuid).InviteUser(testUserGyidFirst, testUserGyidSecound);
            lg.GetChannel(testChannelGuid).UpRole(testUserGyidFirst, testUserGyidSecound);

            lg.GetChannel(testChannelGuid).SendMessage(testUserGyidSecound, "test");
            Guid testMessageID = lg.GetChannel(testChannelGuid).tempMessageID;

            Assert.AreEqual(lg.GetChannel(testChannelGuid).Messages[testMessageID].Text, "test");
        }

        [TestMethod]
        public void Channel_SendMessageUser()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.CreateChannel(testUserGyidFirst);
            Guid testChannelGuid = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.GetChannel(testChannelGuid).InviteUser(testUserGyidFirst, testUserGyidSecound);

            lg.GetChannel(testChannelGuid).SendMessage(testUserGyidSecound, "test");
            Guid testMessageID = lg.GetChannel(testChannelGuid).tempMessageID;

            Assert.IsFalse(lg.GetChannel(testChannelGuid).Messages.ContainsKey(testMessageID));
        }

        [TestMethod]
        public void Group_EditMessageUserHim()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).SendMessage(testUserGyidThird, "test");
            Guid testMessageID = lg.GetGroup(testGroupID).tempMessageID;

            lg.GetGroup(testGroupID).EditMessage(testUserGyidThird,testMessageID, "edit");

            Assert.AreEqual(lg.GetGroup(testGroupID).Messages[testMessageID].Text, "edit");
        }

        [TestMethod]
        public void Group_EditMessageUserNotHim()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).SendMessage(testUserGyidSecound, "test");
            Guid testMessageID = lg.GetGroup(testGroupID).tempMessageID;

            lg.GetGroup(testGroupID).EditMessage(testUserGyidThird, testMessageID, "edit");

            Assert.AreEqual(lg.GetGroup(testGroupID).Messages[testMessageID].Text, "test");
        }

        [TestMethod]
        public void Group_EditMessageCreatorHim()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).SendMessage(testUserGyidFirst, "test");
            Guid testMessageID = lg.GetGroup(testGroupID).tempMessageID;

            lg.GetGroup(testGroupID).EditMessage(testUserGyidFirst, testMessageID, "edit");

            Assert.AreEqual(lg.GetGroup(testGroupID).Messages[testMessageID].Text, "edit");
        }

        [TestMethod]
        public void Group_EditMessageCreatorNotHim()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).SendMessage(testUserGyidSecound, "test");
            Guid testMessageID = lg.GetGroup(testGroupID).tempMessageID;

            lg.GetGroup(testGroupID).EditMessage(testUserGyidFirst, testMessageID, "edit");

            Assert.AreEqual(lg.GetGroup(testGroupID).Messages[testMessageID].Text, "test");
        }

        [TestMethod]
        public void Group_DeleteMessageCreatorHim()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).SendMessage(testUserGyidFirst, "test");
            Guid testMessageID = lg.GetGroup(testGroupID).tempMessageID;

            lg.GetGroup(testGroupID).DeleteMessage(testUserGyidFirst, testMessageID);

            Assert.IsFalse(lg.GetGroup(testGroupID).Messages.ContainsKey(testMessageID));
        }

        [TestMethod]
        public void Group_DeleteMessageCreatorNotHim()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).SendMessage(testUserGyidSecound, "test");
            Guid testMessageID = lg.GetGroup(testGroupID).tempMessageID;

            lg.GetGroup(testGroupID).DeleteMessage(testUserGyidFirst, testMessageID);

            Assert.IsFalse(lg.GetGroup(testGroupID).Messages.ContainsKey(testMessageID));
        }

        [TestMethod]
        public void Group_DeleteMessageUserHim()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).SendMessage(testUserGyidSecound, "test");
            Guid testMessageID = lg.GetGroup(testGroupID).tempMessageID;

            lg.GetGroup(testGroupID).DeleteMessage(testUserGyidSecound, testMessageID);

            Assert.IsFalse(lg.GetGroup(testGroupID).Messages.ContainsKey(testMessageID));
        }

        [TestMethod]
        public void Group_DeleteMessageUserNotHim()
        {
            LeagueGram.LeagueGram lg = new LeagueGram.LeagueGram();

            lg.UserRegistration("g", "8", "i");
            Guid testUserGyidFirst = lg.tempGuid;

            lg.UserRegistration("g1", "81", "i1");
            Guid testUserGyidSecound = lg.tempGuid;

            lg.UserRegistration("g2", "82", "i2");
            Guid testUserGyidThird = lg.tempGuid;

            Guid[] testGuidArray = { testUserGyidSecound, testUserGyidThird };
            string[] testNickNameArray = { lg.GetUser(testUserGyidSecound).NickName, lg.GetUser(testUserGyidThird).NickName };

            lg.CreateGroup(testUserGyidFirst, lg.GetUser(testUserGyidFirst).NickName, testGuidArray, testNickNameArray);
            Guid testGroupID = lg.tempGuid;

            lg.GetGroup(testGroupID).SendMessage(testUserGyidSecound, "test");
            Guid testMessageID = lg.GetGroup(testGroupID).tempMessageID;

            lg.GetGroup(testGroupID).DeleteMessage(testUserGyidThird, testMessageID);

            Assert.IsTrue(lg.GetGroup(testGroupID).Messages.ContainsKey(testMessageID));
        }
    }
}
