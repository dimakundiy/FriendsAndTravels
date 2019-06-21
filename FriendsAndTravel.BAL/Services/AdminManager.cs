using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public OperationDetails AddCategory( string title)
        {
            Database.CategoryRepository.Add(new Categories() { Tag = title });
            Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<OperationDetails> Delete(int id)
        {
            if (id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }
            Categories category = Database.CategoryRepository.GetById(id);
            if (category == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            Database.CategoryRepository.Delete(category);
            await Database.SaveAsync();
            return new OperationDetails(true, "", "");
        }
    }
}
