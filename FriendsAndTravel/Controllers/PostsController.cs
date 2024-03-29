﻿using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data;
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
    public class PostsController : Controller
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
 
        public IActionResult Create(PostFormModel model)
        {
            if (model.Photo != null)
            {
                if (model.Photo.Length > DataConstants.MaxPhotoLength)
                {
                    ModelState.AddModelError(string.Empty, "Your photo should be a valid image file with max size 5MB!");
                    return View(model);
                }
            }

            this.postService.Create(this.User.GetUserId(), model.Feeling, model.Text, model.Photo);

            return RedirectToAction("Index", "Profile");
        }

        public IActionResult Edit(int postId)
        {
            if (!this.postService.Exists(postId))
            {
                return NotFound();
            }

            var postInfo = this.postService.PostById(postId);

            ViewData["PostPhoto"] = postInfo.Photo;

            var postFormModel = new PostFormModel
            {
                Text = postInfo.Text,
                Feeling = postInfo.Feeling
            };

            return this.ViewOrNotFound(postFormModel);
        }

        [HttpPost]
 
        public IActionResult Edit(int postId, PostFormModel model)
        {
            if (!this.postService.UserIsAuthorizedToEdit(postId, this.User.GetUserId()))
            {
                return BadRequest();
            }

            this.postService.Edit(postId, model.Feeling, model.Text, model.Photo);

            return RedirectToAction("Index", "Profile", new { id = this.User.GetUserId() });
        }

        public IActionResult Delete(int postId)
        {
            if (!this.postService.Exists(postId))
            {
                return NotFound();
            }

            var postInfo = this.postService.PostById(postId);

            ViewData["PostPhoto"] = postInfo.Photo;

            var postFormModel = new PostFormModel
            {
                Text = postInfo.Text,
                Feeling = postInfo.Feeling
            };

            return this.ViewOrNotFound(postFormModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Destroy(int postId)
        {
            if (!this.postService.UserIsAuthorizedToEdit(postId, this.User.GetUserId()))
            {
                return BadRequest();
            }

            this.postService.Delete(postId);

            return RedirectToAction("Index", "Profile", new { id = this.User.GetUserId() });
        }

        public IActionResult Like(int postId, int pageIndex)
        {
            if (!this.postService.Exists(postId))
            {
                return this.NotFound();
            }

            this.postService.Like(postId);

            return RedirectToAction("Index", "Profile", new { page = pageIndex });
        }
    }
}
