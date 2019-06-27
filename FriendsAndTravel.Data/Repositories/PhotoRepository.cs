using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.InterfacesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.Data.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(FriendsAndTravelDbContext db) : base(db)
        {

        }

        public Photo FindClone(string url)
        {
            return context.Photos.FirstOrDefault(x => x.Path == url);
        }
    }
}
