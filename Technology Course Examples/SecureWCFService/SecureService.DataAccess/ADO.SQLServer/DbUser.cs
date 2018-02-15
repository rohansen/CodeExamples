using SecureService.DataAccess.Interfaces;
using SecureService.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.DataAccess.ADO.SQLServer
{
    public class DbUser : IDatabaseCrud<User>
    {
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(string query)
        {
            throw new NotImplementedException();
        }
        public User Get(int id)
        {
            List<Role> userRoles = new List<Role> { new Role { Id = 1, Title = "Admin" } };
            return new User { Id = 1, Email = "roh@ucn.dk", Password = "1234", Roles = userRoles };
        }
        public User Get(string email)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    string sql = "SELECT Users.Id as UserId,Email, Password, Roles.Id as RoleId," +
                                    "Title FROM Users" +
                                    "JOIN UserRoles ON Users.Id = UserRoles.UserId" +
                                    "JOIN Roles ON UserRoles.RoleId = Roles.Id" +
                                    "WHERE Email = @email";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("email", email);
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        return null;
                    }
                    else
                    {
                        reader.Read();//advance pointer 1 row, and get the user information from the first row
                        var foundUser = new User();
                        foundUser.Id = reader.GetInt32(reader.GetOrdinal("UserId"));
                        foundUser.Email = reader.GetString(reader.GetOrdinal("Email"));
                        foundUser.Password = reader.GetString(reader.GetOrdinal("Password"));

                        while (reader.Read())//Continue advancing the pointer untill the end, and save the Role information
                        {
                            Role foundRole = new Role();
                            foundRole.Title = reader.GetString(reader.GetOrdinal("Title"));
                            foundRole.Id = reader.GetInt32(reader.GetOrdinal("RoleId"));
                            foundUser.Roles.Add(foundRole);
                        }
                        return foundUser;
                    }
                }
            }
        }

        public User Login(string username, string password)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    string sql = "SELECT Users.Id as UserId,Email, Password, Roles.Id as RoleId,"+
                                    "Title FROM Users" +
                                    "JOIN UserRoles ON Users.Id = UserRoles.UserId" +
                                    "JOIN Roles ON UserRoles.RoleId = Roles.Id" +
                                    "WHERE Email = @email AND Password = @password";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("email", username);
                    cmd.Parameters.AddWithValue("password", password);
                    var reader = cmd.ExecuteReader();
                    if(!reader.HasRows)
                    {
                        return null;
                    }else
                    {
                        reader.Read();//advance pointer 1 row, and get the user information from the first row
                        var foundUser = new User();
                        foundUser.Id = reader.GetInt32(reader.GetOrdinal("UserId"));
                        foundUser.Email = reader.GetString(reader.GetOrdinal("Email"));
                        foundUser.Password = reader.GetString(reader.GetOrdinal("Password"));
                        //TODO: Forgot the first role!!!!
                        while (reader.Read())//Continue advancing the pointer untill the end, and save the Role information
                        {
                            Role foundRole = new Role();
                            foundRole.Title = reader.GetString(reader.GetOrdinal("Title"));
                            foundRole.Id = reader.GetInt32(reader.GetOrdinal("RoleId"));
                            foundUser.Roles.Add(foundRole);
                        }
                        return foundUser;
                    }
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
