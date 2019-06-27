using FriendsAndTravel.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTO
{
    public class EventListDTO
    {
        public Event Event { get; set; }
        public Photo Photo { get; set; }
        public List<Categories> Categories { get; set; }
    }
}
