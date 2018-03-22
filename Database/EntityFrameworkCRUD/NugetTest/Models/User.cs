using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetTest.Models
{
    
    public class User
    {
        public User()
        {
            BlogPosts = new List<BlogPost>();
        }
        public int Id { get; set; }
        
        [Required]
        public string Email { get; set; }

        public int? Age { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }


        public List<BlogPost> BlogPosts { get; set; }




        public override string ToString()
        {
            return $"{Email} with pw: {Password}";
        }
    }
}
