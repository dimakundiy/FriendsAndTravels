using FriendsAndTravel.BAL.DTO;
using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FriendsAndTravel.Controllers
{
    public class AccountController : Controller
    {
      
      
       private readonly IUserService userService;
        private readonly SignInManager<User> AuthenticationManager;

        public AccountController(
            SignInManager<User> authenticationManager,
            IUserService _userService
         )
        {
           
           
            AuthenticationManager = authenticationManager;
            userService = _userService;
         
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Models.LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                bool auth = await userService.Authenticate(userDto);
                if (!auth)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Models.RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {

                UserDTO userDto = new UserDTO
                {

                    Email = model.Email,
                    UserName = model.Username,
                    Birthday = model.Birthday,
                    Phone = model.Phone,
                    Location = new Location { NameLocation = model.Location },
                    Role = "user",
                    Gender = model.Gender,
                  
                    //ProfilePicture = this.photoService.PhotoAsBytes(model.Photo),
                    Password = model.Password
                };  
                OperationDetails operationDetails = await userService.Create(userDto);
               
                if (operationDetails.Succedeed) { 

                    return RedirectToAction("Index", "Home");

                }
                else { 
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                
}
            }
            return View(model);
        }
        
        private async Task SetInitialDataAsync()
        {
           
            await userService.SetInitialData(new UserDTO
            {
                Email = "dima.kundiy14@gmail.com",
                UserName = "dima",
                Password = "Dima.2580",
                Location=new Location() { NameLocation="Chernivtsi"},
                Gender=Gender.Male,
                Phone="380974293583",
                Birthday=new System.DateTime(2000,8,14),
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }

        private Location ToString(string v)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Logout()
        {
            await AuthenticationManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Profile()
        {
            return View();
        }

    }
}
