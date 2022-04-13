using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.Common;
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
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;

            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var accountModel = _accountService.GetAccountModel(model.Login, model.Password);
                    if (accountModel == null)
                    {
                        var mapped = _mapper.Map<UserModel>(model);
                        _accountService.Registration(mapped);
                        Authenticate(model.Login, RoleTypes.DefaultUser);
                        return RedirectToAction("Authorization", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("Login", "Login is taken");
                    }
                }
            }
            catch
            {

            }
            return View(model);
        }   

        [HttpGet]
        public IActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authorization(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var accountModel = _accountService.GetAccountModel(model.Login, model.Password); 
                    if (accountModel != null)
                    {
                        var accountRole = accountModel.Role;
                        Authenticate(model.Login, accountRole);
                        switch (accountRole)
                        {
                            case RoleTypes.Admin:
                                return RedirectToAction("Index", "Admin");
                            case RoleTypes.DefaultUser:
                                return RedirectToAction("Index", "User");
                            default:
                                return RedirectToAction("Index", "Home");
                        }
                        
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Некорректный логин и(или) пароль.");
                    }
                }
            }
            catch
            {
            }
            return View(model);
        }

        private void Authenticate(string login, RoleTypes accountRole)
        {
            var role = accountRole.ToString(); 
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,  role),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Authorization", "Account");
        }
    }
}
