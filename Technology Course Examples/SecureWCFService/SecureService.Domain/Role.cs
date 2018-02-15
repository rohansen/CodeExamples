using System.Collections.Generic;

namespace SecureService.Domain
{
    public class Role
    {
        public Role()
        {
            User = new List<User>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<User> User { get; set; }
    }
}