using AutoMapper;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.BAL.Services
{
    public  class MappingUserProfile: Profile
    {
        public MappingUserProfile() {
            CreateMap<User, PersonViewModel>();
        }
    }
}
