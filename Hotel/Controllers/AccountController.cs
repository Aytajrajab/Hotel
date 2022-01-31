using Hotel.Models;
using Hotel.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(RegisterAndLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.LoginViewModel.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Credentials");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.LoginViewModel.Password, model.LoginViewModel.Persistent, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Credentials");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterAndLoginViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", registerModel);
            }
            var dbUser = await _userManager.FindByNameAsync(registerModel.RegisterViewModel.UserName);
            if (dbUser != null)
            {
                ModelState.AddModelError(nameof(RegisterViewModel.UserName),
                    "The user with this username is already exits.");
                return View("Login", registerModel);
            }

            User user = new User
            {
                UserName = registerModel.RegisterViewModel.UserName,
                Email = registerModel.RegisterViewModel.Email,
                FullName = registerModel.RegisterViewModel.FullName,
            };

            var identityResult = await _userManager.CreateAsync(user, registerModel.RegisterViewModel.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View("Login", registerModel);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
