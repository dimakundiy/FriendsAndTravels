using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.InterfacesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.Data.Repositories
{
    public class UserProfileRepository : Repository<User>, IUserProfileRepository
    {
        public UserProfileRepository(FriendsAndTravelDbContext context) : base(context)
        {

        }

        public User FindByUserName(string UserName)
        {
            User user = context.Users.FirstOrDefault(x => x.UserName == UserName);
            user = context.Users.FirstOrDefault(x => x.Id == user.Id);
           // user = context.Users.FirstOrDefault(x => x.Id == user.Id);
         //  user.Avatar = context.Photos.FirstOrDefault(x => x.Id == user.UserProfile.PhotoId);
          //  user.Location = context.Locations.FirstOrDefault(x => x.Id == user.Location.Id);
            return user;
        }
    }
}
