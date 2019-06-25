using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FriendsAndTravel.Data.Entities
{
    public class UserCategories
    {
     
        public int CategoriesId { get; set; }

        public Categories Categories { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
