using AutoMapper;
using FriendsAndTravel.BAL.DTO;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Extensions;
using FriendsAndTravel.Models;
using Model.DTO;

using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FriendsAndTravel.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Comment, CommentModel>()
                .ForMember(c => c.UserProfilePicture, cfg => cfg.MapFrom(c => c.User.Avatar))
                .ForMember(c => c.UserFullName, cfg => cfg.MapFrom(c => c.User.UserName));
          
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<LoginModel, UserDTO>();
            CreateMap<RegisterModel, UserDTO>()
          .ForMember(dest => dest.Role, opts => opts.MapFrom(src => "user"));

            CreateMap<Post, PostModel>()
             .ForMember(p => p.UserProfilePicture, cfg => cfg.MapFrom(p => p.User.Avatar))
            .ForMember(p => p.UserFullName, cfg => cfg.MapFrom(p => p.User.UserName));
          

            CreateMap<Event, EventDTO>()
            .ForMember(dest => dest.ImUrl, opts => opts.MapFrom(src => src.ImageUrl));
            CreateMap<EventDTO, EventModel>();

            CreateMap<EventModel, EventDTO>()
                .ForMember(dest => dest.categories, opt => opt.MapFrom(src => src.Categories))
                 .ForMember(dest => dest.Categories, opts => opts.MapFrom(src => src.SelectedCategories));
            CreateMap<Event, EventFormModel>();
            CreateMap<EventModel, EventFormModel > ()
                 .ForMember(c => c.Categories, ctg => ctg.MapFrom(src => src.Categories));
            CreateMap<Event, EventModel>()
            .ForMember(dest => dest.ImUrl, opts => opts.MapFrom(src => src.ImageUrl))
                    .ForMember(e => e.ParticipantId, cfg =>
                    cfg.MapFrom(e => e.Participants.Select(p => p.UserId).ToList()))
                    .ForMember(e => e.ParticipantsCount, cfg => cfg.MapFrom(e => e.Participants.Count));
            CreateMap<User, PersonViewModel>()
                .ForMember(u => u.Posts, cfg => cfg.Ignore())
                .ForMember(u => u.Events, cfg => cfg.Ignore())
                .ForMember(u => u.Interests, cfg => cfg.MapFrom(u => u.Categories.Select(i => i.Categories.Tag).ToList()));
            CreateMap<PostModel, PostCommentCreateModel>()
                .ForMember(p => p.CommentText, cfg => cfg.Ignore()) 
                .ForMember(p => p.Photo, cfg => cfg.MapFrom(p => p.Photo.ToRenderablePictureString()))
                .ForMember(p => p.UserFullName, cfg => cfg.MapFrom(p => p.UserFullName))
                .ForMember(p => p.UserProfilePicture, cfg => cfg.MapFrom(p => p.UserProfilePicture.ToRenderablePictureString()));
        
               
        }

    }
}
