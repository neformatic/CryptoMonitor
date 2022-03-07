using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoMonitor.DAL.Entities
{
    public class CryptoCurrency
    {
        [Key]
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public decimal? CurrencyPrice { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CurrencyImage { get; set; }
    }
}
