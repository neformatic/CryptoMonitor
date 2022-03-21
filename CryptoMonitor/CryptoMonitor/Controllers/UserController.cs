using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMonitor.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ICryptoCurrencyService _currencyService;
        private readonly IMapper _mapper;
       
        public UserController(ICryptoCurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        // GET: UserController
        public ActionResult Index(string searchString, SortState sortOrder = SortState.CurrencyNameAsc)
        {
            var currencyList = new List<CryptoCurrencyModel>();

            if (String.IsNullOrEmpty(searchString))
            {
                currencyList = _currencyService.GetCryptoCurrencies();
            }
            else
            {
                currencyList = _currencyService.searchingCurrency(searchString);
            }         

            var sortedList = new List<CryptoCurrencyModel>();

            ViewData["GetCurrencyForSearch"] = searchString;
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

<<<<<<< HEAD
<<<<<<< Updated upstream
        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
=======
            ViewData["GetStringForSearch"] = searchString;
            ViewData["SortByName"] = sortOrder == SortState.CurrencyNameAsc ? SortState.CurrencyNameDesc : SortState.CurrencyNameAsc;
            ViewData["SortByPrice"] = sortOrder == SortState.CurrencyPriceAsc ? SortState.CurrencyPriceDesc : SortState.CurrencyPriceAsc;
            ViewData["SortByDate"] = sortOrder == SortState.CurrencyUpdatedDateAsc ? SortState.CurrencyUpdatedDateDesc : SortState.CurrencyUpdatedDateAsc;
>>>>>>> Stashed changes

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
=======
>>>>>>> 1bb58dfca959324f792d11b8fe29c78f3ac897bd
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Authorization", "Account");
        }
    }
}
