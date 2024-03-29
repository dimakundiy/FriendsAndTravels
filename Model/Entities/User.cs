﻿using Microsoft.AspNetCore.Identity;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FriendsAndTravel.Data.Entities
{

    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class User : IdentityUser
    {
      

        [Required]
        [Range(DataConstants.MinUserAge, DataConstants.MaxUserAge)]
        public DateTime Birthday { get; set; }
        public Location Location { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Phone { get; set; }
        public string Role { get; set; }
        public IEnumerable<Photo> Photos { get; set; } = new List<Photo>();
        public byte[] Avatar { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<UserCategories> Categories { get; set; } = new List<UserCategories>();

        public ICollection<EventUser> Events { get; set; } = new List<EventUser>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
