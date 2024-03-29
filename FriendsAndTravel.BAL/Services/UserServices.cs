﻿using FriendsAndTravel.BAL.DTO;
using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data.Entities;

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsAndTravel.Data.Interfaces;
using Model.Entities;
using FriendsAndTravel.Data.InterfacesModel;

namespace FriendsAndTravel.BAL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public  async Task<UserDTO> FindProfileByUserName(string UserName)
        {
            User user = Database.userProfileRepository.FindByUserName(UserName);
            UserDTO profile = new UserDTO()
            {
                GetUser = user
            };
            return profile;
        }
        public User GetUserByName(string user)
        {
            return Database.userProfileRepository.FindByUserName(user);
        }
        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            User user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new User { Email = userDto.Email, UserName = userDto.UserName, Birthday=userDto.Birthday, Gender=userDto.Gender,Role=userDto.Role, PhoneNumber=userDto.Phone, Location=new Location() { NameLocation=userDto.Location.ToString()} };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
             
                await Database.UserManager.AddToRoleAsync(user, userDto.Role);  
              
               
                await Database.SaveAsync();
                return new OperationDetails(true, "Registration successfully completed!", "");
            }
            else
            {
                return new OperationDetails(false, "User with this login already exists", "Email");
            }
        }

        public async Task<bool> Authenticate(UserDTO userDto)
        {
             

            var user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null) {
                return false;
            }
            var username = user.UserName;
            
            var auth = await Database.SignInManager.PasswordSignInAsync(username, userDto.Password, false, lockoutOnFailure: false);
           
            return auth.Succeeded;
        }

      
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new IdentityRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
