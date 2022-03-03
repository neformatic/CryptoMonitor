using System.ComponentModel.DataAnnotations;

namespace CryptoMonitor.Web.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
    }
}
