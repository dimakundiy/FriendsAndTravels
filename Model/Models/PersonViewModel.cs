﻿using AutoMapper;
using FriendsAndTravel.Data.CustomDataStructures;
using FriendsAndTravel.Data.Entities;
using Microsoft.AspNetCore.Http;
using Model.DTO;
using Model.Entities;
using Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.Models
{
    public class PersonViewModel
    {

        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public Location Location { get; set; }
     
        public string Name { get; set; }
       
        public IFormFile Avatar { get; set; }
         [Display(Name = "Upload a photo")]
        public byte[] phot { get; set; }

        public string StatusMessage { get; set; }
        public List<string> UserCategories { get; set; }
        public IEnumerable<PostModel> Posts { get; set; } = new List<PostModel>();
        public IEnumerable<EventModel> Events { get; set; } = new List<EventModel>();
        public IEnumerable<EventCategory> eventCategories { get; set; } = new List<EventCategory>();
     
        public IEnumerable<string> Interests { get; set; } = new List<string>();

      
    }
}
