using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.Data.InterfacesModel
{
    public interface IEventCategoryRepository : IRepository<EventCategory>
    {
        IQueryable<EventCategory> FindByEventId(int id);
        IQueryable<Categories> GetCategoriesByEventId(int id);
    }
}
