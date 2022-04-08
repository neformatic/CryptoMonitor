using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CryptoMonitor.DAL.Entities
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }
        public decimal BetPrice { get; set; }
        public DateTime? BetDate { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual CryptoCurrency Currency { get; set; }
    }
}
