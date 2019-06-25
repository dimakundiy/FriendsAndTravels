using System;
using System.Collections.Generic;
using System.Text;
using FriendsAndTravel.Data.Entities;
using Model.Entities;

namespace FriendsAndTravel.BAL.DTO
{
  public  class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public Location Location { get; set; }
        public Gender Gender { get; set; }
        public User GetUser { get; set; }
        public bool IsDeleted { get; set; } = false;
        public IEnumerable<Photo> Photos { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public byte[] ProfilePicture { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserCategories> categories { get; set; }
        public ICollection<EventUser> Events { get; set; }
    }
}
