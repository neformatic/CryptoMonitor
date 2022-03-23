using CryptoMonitor.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoMonitor.DAL.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string AccountLogin { get; set; }
        public string AccountPassword { get; set; }
        public RoleTypes Role { get; set; }

        public virtual User User { get; set; }
    }
}
