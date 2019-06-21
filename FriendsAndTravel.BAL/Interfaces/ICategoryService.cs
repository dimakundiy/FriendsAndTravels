using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.Data.Entities;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsAndTravel.BAL.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        List<Categories> Categories();
        List<Categories> UserCategories(string id);
        Task<OperationDetails> AddUserCategories(UCategoriesDTO model);
    }
}
