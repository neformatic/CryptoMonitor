using System.ComponentModel.DataAnnotations;

namespace CryptoMonitor.Web.Models
{
    public class AuthorizationViewModel
    {
        [Required(ErrorMessage = "Please enter Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
    }

}
