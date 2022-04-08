using CryptoMonitor.BLL.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoMonitor.Web.Models
{
    public class CryptoCurrencyViewModel
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public decimal CurrencyPrice { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CurrencyImage { get; set; }
        public IFormFile Image { get; set; }
        public BetModel BetModel { get; set; }
    }
}
