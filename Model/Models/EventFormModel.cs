using FriendsAndTravel.Data;
using FriendsAndTravel.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models
{
  public   class EventFormModel
        {
        public string Id { get; set; }
        [Required]
        [MaxLength(DataConstants.MaxEventTitleLength)]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Display(Name = "Photo URl")]
        public string ImUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime DateStarts { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime DateEnds { get; set; }

        public List<string> SelectedCategories { get; set; }
        public List<Categories> Categories { get; set; }
    }
}
