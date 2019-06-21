using FriendsAndTravel.BAL.Infrastructure;
using FriendsAndTravel.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsAndTravel.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminManager _adminManager;

        public AdminController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View(_adminManager.Users());
        }

        public IActionResult Categories()
        {
            return View(_adminManager.Categories());
        }

        [HttpPost]
        public  IActionResult AddCategory(string title)
        {
            _adminManager.AddCategory(title);
            return RedirectToAction("Categories", "Admin");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                OperationDetails result = await _adminManager.Delete(id);
                if (result.Succedeed)
                {
                    return RedirectToAction("Categories", "Admin");
                }
            }
            return BadRequest();
        }
    }
  }
