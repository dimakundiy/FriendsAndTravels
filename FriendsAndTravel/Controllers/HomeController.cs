using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FriendsAndTravel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace FriendsAndTravel.Controllers
{
    
    public class HomeController : Controller
    {
        FriendsAndTravelDbContext _context;
        IHostingEnvironment _appEnvironment;

        public HomeController(FriendsAndTravelDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            return View(_context.Photos.ToList());
        }
        
        public IActionResult Create()
        {
            return View(_context.Users.ToList());
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel pvm)
        {
            User user = new User { UserName = pvm.Name };
            if (pvm.Avatar != null)
            {
                byte[] imageData = null;
              
                using (var binaryReader = new BinaryReader(pvm.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.Avatar.Length);
                }
              
                user.Avatar = imageData;
            }
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Create");
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
