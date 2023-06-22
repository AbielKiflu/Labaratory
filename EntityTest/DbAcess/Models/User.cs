using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAcess.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }


        [MaxLength(15)]
        public string? Telephone { get; set; }

        public bool? EmailConfirmed { get; set; } = false;


        public List<Address>? Addresses { get; set; } = new List<Address>();
    }
}
