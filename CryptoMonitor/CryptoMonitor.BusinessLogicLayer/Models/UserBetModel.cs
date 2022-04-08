using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.DTO
{
    public class UserBetModel
    {
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Price { get; set; }
    }
}
