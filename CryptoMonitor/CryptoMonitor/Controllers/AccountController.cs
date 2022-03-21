using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
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
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private string accountRole = string.Empty;

        public AccountController(IAccountService accountService, IRoleService roleService, IMapper mapper)
        {
            _accountService = accountService;
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUser = _accountService.IsAccount(model.Login, model.Password);
                    if (!isUser)
                    {
                        var mapped = _mapper.Map<UserModel>(model);
                        _accountService.Registration(mapped);
                        await Authenticate(model.Login);
                        return RedirectToAction("Authorization", "Account");
                    }
                }
            }
            catch
            {
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
            try
            {
                if (ModelState.IsValid)
                {
                    var accountExist = _accountService.IsAccount(model.Login, model.Password);

                    if (accountExist)
                    {
                        await Authenticate(model.Login);
                        var userId = _accountService.GetAccountId(model.Login);
                        accountRole = _roleService.GetRole(userId);

                        switch (accountRole)
                        {
                            case "Admin":
                                return RedirectToAction("Index", "Admin");
                            case "Default user":
                                return RedirectToAction("Index", "User");
                            default:
                                return RedirectToAction("Index", "Home");
                        }

                    }
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Некорректный логин и(или) пароль.");
            }
            //return View(model);
            return RedirectToAction("Index", "Home");

        }

        private async Task Authenticate(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, accountRole),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Authorization", "Account");
        }
    }
}
