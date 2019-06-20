using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.InterfacesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.Data.Repositories
{
    public class UserCategoryRepository : Repository<UserCategories>, IUserCategoryRepository
    {
        public UserCategoryRepository(FriendsAndTravelDbContext db) : base(db)
        {

        }

        public List<UserCategories> FindById(string id)
        {
            return context.UserCategories.Where(x => x.UserId == id).ToList();
        }
    }
}
