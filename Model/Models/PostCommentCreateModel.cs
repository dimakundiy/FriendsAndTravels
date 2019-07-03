using FriendsAndTravel.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models
{
    public class PostCommentCreateModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int Likes { get; set; }

        public string Photo { get; set; }

        public string UserProfilePicture { get; set; }

        public string UserFullName { get; set; }

        public Feeling Feeling { get; set; }

        [Required]
        [Display(Name = "Comment:")]
        public string CommentText { get; set; }

        
    }
}
