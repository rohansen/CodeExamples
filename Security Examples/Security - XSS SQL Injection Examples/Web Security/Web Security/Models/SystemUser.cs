using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Security.Models
{
    public class SystemUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SystemUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
    }
}