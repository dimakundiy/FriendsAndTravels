using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.BAL.Interfaces
{
    public interface IAdminManager : IDisposable
    {
        List<User> Users();
        List<Categories> Categories();
        OperationDetails AddCategory(string title);
    }
}
