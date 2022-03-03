using System.ComponentModel.DataAnnotations;

namespace CryptoMonitor.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }

}
