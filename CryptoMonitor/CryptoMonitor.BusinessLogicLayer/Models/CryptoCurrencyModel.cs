using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.DTO
{
    public class CryptoCurrencyModel
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public decimal? CurrencyPrice { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CurrencyImage { get; set; }
        public BetModel BetModel { get; set; } 
    }
}
