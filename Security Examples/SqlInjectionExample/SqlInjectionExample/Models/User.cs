using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SqlInjectionExample.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Role { get; set; }
        public int Points { get; set; }
        public virtual ICollection<PasswordEntry> StoredPasswords { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}