using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class User : IUser
    {
        public string Address { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

    }
}
