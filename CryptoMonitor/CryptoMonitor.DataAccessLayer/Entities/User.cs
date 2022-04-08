using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoMonitor.DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public decimal UserBet { get; set; }
        public int AccountId { get; set; }
        public int? CryptoCurrencyId { get; set; }
        public virtual Account Account { get; set; }
        [ForeignKey("CryptoCurrencyId")]
        public virtual CryptoCurrency Currency { get; set; }
    }
}
