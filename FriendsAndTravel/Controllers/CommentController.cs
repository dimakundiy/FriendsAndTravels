using AutoMapper;
using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsAndTravel.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        public CommentController(IPostService postService, ICommentService commentService, IMapper mapper)
        {
            this.mapper = mapper;
            this.postService = postService;
            this.commentService = commentService;
        }

        public IActionResult Create(int postId)
        {
            var postCommentViewModel = this.postService.PostById(postId);

           PostCommentCreateModel postCommentCreateModel = mapper.Map<PostCommentCreateModel>(postCommentViewModel);

            return this.ViewOrNotFound(postCommentCreateModel);
        }

        [HttpPost]
        public IActionResult Create(PostCommentCreateModel model, string returnUrl = null)
        {
            if (CoreValidator.CheckIfStringIsNullOrEmpty(model.CommentText))
            {
                ModelState.AddModelError(string.Empty, "You cannot submit an empty comment!");
                return this.ViewOrNotFound(model);
            }

            this.commentService.Create(model.CommentText, User.GetUserId(), model.Id);
            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                this.commentService.DeleteCommentById(id);
                return RedirectToAction("Index", "Profile");
            }
            return RedirectToAction("Index", "Profile");
        }

    }
}
