using FriendsAndTravel.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class ChooseCategoryModel
    {
        public  List<string> SelectedCategories { get; set; }
        public List<Categories> Categories { get; set; }
        public List<UserCategories> UCategories { get; set; }
    }
}
