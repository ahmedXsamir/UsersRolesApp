using Microsoft.AspNetCore.Mvc;

namespace UsersApp.Controllers
{
    public class AccountController : Controller   
    {
        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult Register()
        {
            return View("Register");
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
