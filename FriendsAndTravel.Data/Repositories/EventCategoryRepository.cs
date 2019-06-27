using FriendsAndTravel.Data.InterfacesModel;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.Data.Repositories
{
    public class EventCategoryRepository : Repository<EventCategory>, IEventCategoryRepository
    {
        public EventCategoryRepository(FriendsAndTravelDbContext db) : base(db)
        {

        }

        public List<EventCategory> FindByEventId(int id)
        {
            return context.EventCategories.Where(x => x.EventId == id).ToList();
        }
    }
}
