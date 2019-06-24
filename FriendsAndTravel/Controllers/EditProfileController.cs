using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.Data;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.DTO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsAndTravel.Controllers
{
    public class EditProfileController: Controller
    {
        FriendsAndTravelDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        private readonly ICategoryService categoryService;
        public EditProfileController(
          UserManager<User> userManager,
          SignInManager<User> signInManager,
          ILogger<EditProfileController> logger, ICategoryService _categoryService, FriendsAndTravelDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            categoryService = _categoryService;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var model = new PersonViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Location=user.Location,
                Phone = user.PhoneNumber,
                Age = DateTime.Today.Year - user.Birthday.Year,
                
                StatusMessage = StatusMessage
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(PersonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);

            var userName = user.UserName;
            if (model.UserName != userName)
            {
                var setUserNAmeResult = await _userManager.SetUserNameAsync(user, model.UserName);
                if (!setUserNAmeResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting User Name for user with ID '{user.Id}'.");
                }
            }
         //   var location = user.Location;
          //  if (model.Location != location)
          //  {
          //     var setEmailResult = await _userManager.User;
             //   if (!setEmailResult.Succeeded)
              //  {
                //    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
               // }
          //  }

            var phoneNumber = user.PhoneNumber;
            if (model.Phone != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.Phone);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }
            StatusMessage = "Your profile has been updated";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToAction(nameof(SetPassword));
            }

            var model = new ChangeUserPasswordModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            _logger.LogInformation("User changed their password successfully.");
            StatusMessage = "Your password has been changed.";

            return RedirectToAction(nameof(ChangePassword));
        }

        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);

            if (hasPassword)
            {
                return RedirectToAction(nameof(ChangePassword));
            }

            var model = new SetPasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var addPasswordResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                AddErrors(addPasswordResult);
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            StatusMessage = "Your password has been set.";

            return RedirectToAction(nameof(SetPassword));
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        public IActionResult ChangeAvatar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeAvatar(PersonViewModel pvm)
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

            return RedirectToAction("Index","Profile");
        }
        public IActionResult ChooseCategories(string id)
        {
            List<string> selected_categories = new List<string>();
            foreach (var item in categoryService.UserCategories(User.Identity.Name))
            {
                selected_categories.Add(item.Tag);
            }
            ChooseCategoryModel chooseCategoriesViewModel = new ChooseCategoryModel
            {
                SelectedCategories = selected_categories,
                Categories = categoryService.Categories()
            };
            return View(chooseCategoriesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChooseCategories(ChooseCategoryModel model)
        {
            var p = await _userManager.FindByNameAsync(User.Identity.Name);
            UCategoriesDTO userCategoryDTO = new UCategoriesDTO
            {
                Categories = model.SelectedCategories,
                Id = p.Id
            };
            OperationDetails result = await categoryService.AddUserCategories(userCategoryDTO);

            return RedirectToAction("Index", "Profile");
        }

    }
}
