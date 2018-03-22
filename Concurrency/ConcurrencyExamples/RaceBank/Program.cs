using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RaceBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer cust1 = new Customer { CustomerId = 1, Name = "Jesper Jespersen", Account = new Account { AccountId = 1, Balance = 10000 } };

            Customer cust2 = new Customer { CustomerId = 2, Name = "Jens Jensesesesn", Account = new Account { AccountId = 2, Balance = 10000 } };
            //Locking example.. we have to make sure that account increment and decrement is atomic.. we lock the accounts
            //This example has 200 threads transfer 5000 back and forth from the account
            //Bear in mind, that lock() is syntactic sugar for Monitor.Enter
            for (int i = 0; i < 100; i++)
            {
                new Thread(() => cust1.Account.Transfer(5000, cust2.Account)).Start();
                new Thread(() => cust2.Account.Transfer(5000, cust1.Account)).Start();
            }
            Thread.Sleep(500);
            Console.WriteLine("Customer 1 balance is {0}, Customer 2 Balance is {1}", cust1.Account.Balance, cust2.Account.Balance);
            Console.ReadLine();
        }
    }
}
