using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSecurityScan
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + args[0]);
        }
    }
}
