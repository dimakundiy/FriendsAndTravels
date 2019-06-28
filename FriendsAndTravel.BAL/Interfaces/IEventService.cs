using FriendsAndTravel.BAL.Infrastructure;
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
        Task<OperationDetails> Create(EventDTO e);
        IEnumerable<EventDTO> Events();
        bool Exists(int id);
        EventModel EventById(int eventId);
        bool UserIsAuthorizedToEdit(int eventId, string userId);
        EventModel Details(int id);
        void Delete(int eventId);
        IEnumerable<EventModel> EventsByUserId(string userId);
        IEnumerable<EventModel> UpcomingThreeEvents();

        void AddUserToEvent(string userId, int eventId);
    }
}
