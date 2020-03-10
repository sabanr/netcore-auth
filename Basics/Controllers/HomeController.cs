using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() { return View(); }

        [Authorize]
        public IActionResult Secret() { return View(); }

        public async Task<IActionResult> Authenticate() {

            var grandmaClaims = new List<Claim> {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim(ClaimTypes.Email, "bob@mail.com"),
                new Claim("Grandma.Says", "Very nice boi.")
            };

            var licenseClaims = new List<Claim> {
                new Claim(ClaimTypes.Name, "Bob K Foo"),
                new Claim("DrivingLicense", "A+")
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
            var licenseIndentity = new ClaimsIdentity(licenseClaims, "Government");
            
            var userPrincipal = new ClaimsPrincipal(new [] { grandmaIdentity, licenseIndentity });

            await HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}