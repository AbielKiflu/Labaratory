﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [MaxLength(50)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(50)]
        public string Salt { get; set; }


        [MaxLength(15)]
        public string Telephone { get; set; }

        public bool EmailConfirmed { get; set; } = false;

        [Required]
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
