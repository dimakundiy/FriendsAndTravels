using FriendsAndTravel.Data.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models
{
    public class PostFormModel
    {
        [Required]
        [Display(Name = "What do you think?")]
        public string Text { get; set; }

        [Display(Name = "How do you feel?")]
        public Feeling Feeling { get; set; }

        [Display(Name = "Upload a photo")]
        public IFormFile Photo { get; set; }
    }
}
