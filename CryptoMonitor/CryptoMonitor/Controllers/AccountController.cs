using CryptoMonitor.BLL.Services;
using CryptoMonitor.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMonitor.Web.Controllers
{
    public class AccountController : Controller
    {
        private AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authorization(AuthorizationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isUser = _accountService.IsAccount(model.Login, model.Password);
                if (!isUser)
                {
                    ModelState.AddModelError("Password", "Неверный логин или пароль");
                    return BadRequest();
                }
                return View();
            }
            return View(ModelState);       
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();   
        }
        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isAccount = _accountService.IsAccount(model.Login, model.Password);
                if (!isAccount)
                {
                    _accountService.AddNewAccount(model.Login, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Login", "Login is taken");
            }
            return RedirectToAction("Registration");
        }


    }
}
