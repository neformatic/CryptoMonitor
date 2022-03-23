using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.Common;
using CryptoMonitor.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMonitor.Web.Controllers
{
    [Authorize(Roles = nameof(RoleTypes.Admin))]
    public class AdminController : Controller
    {
        private readonly ICryptoCurrencyService _currencyService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(ICryptoCurrencyService currencyService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _currencyService = currencyService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment; // получим доступ к корневой папке wwwroot через IWebHostEnvironment
        }
        // GET: AdminController
        public IActionResult Index(SortState sortOrder = SortState.CurrencyNameAsc)
        {
            var currencyList = _currencyService.GetCryptoCurrencies();

            var sortedList = new List<CryptoCurrencyModel>();

            foreach (var currency in currencyList)
            {
                if (currency.CurrencyImage == null)
                {
                    
                }
                else
                {
                    currency.CurrencyImage = Path.Combine(WebConstants.ImagePath, currency.CurrencyImage);
                }
            }

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
        //[Authorize(Roles = "Admin")]
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
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public IActionResult Create([FromForm]CryptoCurrencyViewModel currencyViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var images = HttpContext.Request.Form.Files;
                    string webRootPath = _webHostEnvironment.WebRootPath;

                    string addCurrencyImage = webRootPath + WebConstants.ImagePath;
                    string imageName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(images[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(addCurrencyImage, imageName + extension), FileMode.Create))
                    {
                        images[0].CopyTo(fileStream);
                    }

                    currencyViewModel.CurrencyImage = imageName + extension;

                    var mapped = _mapper.Map<CryptoCurrencyModel>(currencyViewModel);
                    _currencyService.AddCryptoCurrency(mapped);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("Create", "Error!");
            }
            return View();


        }

        // GET: AdminController/Edit/5
        //[Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            return View();
        }

        //// POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, [FromForm] CryptoCurrencyViewModel currencyViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var images = HttpContext.Request.Form.Files;
                    string webRootPath = _webHostEnvironment.WebRootPath;

                    string addCurrencyImage = webRootPath + WebConstants.ImagePath;
                    string imageName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(images[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(addCurrencyImage, imageName + extension), FileMode.Create))
                    {
                        images[0].CopyTo(fileStream);
                    }

                    currencyViewModel.CurrencyImage = imageName + extension;

                    var mappedModel = _mapper.Map<CryptoCurrencyModel>(currencyViewModel);
                    mappedModel.Id = id;
                    var currencyById = _currencyService.GetCryptoCurrencyById(id);
                    var filePath = webRootPath + WebConstants.ImagePath + "\\" + currencyById.CurrencyImage;
                    System.IO.File.Delete(filePath);
                    _currencyService.EditCryptoCurrency(mappedModel);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return NotFound();
            }
            return View();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
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
