using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SqlInjectionExample.Models
{
    public class PasswordEntry
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }
        
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}