﻿using FriendsAndTravel.BAL.DTO;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data;
using FriendsAndTravel.Data.Interfaces;
using FriendsAndTravel.Extensions;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IEventService eventService;
        private readonly IPhotoService photoService;
        private readonly ICategoryService categoryService;
        public EventsController(IEventService eventService, IPhotoService photoService, IUnitOfWork unitOfWork, ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            this.unitOfWork = unitOfWork;
            this.photoService = photoService;
            this.eventService = eventService;
        }

        [HttpGet]
        public IActionResult AllEvents()
        {
           // return Ok(eventService.Events());
            return View(eventService.Events());
        }
        // Create event
  
        public IActionResult Create()
        {
            EventFormModel eventForm = new EventFormModel
            {
                Categories = categoryService.UserCategories(this.User.GetUserId()),
                SelectedCategories = new List<string>()
            };
            return View(eventForm);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(EventFormModel model)
        {
            
            
            EventDTO eventDTO = new EventDTO {
                Title=model.Title,
                Location= model.Location,
                Description= model.Description,
                DateStarts= model.DateStarts,
                DateEnds= model.DateEnds,
                CreatorId =this.User.GetUserId(),
                Categories = model.SelectedCategories,
                ImUrl =model.ImUrl,
            };

            await eventService.Create(
                      eventDTO
              );

            return RedirectToAction("Index", "Profile");
        }
        
        
        public IActionResult Delete(int id)
        {
            

            this.eventService.Delete(id);

            return RedirectToAction("Index", "Profile", new { id = this.User.GetUserId() });
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
