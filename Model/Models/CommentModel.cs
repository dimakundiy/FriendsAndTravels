using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
   public class CommentModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public string UserFullName { get; set; }

        public int PostId { get; set; }

        public byte[] UserProfilePicture { get; set; }
    }
}
