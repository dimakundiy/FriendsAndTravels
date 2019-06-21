using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FriendsAndTravel.Data.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        [MaxLength(DataConstants.MaxPhotoLength)]
        public byte[] PhotoAsBytes { get; set; }

        public string Path { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }

        public int? PostId { get; set; }

        public Post Post { get; set; }

        public bool IsProfilePicture { get; set; }
    }
}
