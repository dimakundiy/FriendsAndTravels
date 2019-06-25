using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.InterfacesModel
{
    public interface IUserProfileRepository  :IRepository<User>
    {
        User FindByUserName(string UserName);
    }
}
