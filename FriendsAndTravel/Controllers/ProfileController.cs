using AutoMapper;
using FriendsAndTravel.BAL.DTO;
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
       
        public ProfileController(FriendsAndTravelDbContext context, IHostingEnvironment appEnvironment, IMapper mapper,  UserManager<User> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new PersonViewModel
            {
           
                phot= user.Avatar,
                UserName = user.UserName,
                Email = user.Email,
                Gender= user.Gender,
                Location = user.Location,
                Phone= user.PhoneNumber,
                Age = DateTime.Today.Year - user.Birthday.Year

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
        public IActionResult Create()
        {
            return View(_context.Users.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonViewModel pvm)
        {
            var user = await _userManager.GetUserAsync(User);
            if (pvm.Avatar != null)
            {
                byte[] imageData = null;
              
                using (var binaryReader = new BinaryReader(pvm.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.Avatar.Length);
                }
            
                user.Avatar = imageData;
            }         
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

