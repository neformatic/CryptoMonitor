using CryptoMonitor.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.DTO
{
    public class AccountDataModel
    {
        public int Id { get; set; }
        public string AccountLogin { get; set; }
        public string AccountPassword { get; set; }
        public int RoleId { get; set; }
    }
}
