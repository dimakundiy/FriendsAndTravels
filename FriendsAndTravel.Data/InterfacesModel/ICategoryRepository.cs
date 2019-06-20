using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.InterfacesModel
{
    public interface ICategoryRepository : IRepository<Categories>
    {
        List<Categories> Categories(string id);
        Categories GetByTitle(string title);
        void Save();
    }
}
