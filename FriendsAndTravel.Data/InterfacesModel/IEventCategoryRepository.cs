using FriendsAndTravel.Data.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.InterfacesModel
{
    public interface IEventCategoryRepository : IRepository<EventCategory>
    {
        List<EventCategory> FindByEventId(int id);
    }
}
