using System.ComponentModel.DataAnnotations;

namespace PasswordSecurity
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}