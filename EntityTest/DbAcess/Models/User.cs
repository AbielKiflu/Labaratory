using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAcess.Models
{
    public class User
    {
        public int Id { get; set; }

        
        public int Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Salt { get; set; }


        [MaxLength(15)]
        public string Telephone { get; set; }

        [Required]
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
