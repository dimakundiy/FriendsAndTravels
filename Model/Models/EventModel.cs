using AutoMapper;
using FriendsAndTravel.Common.Mapping;
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
        public class EventModel : IMapFrom<Event>, IHaveCustomMapping
        {
            public int Id { get; set; }

            public byte[] Photo { get; set; }

            public string Title { get; set; }

            public string Location { get; set; }

            public string Description { get; set; }

            public DateTime DateStarts { get; set; }

            public DateTime DateEnds { get; set; }

            public int ParticipantsCount { get; set; }

            public List<string> ParticipantId { get; set; } = new List<string>();
            public List<string> SelectedCategories { get; set; }
            public List<Categories> Categories { get; set; }

            public string OwnerId { get; set; }
     
        public void ConfigureMapping(Profile profile)
            {
                profile.CreateMap<Event, EventModel>()
                    .ForMember(e => e.ParticipantId, cfg =>
                    cfg.MapFrom(e => e.Participants.Select(p => p.UserId).ToList()))
                    .ForMember(e => e.ParticipantsCount, cfg => cfg.MapFrom(e => e.Participants.Count));
            }
        }
}
