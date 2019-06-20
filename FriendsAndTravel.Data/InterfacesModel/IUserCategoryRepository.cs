using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.InterfacesModel
{
    public interface IUserCategoryRepository : IRepository<UserCategories>
    {

        List<UserCategories> FindById(string id);

    }
}
