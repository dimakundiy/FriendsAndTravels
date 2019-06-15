﻿using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
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
       
        public IdentityUnitOfWork(
                                  FriendsAndTravelDbContext db,
                                  SignInManager<User> signInManager,
                                  UserManager<User> userManager,
                                  RoleManager<IdentityRole> roleManager)
        {
            Database = db;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
            
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