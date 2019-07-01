using FriendsAndTravel.Data.Entities;
using Microsoft.AspNetCore.Http;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime DateStarts { get; set; }
        public DateTime DateEnds { get; set; }
        public string CreatorId { get; set; }
        public string ImUrl { get; set; }
        public List<string> Categories { get; set; }
         public List<Categories> categories { get; set; }
        public string UserId { get; set; }
        public string OwnerName { get; set; }
        public Event Event { get; set; }
    }
}
