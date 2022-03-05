using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CryptoMonitor.BLL.Models
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AccountLogin { get; set; }
        [Required]
        public string AccountPassword { get; set; }
        public int RoleId { get; set; }
    }
}
