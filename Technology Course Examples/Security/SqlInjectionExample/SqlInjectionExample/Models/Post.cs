using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SqlInjectionExample.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}