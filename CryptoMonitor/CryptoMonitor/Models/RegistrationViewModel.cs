using System.ComponentModel.DataAnnotations;

namespace CryptoMonitor.Web.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [StringLength(10)]
        [MinLength(3, ErrorMessage = "Логин должен быть от 3 до 10 символов")]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
    }
}
