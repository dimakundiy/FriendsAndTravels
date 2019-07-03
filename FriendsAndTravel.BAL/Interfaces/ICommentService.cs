using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.BAL.Interfaces
{
    public interface ICommentService 
    {
        void Create(string commentText, string userId, int postId);

        void DeleteCommentsByPostId(int postId);

        void DeleteCommentById(int comment_id);

        IEnumerable<CommentModel> CommentsByPostId(int postId);

        bool Exists(int id);
    }
}
