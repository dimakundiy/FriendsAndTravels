﻿using FriendsAndTravel.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
