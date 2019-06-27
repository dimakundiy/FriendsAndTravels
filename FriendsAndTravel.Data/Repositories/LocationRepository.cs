using FriendsAndTravel.Data.InterfacesModel;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(FriendsAndTravelDbContext context) : base(context)
        {
        }
    }
}
