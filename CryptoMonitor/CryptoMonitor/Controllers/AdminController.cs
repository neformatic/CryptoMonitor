using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoMonitor.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICryptoCurrencyService _currencyService;
        private readonly IMapper _mapper;
        public AdminController(ICryptoCurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }
        // GET: AdminController
        public IActionResult Index()
        {
            var currencyList = _currencyService.GetCryptoCurrencies();
            List<CryptoCurrencyViewModel> mappedModel = new List<CryptoCurrencyViewModel>();
            foreach (var currency in currencyList)
            {
                var mapped = _mapper.Map<CryptoCurrencyViewModel>(currency);
                mappedModel.Add(mapped);
            }
            return View(mappedModel);
        }

        // GET: AdminController/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                var currencyById = _currencyService.GetCryptoCurrencyById(id);
                var mappedModel = _mapper.Map<CryptoCurrencyViewModel>(currencyById);
                return View(mappedModel);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: AdminController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CryptoCurrencyViewModel currencyViewModel)
        {
            var mapped = _mapper.Map<CryptoCurrencyModel>(currencyViewModel);
            _currencyService.AddCryptoCurrency(mapped);
            return RedirectToAction("Index");
        }

        // GET: AdminController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        //// POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CryptoCurrencyViewModel currencyViewModel)
        {
            try
            {
                var mappedModel = _mapper.Map<CryptoCurrencyModel>(currencyViewModel);
                _currencyService.EditCryptoCurrency(mappedModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                _currencyService.DeleteCryptoCurrency(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Authorization", "Account");
        }
    }
}
