using CryptoMonitor.BLL.DTO;

namespace CryptoMonitor.Web.Models
{
    public class BetViewModel
    {
        public int Id { get; set; }
        public decimal? BetPrice { get; set; }
        public UserModel UserModel { get; set; }
        public CryptoCurrencyModel CurrencyModel { get; set; }
    }
}
