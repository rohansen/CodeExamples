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
    public class DbConsultant : ICRUD<Consultant>
    {
        private string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlConnection connection;
        public DbConsultant()
        {
            connection = new SqlConnection(CONNECTION_STRING);
        }
        public void Create(Consultant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Consultant Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Consultant> GetAll()
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
            List<Consultant> consultants;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Consultant";
                    var reader = cmd.ExecuteReader();
                    scope.Complete();
                    consultants = new List<Consultant>();
                    while (reader.Read())
                    {
                        Consultant newConsultant = new Consultant();

                        newConsultant.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        newConsultant.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        newConsultant.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        consultants.Add(newConsultant);
                    }
                }
            }
            connection.Close();
            return consultants;
        }

        public void Update(Consultant entity)
        {
            throw new NotImplementedException();
        }
    }
}
