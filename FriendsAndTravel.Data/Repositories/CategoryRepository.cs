using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.InterfacesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.Data.Repositories
{
    public class CategoryRepository : Repository<Categories>, ICategoryRepository
    {
        public CategoryRepository(FriendsAndTravelDbContext db) : base(db)
        {

        }

        public List<Categories> Categories(string id)
        {
            List<Categories> categories = new List<Categories>();
            foreach (var item in context.UserCategories.Where(x => x.UserId == id))
            {
                categories.Add(context.Categories.FirstOrDefault(x => x.Id == item.CategoriesId));
            }
            return categories;
        }

        public Categories GetByTitle(string title)
        {
            return context.Categories.FirstOrDefault(x => x.Tag == title);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
