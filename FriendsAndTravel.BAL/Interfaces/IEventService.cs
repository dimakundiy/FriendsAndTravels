﻿using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.Data.Entities;
using Microsoft.AspNetCore.Http;
using Model.DTO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsAndTravel.BAL.Interfaces
{
    public interface IEventService 
    {
        void Create(EventDTO e);

        bool Exists(int id);
        EventModel EventById(int eventId);

        EventModel Details(int id);

        IEnumerable<EventModel> EventsByUserId(string userId);
        IEnumerable<EventModel> UpcomingThreeEvents();

        void AddUserToEvent(string userId, int eventId);
    }
}
