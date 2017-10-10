using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystem
{
    public class DbUser
    {
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public void Register(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    var salt = HashingHelper.GenerateSalt();
                    string saltedHash = HashingHelper.HashPassword(password, salt);
                    string sql = "INSERT INTO Users (Email, PasswordHash, Salt) VALUES (@email,@pwhash, @salt)";
                    cmd.Parameters.AddWithValue("email", username);
                    cmd.Parameters.AddWithValue("pwhash", saltedHash);
                    cmd.Parameters.AddWithValue("salt", salt);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public bool Login(string username, string password)
        {
            bool isLoggedIn = false;
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //I made Email unique
                    string sql = "SELECT * FROM Users WHERE Email=@email";
                    cmd.Parameters.AddWithValue("email", username);

                    cmd.CommandText = sql;
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string currentSalt = rdr.GetString(rdr.GetOrdinal("Salt"));
                        string currentSaltedHash = rdr.GetString(rdr.GetOrdinal("PasswordHash"));
                        if (HashingHelper.CheckPassword(password, currentSalt, currentSaltedHash))
                        {
                            isLoggedIn = true;
                        }
                    }
                }
            }
            return isLoggedIn;
        }
    }
}
