using CarBookingLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarBookingLogic.DAL
{
    public class DbBooking
    {
        private SqlConnection con = null;
        private const string connectionString = @"data source=localhost;initial catalog=CarBooking;integrated security=True;MultipleActiveResultSets=True;";
        public DbBooking()
        {
            
            
        }


        public void InsertBooking(int unitId, int customerId, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                //ReadCommitted is standard --> using repeatable read, to ensure that the data wont change during the booking transaction
                SqlTransaction transaction = con.BeginTransaction(System.Data.IsolationLevel.ReadCommitted,"CreateBooking");
                SqlCommand insertCmd = con.CreateCommand();
                SqlCommand updateCmd = con.CreateCommand();
                insertCmd.Transaction = transaction;
                updateCmd.Transaction = transaction;
                

                try
                {
                    
                    updateCmd.CommandText = "UPDATE Unit SET IsBooked = @ib WHERE UnitId = @ui";
                    updateCmd.Parameters.AddWithValue("ib", true);
                    updateCmd.Parameters.AddWithValue("ui", unitId);
                    updateCmd.ExecuteNonQuery(); 
                    Thread.Sleep(5000);
                    
                    insertCmd.CommandText = "INSERT !INTO Booking(StartDate, EndDate, CustomerId, UnitId) VALUES (@sd,@ed,@ci,@ui)";
                    insertCmd.Parameters.AddWithValue("sd", startDate);
                    insertCmd.Parameters.AddWithValue("ed", endDate);
                    insertCmd.Parameters.AddWithValue("ci", customerId);
                    insertCmd.Parameters.AddWithValue("ui", unitId);
                    insertCmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    //Transaction Failed
                    try
                    {   
                        transaction.Rollback();
                    }
                    catch (Exception)
                    {
                        //Rollback failed
                    }
                   
                }
                
            }
        }

        public List<Unit> GetAllUnits(bool includeBookedUnits)
        {
            var unitList = new List<Unit>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Unit WITH(READUNCOMMITTED) WHERE isBooked = @ib";
                cmd.Parameters.AddWithValue("ib", includeBookedUnits);
                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var unit = new Unit();
                    unit.UnitId = (int)reader["UnitId"];
                    unit.Description = reader["Description"] as string;
                    unit.Price = (decimal)reader["Price"];
                    unit.Name = reader["Name"] as string;
                    unit.IsBooked = reader["isBooked"] is DBNull ? false : (bool)reader["isBooked"];
                    unitList.Add(unit);
                }
            }
            return unitList;
            
        }
    }
}
