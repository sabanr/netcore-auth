using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;

using IdentityExample.Data;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index() { return View(); }

        [Authorize]
        public IActionResult Secret() { return View(); }

        public IActionResult Login() { return View(); }

        public async Task<IActionResult> Login(string username, string password) {
            
            // login functionality
            var user = await _userManager.FindByNameAsync(username);

            if (user != null) {
                // sign in
            }
            return RedirectToAction("Index");
        }

        public IActionResult Register() { return View(); }

        public async Task<IActionResult> Register(string username, string password) {
            
            // register functionality
            var user = new IdentityUser(username);
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded) {
                // sign user here
            }
            return RedirectToAction("Index");
        }
    }
}