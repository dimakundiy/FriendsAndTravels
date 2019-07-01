using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.InterfacesModel;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<EventCategory> FindByEventId(int id)
        {
            return context.EventCategories.Where(x => x.EventId == id).Include(x => x.Category).Include(x => x.Event);
        }
        public IQueryable<Categories> GetCategoriesByEventId(int id)
        {
            return this.FindByEventId(id).Select(x => x.Category);
        }
    }
}
