using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.InterfacesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.Repositories
{
    public class UserEventRepository : Repository<EventUser>, IUserEventRepository
    {
        public UserEventRepository(FriendsAndTravelDbContext db) : base(db)
        {

        }
    }
}
