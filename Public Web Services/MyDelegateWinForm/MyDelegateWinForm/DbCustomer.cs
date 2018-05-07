using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateWinForm
{
    public class DbCustomer
    {

        public delegate void CreateCustomerMessage(string message);
        public event CreateCustomerMessage CustomerCreated;
        public void Create(Customer customer)
        {
            //Open connection, make command, when done: callback
            if(CustomerCreated!=null)
                CustomerCreated($"Im done inserting {customer.Name} to database");
        }

    }
}
