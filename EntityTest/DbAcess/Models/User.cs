using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAcess.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Telephone { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
