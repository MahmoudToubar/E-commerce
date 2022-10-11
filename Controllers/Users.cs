using E_commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Controllers
{
    public class Users : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signinManager;
        public Users(UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signManager)
        {
            userManager = manager;
            signinManager = signManager;
        }
        public IActionResult Login(string ReturnUrl)
        {
            return View(new UserModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Regist()
        {
            return View();
        }
        public async Task<IActionResult> Register(UserModel userModel)
        {
            var user = new ApplicationUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };
            var result = await userManager.CreateAsync(user, userModel.Password);

            if (result.Succeeded)
            {
                return Redirect("~/");
            }
            else
                return View("Regist", userModel);
        }
        public async Task<IActionResult> LogOut()
        {
            await signinManager.SignOutAsync();
            return Redirect("~/");
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            var result = await signinManager.PasswordSignInAsync(userModel.Email, userModel.Password, true, true);

            if (string.IsNullOrEmpty(userModel.ReturnUrl))
                userModel.ReturnUrl = "~/";

            if (result.Succeeded)
            {
                return Redirect(userModel.ReturnUrl);
            }
            else
                return View("Login", userModel);
        }
    }
}
