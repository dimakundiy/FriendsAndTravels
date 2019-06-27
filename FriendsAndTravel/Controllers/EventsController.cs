using FriendsAndTravel.BAL.DTO;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data;
using FriendsAndTravel.Extensions;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsAndTravel.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        private readonly IPhotoService photoService;
        public EventsController(IEventService eventService, IPhotoService photoService)
        {
            this.photoService = photoService;
            this.eventService = eventService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllEvents()
        {
            return View();
        }
        [HttpPost]
   
        public IActionResult Create(EventFormModel model)
        {
            EventDTO eventDTO = new EventDTO {
                Title=model.Title,
                Location= model.Location,
                Description= model.Description,
                DateStarts= model.DateStarts,
                DateEnds= model.DateEnds,
                CreatorId =this.User.GetUserId(),
               ImUrl=model.ImUrl

            };
           
            this.eventService.Create(
                      eventDTO
              );

            return RedirectToAction("Index", "Profile");
        }
        public IActionResult DeleteEvent(int event_id)
        {
            eventService.DeleteEvent(event_id);
            return RedirectToAction("Index", "Profile");
        }
        public IActionResult Details(int id)
        {
            if (!this.eventService.Exists(id))
            {
                return NotFound();
            }

            return this.ViewOrNotFound(this.eventService.Details(id));
        }

        public IActionResult JointEvent(int id)
        {
            if (!this.eventService.Exists(id))
            {
                return NotFound();
            }

            this.eventService.AddUserToEvent(User.GetUserId(), id);

            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
