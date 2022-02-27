using System.ComponentModel.DataAnnotations;

namespace CryptoMonitor.DAL.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
