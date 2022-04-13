using System.ComponentModel.DataAnnotations;

namespace CryptoMonitor.Web.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [MinLength(3, ErrorMessage = "Логин должен быть больше 3 символов")]
        [MaxLength(11, ErrorMessage = "Логин не должен превышать 11 символов")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(20,MinimumLength = 5, ErrorMessage = "Диапазон пароля от 5 до 20 символов")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; }
    }
}
