using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMonitor.Web.Models
{
    public class ShortCurrencyViewModel
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyImage { get; set; }
    }
}
