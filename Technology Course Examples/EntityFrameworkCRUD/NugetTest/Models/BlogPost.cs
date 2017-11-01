using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetTest.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
