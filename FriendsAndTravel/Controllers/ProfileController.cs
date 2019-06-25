﻿using AutoMapper;
using FriendsAndTravel.BAL.DTO;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.BAL.Services;
using FriendsAndTravel.Data;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FriendsAndTravel.Controllers
{
    public class ProfileController: Controller
    {
        FriendsAndTravelDbContext _context;
        IHostingEnvironment _appEnvironment;
        UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
       
        public ProfileController(FriendsAndTravelDbContext context, IHostingEnvironment appEnvironment, IMapper mapper,  UserManager<User> userManager, IPostService postService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _postService = postService;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
             List<string> user_categories = new List<string>();
            foreach (var item in _categoryService.UserCategories(user.UserName))
            {
                user_categories.Add(item.Tag);
            }
            var model = new PersonViewModel
            {
                Id=user.Id,
                phot = user.Avatar,
                UserName = user.UserName,
                Email = user.Email,
                Gender = user.Gender,
                Location = user.Location,
                Phone = user.PhoneNumber,
                Age = DateTime.Today.Year - user.Birthday.Year,
                UserCategories = user_categories,
                 Posts = _postService.PostsByUserId(user.Id, 1, 5)

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFileCollection uploads)
        {
            foreach (var uploadedFile in uploads)
            {
           
                string path = "/Files/" + uploadedFile.FileName;
               
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                Photo file = new Photo { Name = uploadedFile.FileName, Path = path };
                _context.Photos.Add(file);
            }
            _context.SaveChanges();

            return RedirectToAction("AddFile");
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/Files/" + uploadedFile.FileName;
             
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                Photo file = new Photo { Name = uploadedFile.FileName, Path = path };
                _context.Photos.Add(file);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
       

        

    }
}

