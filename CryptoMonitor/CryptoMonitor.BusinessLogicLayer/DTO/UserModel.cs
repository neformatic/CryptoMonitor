using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.BLL.DTO
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AccountModel Account { get; set; }
    }
}
