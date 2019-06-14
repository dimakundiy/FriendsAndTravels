using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FriendsAndTravel.Data.Entities
{
    public class Categories
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.MaxInterestLength)]
        [MinLength(DataConstants.MinInterestLength)]
        public string Tag { get; set; }
        public ICollection<UserCategories> Users { get; set; } = new List<UserCategories>();
    }
}
