using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.InterfacesModel
{
    public interface IEventRepository : IRepository<Event>
    {
        List<Event> MyEvents(string user_id);
    }
}
