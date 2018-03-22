using System.Collections.Generic;

namespace DataAccess
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<User> Roles { get; set; }
    }
}