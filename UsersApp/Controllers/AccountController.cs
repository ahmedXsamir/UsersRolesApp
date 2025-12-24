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

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(model.Email).Result;

                if (user != null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (result)
                    {
                        await _signInManager.SignInAsync(user, model.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View("Login", model);
                }
            }

            return RedirectToAction("Login", model);
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
