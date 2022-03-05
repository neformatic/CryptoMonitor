using CryptoMonitor.BLL.Services;
using CryptoMonitor.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CryptoMonitor.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isUser = _accountService.IsAccount(model.Login, model.Password);
                if (!isUser)
                {
                    _accountService.UserRegistration(model.Login, model.Password, model.LastName, model.FirstName);
                    await Authenticate(model.Login);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Login", "Login is taken");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            return View();   
        }

        [HttpPost]
        public async Task<IActionResult> Authorization(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userExist = _accountService.IsAccount(model.Login, model.Password);

                if (userExist)
                {
                    await Authenticate(model.Login);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Некорректный логин и(или) пароль.");
            }

            return View(model);       
        }

        private async Task Authenticate(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
