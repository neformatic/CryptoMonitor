using CryptoMonitor.DAL.Entities;
using CryptoMonitor.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMonitor.Controllers
{
    public class HomeController : Controller
    {
       [Authorize]
       public IActionResult Index()
        {
            return Content(User.Identity.Name);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Authorization", "Account");
        }
    }
}
