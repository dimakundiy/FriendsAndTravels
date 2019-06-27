using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using FriendsAndTravel.Data.InterfacesModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsAndTravel.Data.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        public FriendsAndTravelDbContext Database { get; private set; }
        public UserManager<User> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public IUserCategoryRepository UserCategoryRepository { get; private set; }
        public IUserProfileRepository userProfileRepository { get; private set; }
        public IEventCategoryRepository EventCategoryRepository { get; private set; }
        public IUserEventRepository UserEventRepository { get; private set; }
        public IEventRepository EventRepository { get; private set; }
        public IEventPhotoRepository EventPhotoRepository { get; private set; }
        public IPhotoRepository PhotoRepository { get; private set; }
        public ILocationRepository LocationRepository { get; private set; }
        public IdentityUnitOfWork(

                                  FriendsAndTravelDbContext db,
                                  SignInManager<User> signInManager,
                                  UserManager<User> userManager,
                                  RoleManager<IdentityRole> roleManager,
                                  ICategoryRepository categoryRepository,
                                  IUserCategoryRepository userCategoryRepository,
                                  IUserProfileRepository UserProfileRepository,
                                  IUserEventRepository userEventRepository,
                                  IEventRepository eventRepository,
                                  IEventCategoryRepository eventCategoryRepository,
                                  IPhotoRepository photoRepository,
                                  IEventPhotoRepository eventPhotoRepository,
                                  ILocationRepository locationRepository
                                  )
        {
            Database = db;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
            UserCategoryRepository = userCategoryRepository;
            CategoryRepository = categoryRepository;
            this.userProfileRepository= UserProfileRepository;
            UserEventRepository = userEventRepository;
            EventCategoryRepository = eventCategoryRepository;
            EventRepository = eventRepository;
            PhotoRepository = photoRepository;   
            EventPhotoRepository = eventPhotoRepository;
            LocationRepository = locationRepository;
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await Database.SaveChangesAsync();
        }
    }
}
