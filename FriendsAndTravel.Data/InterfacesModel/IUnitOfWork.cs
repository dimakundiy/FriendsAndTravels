using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.InterfacesModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsAndTravel.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserCategoryRepository UserCategoryRepository { get; }
      
        Task SaveAsync();
    }
}
