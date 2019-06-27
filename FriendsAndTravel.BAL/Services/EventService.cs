using AutoMapper;
using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Model.DTO;
using Model.Entities;
using Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsAndTravel.BAL.Services
{
    public class EventService : IEventService
    {
        private readonly FriendsAndTravelDbContext db;
        private readonly IMapper mapper;
        private readonly IPhotoService photoService;
        private readonly IUnitOfWork unitOfWork;
        public EventService(FriendsAndTravelDbContext db, IMapper mapper, IPhotoService photoService, IUnitOfWork unitOfWork )
        {
            this.unitOfWork = unitOfWork;
            this.photoService = photoService;
            this.mapper = mapper;
            this.db = db;
        }

        public void AddUserToEvent(string userId, int eventId)
        {
            if (this.Exists(eventId))
            {
                var ev = this.db.Events
                    .Include(e => e.Participants)
                    .FirstOrDefault(e => e.Id == eventId);

                if (!ev.Participants.Any(p => p.UserId == userId))
                {
                    ev.Participants.Add(new EventUser
                    {
                        UserId = userId
                    });
                }

                this.db.SaveChanges();
            }
        }

        public EventModel EventById(int eventId)
        {
            var ev= this.db
                .Events
                .Where(p => p.Id == eventId).FirstOrDefault();
            return mapper.Map<EventModel>(ev);
        }
        public IEnumerable<EventModel> EventsByUserId(string userId) {
            var ev = this.db
               .Events.Where(e => e.OwnerId == userId)
               .ToList();
            return mapper.Map<IEnumerable<EventModel>>(ev);

        }
        public IEnumerable<EventModel> UpcomingThreeEvents()
        {
            var ev = this.db
                .Events.Where(e => e.DateEnds <= DateTime.UtcNow)
                .OrderBy(e => e.DateStarts)
                .ToList();
            return mapper.Map<IEnumerable<EventModel>>(ev);
        }
        public void Create(EventDTO e)
        {
            var ev = new Event
            {
                Title = e.Title,
                Location = e.Location,
                Description = e.description,
                DateEnds = e.dateEnds,
                DateStarts = e.dateStarts,
                OwnerId=e.creatorId
               
            };
            
            ev.Participants.Add(new EventUser { UserId = e.creatorId });

            this.db.Events.Add(ev);
            this.db.SaveChanges();
        }

        public EventModel Details(int id)
        {
            if (this.Exists(id))
            {
                var ev = this.db.Events
                    .Include(e => e.Participants)
                    .FirstOrDefault(e => e.Id == id);

                return Mapper.Map<EventModel>(ev);
            }

            return null;
        }

       

        public bool Exists(int id) => this.db.Events.Any(e => e.Id == id);

       
    }
}
