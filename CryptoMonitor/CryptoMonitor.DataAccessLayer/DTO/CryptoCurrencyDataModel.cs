using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.DTO
{
    public class CryptoCurrencyDataModel
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public decimal? CurrencyPrice { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CurrencyImage { get; set; }
        public BetDataModel BetDataModel { get; set; }
    }
}
