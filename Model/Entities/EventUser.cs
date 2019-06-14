using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Data.Entities
{
    public class EventUser
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
