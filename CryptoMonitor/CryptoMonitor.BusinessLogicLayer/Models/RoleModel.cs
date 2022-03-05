using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CryptoMonitor.BLL.Models
{
    public class RoleModel
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
