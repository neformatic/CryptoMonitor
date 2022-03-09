using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMonitor.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICryptoCurrencyService _currencyService;
        public AdminController(ICryptoCurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        // GET: AdminController
        public IActionResult Index()
        {
            var currencyList = _currencyService.GetCryptoCurrencies();
            return View(currencyList);
        }

        // GET: AdminController/Details/5
        public IActionResult Details(int id)
        {
            var currencyById = _currencyService.GetCryptoCurrencyById(id);
            return View(currencyById);
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
            _currencyService.AddCryptoCurrency(currencyViewModel.CurrencyName, currencyViewModel.CurrencyPrice, currencyViewModel.UpdatedDate, currencyViewModel.CurrencyImage);
            return RedirectToAction("Index");
        }

        // GET: AdminController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        //// POST: AdminController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, CryptoCurrencyViewModel currencyViewModel)
        //{
        //    try
        //    {
        //        _currencyService.EditCryptoCurrency(id, currencyViewModel.CurrencyName, currencyViewModel.CurrencyPrice, currencyViewModel.UpdatedDate, currencyViewModel.CurrencyImage);
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        // GET: AdminController/Delete/5
        //public IActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                _currencyService.DeleteCryptoCurrency(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
