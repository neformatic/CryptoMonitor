using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.DTO
{
    public class BetDataModel
    {
        public int Id { get; set; }
        public decimal BetPrice { get; set; }
        public DateTime? BetDate { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
    }
}
