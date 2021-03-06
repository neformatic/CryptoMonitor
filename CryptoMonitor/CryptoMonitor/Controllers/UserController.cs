using AutoMapper;
using CryptoMonitor.BLL.DTO;
using CryptoMonitor.BLL.Interfaces;
using CryptoMonitor.Common;
using CryptoMonitor.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMonitor.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public readonly IUserService _userService;
        private readonly IBetService _betService;
        private readonly ICryptoCurrencyService _currencyService;
        private readonly IMapper _mapper;
       
        public UserController(ICryptoCurrencyService currencyService, IBetService betService, IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _betService = betService;
            _currencyService = currencyService;
            _mapper = mapper;
        }

        // GET: UserController
        [HttpGet]
        public IActionResult Index(string searchString, SortState sortOrder = SortState.CurrencyNameAsc) 
        
        {
            var currencyList = new List<CryptoCurrencyModel>();

            if (String.IsNullOrEmpty(searchString))
            {
                currencyList = _currencyService.GetCryptoCurrencies();
            }
            else
            {
                currencyList = _currencyService.SearchingCurrency(searchString);
            }
            
            var sortedList = new List<CryptoCurrencyModel>();

            ViewData["GetStringForSearch"] = searchString;
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
        [Authorize(Roles = nameof(RoleTypes.DefaultUser))]
        public IActionResult Bet([FromForm]UserBetViewModel userBetViewModel)
        {
            var userLogin = HttpContext.User.Identity.Name;
            var userId = _userService.GetUserId(userLogin); 

            var userBetModel = new BetModel()
            {
               BetPrice = userBetViewModel.Price,
               CurrencyId = userBetViewModel.CurrencyId,
               UserId = userId
            };
            _betService.AddUserBet(userBetModel);
            return RedirectToAction("Index", "User");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Authorization", "Account");
        }

        [HttpGet]
        public IActionResult UserCurrencyBets(int id)
        {
            try
            {
                var currencyNames = _betService.GetCurrencyNamesByUserId(id);
                return Ok(currencyNames);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
