using AutoMapper;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data;
using FriendsAndTravel.Data.Entities;
using Model.Entities;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.BAL.Services
{
    public class CommentService : ICommentService
    {
        private readonly FriendsAndTravelDbContext db;
        private readonly IMapper mapper;
        public CommentService(FriendsAndTravelDbContext db, IMapper mapper)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public IEnumerable<CommentModel> CommentsByPostId(int postId)
        {
           
          var ev =
                this.db
                .Comments
                .Where(c => c.PostId == postId)
                .OrderByDescending(c => c.Date).ToList();
            return mapper.Map<IEnumerable<CommentModel>>(ev);
        }

        public void Create(string commentText, string userId, int postId)
        {
            var comment = new Comment
            {
                Date = DateTime.UtcNow,
                Text = commentText,
                UserId = userId,
                PostId = postId
            };

            this.db.Comments.Add(comment);
            this.db.SaveChanges();
        }
        public void  DeleteCommentById(int comment_id) {
            var comment = this.db.Comments.Find(comment_id);  
            this.db.Remove(comment);
            this.db.SaveChanges();

        }

        public void DeleteCommentsByPostId(int postId)
        {
            var comments = this.db.Comments.Where(c => c.PostId == postId);

            foreach (var comment in comments)
            {
                this.db.Remove(comment);
            }

            this.db.SaveChanges();
        }
        public bool Exists(int id) => this.db.Comments.Any(p => p.Id == id);
    }
}
