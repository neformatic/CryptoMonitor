using CryptoMonitor.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMonitor.DAL.DTO
{
    public class UserDataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountId { get; set; }
        public int? CryptoCurrencyId { get; set; }
    }
}
