using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return View(currencyList);
        }

        // GET: AdminController/Details/5
        public IActionResult Details(int id) // переделать
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
