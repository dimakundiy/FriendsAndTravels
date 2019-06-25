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


        public IdentityUnitOfWork(

                                  FriendsAndTravelDbContext db,
                                  SignInManager<User> signInManager,
                                  UserManager<User> userManager,
                                  RoleManager<IdentityRole> roleManager,
                                  ICategoryRepository categoryRepository,
                                  IUserCategoryRepository userCategoryRepository,
                                  IUserProfileRepository UserProfileRepository
                                  )
        {
            Database = db;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
            UserCategoryRepository = userCategoryRepository;
            CategoryRepository = categoryRepository;
            this.userProfileRepository= UserProfileRepository;
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
