using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CryptoMonitor.BLL.Models
{
    public class CryptoCurrencyModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CurrencyName { get; set; }
        public decimal? CurrencyPrice { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CurrencyImage { get; set; }
    }
}
