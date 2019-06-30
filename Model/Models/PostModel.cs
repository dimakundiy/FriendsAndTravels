using AutoMapper;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class PostModel 
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int Likes { get; set; }

        public byte[] Photo { get; set; }

        public byte[] UserProfilePicture { get; set; }

        public string UserId { get; set; }

        public string UserFullName { get; set; }

        public Feeling Feeling { get; set; }

    

    }
}
