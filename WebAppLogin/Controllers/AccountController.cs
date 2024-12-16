using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLogin.Models;

namespace WebAppLogin.Controllers
{
    public class AccountController : Controller
    {
        private readonly List<User> _users ;
        public AccountController()
        {
            _users = new List<User>
            {
                new User{Userid=1,Username="Alfiyan",Password="Alje123",Email="alje@gmail.com"},
                new User{Userid=2,Username="ari",Password="Alje123",Email="alje@gmail.com"}
            };
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _users.FirstOrDefault(m => m.Username == model.Username && m.Password == model.Password);
                if (user != null)
                {
                    TempData["Message"] = "Login successful";
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("","Invalid Username of Password.");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.OldPassword);
                if (user != null)
                {
                    if (model.NewPassword==model.ConfirmPassword)
                    {
                        user.Password = model.NewPassword;
                        TempData["Message"] = "Password changed successfully";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("","New Password and Confirm Password do not match");
                    }
                }
                else
                {
                    ModelState.AddModelError("","Invalid Username or Password");
                }
            }
            return View(model);
        }
    }
}
