using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index(SortState sortOrder = SortState.CurrencyNameAsc)
        {
            var currencyList = _currencyService.GetCryptoCurrencies();

            var sortedList = new List<CryptoCurrencyModel>();

            ViewData["SortByName"] = sortOrder == SortState.CurrencyNameAsc ? SortState.CurrencyNameDesc : SortState.CurrencyNameAsc;
            ViewData["SortByPrice"] = sortOrder == SortState.CurrencyPriceAsc ? SortState.CurrencyPriceDesc : SortState.CurrencyPriceAsc;
            ViewData["SortByDate"] = sortOrder == SortState.CurrencyUpdatedDateAsc ? SortState.CurrencyUpdatedDateDesc : SortState.CurrencyUpdatedDateAsc;

            switch (sortOrder)
            {
                case SortState.CurrencyNameAsc:
                    sortedList = currencyList.OrderBy(c => c.CurrencyName).ToList();
                    break;
                case SortState.CurrencyNameDesc:
                    sortedList = currencyList.OrderByDescending(c => c.CurrencyName).ToList();
                    break;
                case SortState.CurrencyPriceAsc:
                    sortedList = currencyList.OrderBy(c => c.CurrencyPrice).ToList();
                    break;
                case SortState.CurrencyPriceDesc:
                    sortedList = currencyList.OrderByDescending(c => c.CurrencyPrice).ToList();
                    break;
                case SortState.CurrencyUpdatedDateAsc:
                    sortedList = currencyList.OrderBy(c => c.UpdatedDate).ToList();
                    break;
                case SortState.CurrencyUpdatedDateDesc:
                    sortedList = currencyList.OrderByDescending(c => c.UpdatedDate).ToList();
                    break;
                default:
                    break;
            }

            List<CryptoCurrencyViewModel> mappedModel = _mapper.Map<List<CryptoCurrencyViewModel>>(sortedList);

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
        public IActionResult Create([FromForm]CryptoCurrencyViewModel currencyViewModel)
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
        public IActionResult Edit([FromForm]CryptoCurrencyViewModel currencyViewModel)
        {
            try
            {
                var mappedModel = _mapper.Map<CryptoCurrencyModel>(currencyViewModel);
                _currencyService.EditCryptoCurrency(mappedModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound();
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
