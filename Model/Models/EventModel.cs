using AutoMapper;
using FriendsAndTravel.Data.Entities;
using Microsoft.AspNetCore.Http;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Model.Models
{
        public class EventModel 
        {
            public int Id { get; set; }

            public string ImUrl { get; set; }

            public string Title { get; set; }

            public string Location { get; set; }

            public string Description { get; set; }

            public DateTime DateStarts { get; set; }

            public DateTime DateEnds { get; set; }

            public int ParticipantsCount { get; set; }

            public List<string> ParticipantId { get; set; } = new List<string>();
            public List<string> SelectedCategories { get; set; }
            public List<string> Categories { get; set; }
        public List<Categories> categories { get; set; }
            public string OwnerId { get; set; }
        public string OwnerName { get; set;}
        public byte[] UserProfilePicture { get; set; }
    }
}
