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
        public int CurrencyId { get; set; }
        public CryptoCurrencyModel Currency { get; set; }
        public bool IsWonBet { get; set; }
        public bool IsNotified { get; set; }
    }
}
