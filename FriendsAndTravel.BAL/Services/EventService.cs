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

        public void Delete(int eventId)
        {
            var events = this.db.Events.Find(eventId);

            this.db.Remove(events);
            this.db.SaveChanges();
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
        public async Task<OperationDetails> Create(EventDTO e)
        {
            var ev = new Event
            {
                Title = e.Title,
                Location = e.Location,
                Description = e.Description,
                DateEnds = e.DateEnds,
                DateStarts = e.DateStarts,
                OwnerId=e.CreatorId,
                ImageUrl= e.ImUrl
            };
            
            ev.Participants.Add(new EventUser { UserId = e.CreatorId });
            foreach (var item in e.Categories)
            {
                 ev.EventCategories.Add(new EventCategory
                {
                    Event = ev,
                    Category = unitOfWork.CategoryRepository.GetByTitle(item)
                });
            }
            this.db.Events.Add(ev);
            this.db.SaveChanges();
            return new OperationDetails(true, "Ok", "");
        }

        public async Task<OperationDetails> Edit(int event_id,EventDTO ev) {

            var events = this.db.Events.Find(event_id);        
            events.Title = ev.Title;
            events.Location = ev.Location;
            events.Description = ev.Description;
            events.DateEnds = ev.DateEnds;
            events.DateStarts = ev.DateStarts;
            events.ImageUrl = ev.ImUrl;
            foreach (var item in unitOfWork.EventCategoryRepository.FindByEventId(events.Id))
            {
                unitOfWork.EventCategoryRepository.Delete(item);
            }


            foreach (var item in ev.Categories)
            {
                unitOfWork.EventCategoryRepository.Add(new EventCategory
                {
                    Category = unitOfWork.CategoryRepository.GetByTitle(item),
                    Event = events
                });
            }

            await unitOfWork.SaveAsync();

            return new OperationDetails(true, "Ok", "");
        }
        
        private EventDTO GetAllDataForEvent(Event item)
        {
            EventDTO eventDTO = new EventDTO
            {
                categories = unitOfWork.EventCategoryRepository.GetCategoriesByEventId(item.Id).ToList()
            };
            return eventDTO;
        }

        public EventModel Details(int id)
        {   
            if (this.Exists(id))
            {
                var ev = this.db.Events.Where(x => x.Id == id)
                    .Include(x => x.Participants)
                    .Include(x=>x.Owner)
                    .Include(x => x.EventCategories)
                    .ThenInclude(z=>z.Category)  
                    .FirstOrDefault();
                var em = mapper.Map<EventModel>(ev);
                em.SelectedCategories = ev.EventCategories.Select(x => x.Category.Tag).ToList();
                em.OwnerName = ev.Owner.UserName;
                em.UserProfilePicture = ev.Owner.Avatar;
                return em;
            }

            return null;
        }

        public IEnumerable<EventDTO> Events()
        {
            var events = unitOfWork.EventRepository.GetAll().ToList();

            return mapper.Map<IEnumerable<Event>, IEnumerable<EventDTO>>(events);
        }

        IEnumerable<EventDTO> IEventService.SearchEvents(int Category_id) {
            var ev = this.db.EventCategories.Where(x => x.CategoryId == Category_id)
                  .Include(z => z.Event)
                  .Include(a => a.Category)
                   .ToList();
            var em= mapper.Map<IEnumerable<EventDTO>>(ev);
            return em;
        }

        public bool Exists(int id) => this.db.Events.Any(e => e.Id == id);

        public bool UserIsAuthorizedToEdit(int eventid, string userId) => this.db.Events.Any(p => p.Id == eventid && p.OwnerId == userId);

       
    }
}
