using RoomBooking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RoomBooking.DbLayer
{

    public class DbBooking : IDbCRUD<Booking>
    {

        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void Create(Booking entity)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew,to))
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    int amountOfBookings;
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Count(*) FROM Booking WHERE StartTime <= @startTime AND EndTime>=@endTime AND RoomId=@roomId";
                        cmd.Parameters.AddWithValue("roomId", entity.RoomId);
                        cmd.Parameters.AddWithValue("startTime", entity.StartTime);
                        cmd.Parameters.AddWithValue("endTime", entity.EndTime);
                        amountOfBookings = (int)cmd.ExecuteScalar();
                    }
                    if (amountOfBookings == 0)
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "INSERT INTO Booking (RoomId, UserId, StartTime,EndTime) VALUES(@roomId, @userId,@startTime,@endTime)";
                            cmd.Parameters.AddWithValue("roomId", entity.RoomId);
                            cmd.Parameters.AddWithValue("userId", entity.UserId);
                            cmd.Parameters.AddWithValue("startTime", entity.StartTime);
                            cmd.Parameters.AddWithValue("endTime", entity.EndTime);
                            cmd.ExecuteNonQuery();
                        }
                    }else
                    {
                        throw new FaultException<Exception>(new Exception("Der er allerede en booking"));
                    }
                }
                scope.Complete();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }



        public Booking Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Booking entity)
        {
            throw new NotImplementedException();
        }
    }
}
