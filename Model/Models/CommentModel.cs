using AutoMapper;
using FriendsAndTravel.Common.Mapping;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class CommentModel : IMapFrom<Comment>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public string UserFullName { get; set; }

        public int PostId { get; set; }

        public byte[] UserProfilePicture { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentModel>()
                .ForMember(c => c.UserProfilePicture, cfg => cfg.MapFrom(c => c.User.Avatar))
                .ForMember(c => c.UserFullName, cfg => cfg.MapFrom(c => c.User.UserName));
        }
    }
}
