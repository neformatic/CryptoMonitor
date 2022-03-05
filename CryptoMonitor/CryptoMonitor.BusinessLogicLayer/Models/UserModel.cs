using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CryptoMonitor.BLL.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int AccountId { get; set; }
        public int CryptoCurrencyId { get; set; }
    }
}
