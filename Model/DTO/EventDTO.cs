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

        public string Title { get; set; }
        public string Location { get; set; }
        public string description { get; set; }
        public DateTime dateStarts { get; set; }
        public DateTime dateEnds { get; set; }
        public string creatorId { get; set; }
        public IFormFile Photo { get; set; }
        public List<string> Categories { get; set; }
        public string UserId { get; set; }
    }
}
