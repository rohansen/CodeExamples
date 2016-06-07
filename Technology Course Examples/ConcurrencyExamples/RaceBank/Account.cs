using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceBank
{
    public class Account
    {
        public int AccountId { get; set; }
        public int Balance { get; set; }
        /// <summary>
        /// Transfers an amount of money, to the provided account
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="account"></param>
        public void TransferSafe(int amount, Account accountTo)
        {
            lock (this)
            {
                lock (accountTo)
                {
                    for (int i = 0; i < amount; i++)
                    {
                        Balance -= 1;
                        accountTo.Balance += 1;

                    }
                    
                }
            }

        }
        public void Transfer(int amount, Account accountTo)
        {
            for (int i = 0; i < amount; i++)
            {
                Balance -= 1;
                accountTo.Balance += 1;

            }
        }
    }
}
