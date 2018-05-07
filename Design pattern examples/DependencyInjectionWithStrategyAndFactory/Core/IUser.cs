using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUser
    {
        int Id { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string Address { get; set; }
    }
}
