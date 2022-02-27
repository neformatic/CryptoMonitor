using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoMonitor.DAL.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AccountLogin { get; set; }
        [Required]
        public int AccountPassword { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
