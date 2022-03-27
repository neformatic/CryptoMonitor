using CryptoMonitor.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.DTO
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string AccountLogin { get; set; }
        public string AccountPassword { get; set; }
        public RoleTypes Role { get; set; }
    }
}
