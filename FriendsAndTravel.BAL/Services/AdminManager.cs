using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.BAL.Services
{
   public class AdminManager: IAdminManager
    {
        private readonly IUnitOfWork Database;


        public AdminManager(IUnitOfWork db)
        {
            Database = db;
        }

        public List<User> Users()
        {
            return Database.UserManager.Users.ToList();
        }

        public List<Categories> Categories()
        {
            return Database.CategoryRepository.GetAll().ToList();
        }

        public OperationDetails AddCategory(string title)
        {
            Database.CategoryRepository.Add(new Categories() { Tag = title });
            Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
