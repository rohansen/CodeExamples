using Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbUser
    {
        //Notes   
        //Could have implemented the callback as an event; but i was lazy :-)
        //1. Identify problems using no transactions
        //2. Identify problems using different isolation levels
        public void Withdraw(Account p, decimal amount, Action<string> callback)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=MyDeadlockedDb;Integrated Security=True"))
            {   //Dispose will call Close()
                decimal currentBalance = decimal.MinValue;
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT Balance FROM Account WHERE Id=@id";
                    cmd.Parameters.AddWithValue("id", p.Id);
                    currentBalance = (decimal)cmd.ExecuteScalar();
                    callback("Retrieved current balance as " + currentBalance);
                }

                if (currentBalance >= amount)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        Thread.Sleep(2000);
                        cmd.CommandText = "UPDATE [Account] SET Balance=Balance-@balance WHERE Id=@id";
                        cmd.Parameters.AddWithValue("id", p.Id);
                        cmd.Parameters.AddWithValue("balance", amount);
                        cmd.ExecuteNonQuery();
                        callback("Updated balance to " + (p.Balance-amount).ToString());
                    }
                }
                else
                {
                    callback("Insufficient funds...");
                    return;
                }
                
            }
        }
        
        //Alternative way of ADOing https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/linq/walkthrough-simple-object-model-and-query-csharp
        //Will return n..* rows per account per user! --> each row represents an acount, but carries the user information
        //If no account exists on the found user, the account values are NULL (LEFT JOIN)
        public IEnumerable<User> GetAllUsersWithAccounts()
        {
            List<User> foundUsers = new List<User>();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=MyDeadlockedDb;Integrated Security=True"))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM [User] u LEFT JOIN Account a ON u.Id=a.UserId";
                var rdr = cmd.ExecuteReader();
                User currentUser = null;
                while (rdr.Read())
                {
                   if(currentUser != null && currentUser.Id== (int)rdr["Id"])
                    {
                        //This is a currently created and added user --> next information must be account info
                        BuildAccount(currentUser, rdr);
                    }
                    else
                    {
                    
                        //This is a user not yet processed, create the user
                        User newUser = new User { Id = (int)rdr["Id"], Name = (string)rdr["Name"] };
                        //Build the first rows associated account if it exists
                        BuildAccount(newUser, rdr);
                        foundUsers.Add(newUser);
                        //set currentUser
                        currentUser = newUser;
                    }
                    
                    
                }
            }
            return foundUsers;
        }
        /// <summary>
        /// Returns false if there has been an optimistic concurrency error
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public bool UpdateUser(User u, bool concurrencyCheck)
        {

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                //In this example i have used MSSQL Servers built in timestamp datatype. I called my column RowVersion (and also added this to my Model "User")
                //You could also check the actual values of your data in columns you find interesting
                //Another approach is to 1. Query data from the database, 2. let the user modify the data. Query the database again and check if values have changed. Then commit
                if (concurrencyCheck)
                {

                    cmd.CommandText = "UPDATE [User] SET Name=@name WHERE Id=@id AND RowVersion=@version";
                    cmd.Parameters.AddWithValue("version", u.RowVersion);
                }
                else
                {
                    cmd.CommandText = "UPDATE [User] SET Name=@name WHERE Id=@id";
                }

                cmd.Parameters.AddWithValue("id", u.Id);
                cmd.Parameters.AddWithValue("name", u.Name);

                int rowsChanged = cmd.ExecuteNonQuery();
                return rowsChanged == 1;
            }
        }
        private void BuildAccount(User newUser, SqlDataReader rdr)
        {
            if (rdr.IsDBNull(rdr.GetOrdinal("UserId")))//If this column is null, the row contains no account info
                return;
            newUser.Accounts.Add(new Account { Id = (int)rdr["Id"], Balance = Convert.ToDecimal(rdr["Balance"]), UserId=newUser.Id, User = newUser });

        }
        public IEnumerable<Account> GetAllAccountsFromUser(int userId)
        {
            List<Account> foundAccounts = new List<Account>();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=MyDeadlockedDb;Integrated Security=True"))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM Account WHERE UserId=@uid";
                cmd.Parameters.AddWithValue("uid", userId);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    foundAccounts.Add(new Account { Id = (int)rdr["Id"], Balance = Convert.ToDecimal(rdr["Balance"]), UserId=userId });
                }
            }
            return foundAccounts;
        }
    }
}
