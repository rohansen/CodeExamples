using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class User
    {
        public User()
        {
            Accounts = new List<Account>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
        public byte[] RowVersion { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
 
}
