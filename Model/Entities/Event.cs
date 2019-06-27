using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FriendsAndTravel.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        [MaxLength(DataConstants.MaxEventTitleLength)]
        public string Title { get; set; }


        public int LocationId { get; set; }
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateStarts { get; set; }

        [Required]
        public DateTime DateEnds { get; set; }
       
   
          public string OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public ICollection<EventUser> Participants { get; set; } = new List<EventUser>();
         public ICollection<EventCategory>  EventCategories { get; set; } = new List<EventCategory>();
    }
}
