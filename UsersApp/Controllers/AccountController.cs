using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersApp.Models;
using UsersApp.ViewModels;

namespace UsersApp.Controllers
{
    public class AccountController : Controller   
    {
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        public AccountController(SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Registration logic here
                Users users = new Users
                {
                    FullName = model.Name,
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(users, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Login");

                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View("Register", model);
                }
            }
            return View("Register", model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        



        public IActionResult VerifyEmail()
        {
            return View("VerifyEmail");
        }

        public IActionResult ChangePassword()
        {
            return View("ChangePassword");
        }
    }
}
