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
        IEventCategoryRepository EventCategoryRepository { get; }
        IEventRepository EventRepository { get; }
        IUserProfileRepository userProfileRepository { get; }
        IUserEventRepository UserEventRepository { get; }
        ILocationRepository LocationRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        IEventPhotoRepository EventPhotoRepository { get; }
        Task SaveAsync();
    }
}
