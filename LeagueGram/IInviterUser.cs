using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    interface IInviterUser
    {
        void InviteUser(Guid inviterID, Guid inviteUserID);
    }
}
