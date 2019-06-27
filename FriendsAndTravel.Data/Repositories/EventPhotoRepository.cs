using FriendsAndTravel.Data.InterfacesModel;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.Data.Repositories
{
    public class EventPhotoRepository : Repository<EventPhoto>, IEventPhotoRepository
    {
        public EventPhotoRepository(FriendsAndTravelDbContext db) : base(db)
        {
        }

        public EventPhoto FindByEventId(int id)
        {
            return context.EventPhotos.FirstOrDefault(x => x.EventId == id);
        }
    }
}
