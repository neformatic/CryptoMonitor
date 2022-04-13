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
        public bool IsNotified { get; set; }
        public bool IsWonBet { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual CryptoCurrency Currency { get; set; }
        //потом в сервисе поменял цену валюты - иду по ставкам и смотрю, те ставки которые имеют действительные ставки - поле зашла = false - смотрю, моя цена валюты > чем ставка или нет, если да - пишу, что ставка зашла - меняю поле false на true
        //на уведомлениях
        //
    }
}
