using FriendsAndTravel.Data.CustomDataStructures;
using FriendsAndTravel.Data.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.BAL.Interfaces
{
    public interface IPostService { 

        void Create(string userId, Feeling feeling, string text, IFormFile photo);

        void Edit(int postId, Feeling feeling, string text, IFormFile photo);

        bool Exists(int id);

        bool UserIsAuthorizedToEdit(int postId, string userId);

        IEnumerable<PostModel> PostsByUserId(string userId, int pageIndex, int pageSize);

      

        PostModel PostById(int postId);

        void Delete(int postId);

        void Like(int postId);
    }
}
