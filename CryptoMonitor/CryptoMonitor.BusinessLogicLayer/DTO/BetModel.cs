using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.DTO
{
    public class BetModel
    {
        public int Id { get; set; }
        public decimal? BetPrice { get; set; }
        public int UserId { get; set; }
        public CryptoCurrencyModel Currency { get; set; }
    }
}
