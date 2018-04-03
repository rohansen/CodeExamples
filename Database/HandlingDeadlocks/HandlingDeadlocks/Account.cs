using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingDeadlocks
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public override string ToString()
        {
            return Id + " has balance of " + Balance;
        }
    }
}
