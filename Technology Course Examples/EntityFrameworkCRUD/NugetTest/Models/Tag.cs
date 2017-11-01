using System.Collections.Generic;

namespace NugetTest.Models
{
    public class Tag
    {
        public Tag()
        {
            BlogPosts = new List<BlogPost>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
    }
}