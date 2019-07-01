using FriendsAndTravel.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entities
{
 public   class EventCategory
    {

        public int Id { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }

        public virtual Event Event { get; set; }
    }
}
