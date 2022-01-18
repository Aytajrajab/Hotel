using Hotel.Areas.Admin.ViewModels;
using Hotel.DAL;
using Hotel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly HotelDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(HotelDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            var userList = new List<UserViewModel>();

            foreach (var user in users)
            {
                userList.Add(new UserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = (await _userManager.GetRolesAsync(user))[0]
                });
            }
            return View(userList);
        }


        public async Task<IActionResult> ChangePassword(string Id)
        {

            var user = await _context.Users.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new ChangePasswordViewModel()
            {
                Id = user.Id,
                UserName = user.UserName
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string Id, ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ModelState.AddModelError("", "Not found");
                return View();
            }


            ChangePasswordViewModel viewModel = new ChangePasswordViewModel()
            {
                Id = model.Id,
                UserName = model.UserName
            };

            var checkPassword = await _userManager.CheckPasswordAsync(user, model.OldPassword);
            if (!checkPassword)
            {
                ModelState.AddModelError("", "Incorrect");
                return View(viewModel);
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Try again");
                return View();
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string id, string role)
        {

            var user = await _context.Users.FindAsync(id);

            await _userManager.AddToRoleAsync(user, role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BlockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.SetLockoutEnabledAsync(user, true);
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Parse("12/02/23"));
            await _userManager.UpdateSecurityStampAsync(user);
            return RedirectToAction("Index");
        }
    }
}
