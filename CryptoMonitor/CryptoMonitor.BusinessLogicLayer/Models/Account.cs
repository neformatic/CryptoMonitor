using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CryptoMonitor.BLL.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountLogin { get; set; }
        public string AccountPassword { get; set; }
        public int RoleId { get; set; }
    }
}
