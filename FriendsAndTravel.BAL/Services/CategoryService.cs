using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsAndTravel.BAL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork Database;
        public CategoryService(IUnitOfWork db)
        {
            Database = db;
        }

        public async Task<OperationDetails> AddUserCategories(UCategoriesDTO model)
        {
            foreach (var item in Database.UserCategoryRepository.FindById(model.Id))
            {
                Database.UserCategoryRepository.Delete(item);
            }
            foreach (var item in model.Categories)
            {
                Database.UserCategoryRepository.Add(new UserCategories
                {
                    Categories = Database.CategoryRepository.GetByTitle(item),
                    User = await Database.UserManager.FindByIdAsync(model.Id)
                });
                await Database.SaveAsync();
            }
            return new OperationDetails(true, "Ok", "");
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public List<Categories> UserCategories(string id)
        {
            return Database.CategoryRepository.Categories(id);
        }

        public List<Categories> Categories()
        {
            return Database.CategoryRepository.GetAll().ToList();
        }

        
    }
}
