using DatabasesSimpleADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesSimpleADO.DB
{
    public class DbAccess
    {
        public List<Person> FindItem(string searchString)
        {
            var foundPersons = new List<Person>();
            using (
                var con =
                    new SqlConnection(@"Server=localhost;Database=SIMPLE_ADO;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true;"))
            {
                using (
                    var cmd =
                        new SqlCommand("SELECT * FROM Person WHERE FirstName LIKE '%" + searchString + "%' OR LastName LIKE '%" + searchString + "%'", con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                Person newPerson = BuildPerson(reader);
                                foundPersons.Add(newPerson);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            finally
                            {
                            }
                        }
                    }
                }
            }
            return foundPersons;
        }

        private Person BuildPerson(SqlDataReader reader)
        {

            Person person = new Person();
            try
            {
                if (!reader.IsDBNull(1) && !reader.IsDBNull(2))
                {
                    
                    person.FirstName = reader.GetString(1);
                    person.LastName = reader.GetString(2);
                }
                else
                {
                    person.FirstName = "First Name Not Found";
                    person.LastName = "Last Name Not Found";
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error In BuildPerson(...): " + e.Message);
            }


            return person;
        }
    }
}
