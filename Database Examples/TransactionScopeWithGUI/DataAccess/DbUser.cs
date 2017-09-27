using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess
{
    public class DbUser : ICRUD<User>, IDisposable
    {
        private string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlConnection connection;

        public DbUser()
        {
            connection = new SqlConnection(CONNECTION_STRING);
        }
        public void Create(User entity)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [User] (FirstName, LastName) VALUES (@firstName,@lastName)";
                    cmd.Parameters.AddWithValue("@firstName", entity.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", entity.LastName);
                    cmd.ExecuteNonQuery();
                    scope.Complete();
                }
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM User WHERE ID=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    scope.Complete();
                }
                connection.Close();
            }
        }

        public User Get(int id)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
            User user;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT FirstName, LastName FROM User WHERE ID=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    scope.Complete();
                    user = new User();
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        user.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    }

                }
                connection.Close();
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
            List<User> users;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM User";
                    var reader = cmd.ExecuteReader();
                    scope.Complete();
                    users = new List<User>();
                    while (reader.Read())
                    {
                        User newUser = new User();

                        newUser.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        newUser.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        newUser.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        users.Add(newUser);
                    }
                }
            }
            connection.Close();
            return users;
        }

        public void Update(User entity)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UDPATE User SET FirstName=@fn, LastName = @ln WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    cmd.Parameters.AddWithValue("@fn", entity.FirstName);
                    cmd.Parameters.AddWithValue("@ln", entity.LastName);
                    var reader = cmd.ExecuteNonQuery();
                    scope.Complete();

                }
            }
            connection.Close();
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }
    }
}
