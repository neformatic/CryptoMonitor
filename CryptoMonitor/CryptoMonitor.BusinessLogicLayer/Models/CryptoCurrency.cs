using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CryptoMonitor.BLL.Models
{
    public class CryptoCurrency
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public decimal? CurrencyPrice { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CurrencyImage { get; set; }
    }
}
