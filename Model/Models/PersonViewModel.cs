using AutoMapper;
using FriendsAndTravel.Data.CustomDataStructures;
using FriendsAndTravel.Data.Entities;
using Microsoft.AspNetCore.Http;
using Model.Entities;
using Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FriendsAndTravel.Models
{
    public class PersonViewModel
    {
        public int userId { get; set; }
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

        public PaginatedList<PostModel> Posts { get; set; } = null;
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<User, PersonViewModel>()
                .ForMember(u => u.Posts, cfg => cfg.Ignore());
               
        }
    }
}
