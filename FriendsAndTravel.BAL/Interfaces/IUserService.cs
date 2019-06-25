using FriendsAndTravel.BAL.DTO;
using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.InterfacesModel;
using FriendsAndTravel.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsAndTravel.BAL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<bool> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
        Task<UserDTO> FindProfileByUserName(string UserName);
    }
}
