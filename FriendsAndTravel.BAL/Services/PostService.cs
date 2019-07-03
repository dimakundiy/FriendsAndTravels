using AutoMapper;
using AutoMapper.QueryableExtensions;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data;
using FriendsAndTravel.Data.CustomDataStructures;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendsAndTravel.BAL.Services
{
    public class PostService : IPostService
    {
        private readonly FriendsAndTravelDbContext db;
        private readonly IPhotoService photoService;
        private readonly IMapper mapper;
        private readonly ICommentService commentService;
        public PostService(FriendsAndTravelDbContext db, IPhotoService photoService, IMapper mapper, ICommentService commentService)
        {
            this.mapper = mapper;
            this.db = db;
            this.photoService = photoService;
            this.commentService = commentService;
        }

        public void Create(string userId, Feeling feeling, string text, IFormFile photo)
        {
            var post = new Post
            {
                UserId = userId,
                Feeling = feeling,
                Text = text,
                Likes = 0,
                Date = DateTime.UtcNow,
                Photo = photo != null ? this.photoService.PhotoAsBytes(photo) : null
            };

            db.Posts.Add(post);
            db.SaveChanges();
        }

        public void Delete(int postId)
        {
            var post = this.db.Posts.Find(postId);
           this.commentService.DeleteCommentsByPostId(postId);
            this.db.Remove(post);
            this.db.SaveChanges();
        }

        public void Edit(int postId, Feeling feeling, string text, IFormFile photo)
        {
            var post = this.db.Posts.Find(postId);
            post.Feeling = feeling;
            post.Text = text;
            post.Photo = photo != null ? this.photoService.PhotoAsBytes(photo) : null;
            this.db.SaveChanges();
        }

        public bool Exists(int id) => this.db.Posts.Any(p => p.Id == id);

      
 
        public void Like(int postId)
        {
            if (this.Exists(postId))
            {
                var post = this.db.Posts.Find(postId);
                post.Likes++;
                this.db.SaveChanges();
            }
        }

        public PostModel PostById(int postId)
        {
            var posts= this.db.Posts.Where(p => p.Id == postId)
                .Include(c=>c.User)
                .FirstOrDefault();
            return mapper.Map<PostModel>(posts);
        }

        public IEnumerable<PostModel> PostsByUserId(string userId, int pageIndex, int pageSize)
        {
            var posts = this.db
                .Posts
                .Where(p => p.UserId == userId)
                .Include(p => p.Comments)
                .ThenInclude(p => p.User)              
                .OrderByDescending(p => p.Date);

           
            return mapper.Map<IEnumerable<PostModel>>(posts);

            
        }

        public bool UserIsAuthorizedToEdit(int postId, string userId) => this.db.Posts.Any(p => p.Id == postId && p.UserId == userId);

       
    }
}
