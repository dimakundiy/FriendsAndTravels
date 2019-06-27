using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.InterfacesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(FriendsAndTravelDbContext db) : base(db)
        {

        }

        public List<Event> MyEvents(string user_id)
        {
            return context.Events.Where(x => x.OwnerId == user_id).ToList();
        }
    }
}
