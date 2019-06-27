using FriendsAndTravel.BAL.DTO;
using FriendsAndTravel.BAL.Interfaces;
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

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
   
        public IActionResult Create(EventFormModel model)
        {
            this.eventService.Create(
                model.ImageUrl,
                model.Title,
                model.Location,
                model.Description,
                model.DateStarts,
                model.DateEnds,
                this.User.GetUserId());

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
