
using RoomBooking.DbLayer.Interfaces;
using RoomBooking.Exceptions;
using RoomBooking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RoomBooking.DbLayer.DB.ADO
{

    public class DbBooking : IDbCRUD<Booking>
    {
        //Gets the connection string called "DefaultConnection" from the startup projects App.config
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void Create(Booking entity)
        {
            //Set the options for the transaction scope to serializable, such that double bookings cannot occur
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.Serializable };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, to))
            {
                //Open connction using the connectionstring mentioned earlier
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    //amount of bookings is used to check how many bookings exist at the currently selected time
                    //(hopefully 0)
                    int amountOfBookings;
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Count(*) FROM Booking WHERE StartTime <= @startTime AND EndTime>=@endTime AND RoomId=@roomId";
                        cmd.Parameters.AddWithValue("roomId", entity.RoomId);
                        cmd.Parameters.AddWithValue("startTime", entity.StartTime);
                        cmd.Parameters.AddWithValue("endTime", entity.EndTime);
                        amountOfBookings = (int)cmd.ExecuteScalar();
                    }
                    if (amountOfBookings == 0)//There exists no bookings at the selected time, so we can go ahead and book
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
                    }
                    else
                    {
                        //A booking existed in the selected time period
                        //We log this event (logging is setup in the startup projects app.config, under the element <Diagnostics>)
                        Trace.TraceInformation($"User {entity.UserId} tried to book something that was already booked");
                        Trace.Flush();
                        //and we throw a FaultException(WCF Specific)
                        //The <T> (type) of FaultException we throw, is one we have implemented ourselves (BookingExistsException).
                        //You can find this exception in the projet RoomBooking.Exceptions
                        throw new FaultException<BookingExistsException>(new BookingExistsException("Booking exists at that time"));
                    }
                }
                scope.Complete();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Booking WHERE Id=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }

            }
        }



        public Booking Get(int id)
        {
            Booking booking = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Booking WHERE Id=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        booking = new Booking
                        {
                            Id = (int)reader["id"],
                            RoomId = (int)reader["roomId"],
                            UserId = (int)reader["userId"],
                            StartTime = (DateTime)reader["startTime"],
                            EndTime = (DateTime)reader["endTime"]

                        };
                    }
                }

            }
            return booking;
        }
        public bool Login(string username, string password)
        {
            bool isUserValidated = false;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * Users WHERE username=@username AND password=@password";
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);
                    var reader = cmd.ExecuteReader();

                    if(reader.HasRows)
                    {
                        //If the reader has a row, a match must have been found
                        isUserValidated = true;
                    }
                }

            }
            return isUserValidated;
        }


        public IEnumerable<Booking> GetAll()
        {
            List<Booking> bookings = new List<Booking>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Booking";
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Booking b = new Booking
                        {
                            Id = (int)reader["id"],
                            RoomId = (int)reader["roomId"],
                            UserId = (int)reader["userId"],
                            StartTime = (DateTime)reader["startTime"],
                            EndTime = (DateTime)reader["endTime"]

                        };
                        bookings.Add(b);
                    }
                }

            }
            return bookings;
        }

        public void Update(Booking entity)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Booking SET UserId=@uid, RoomId=@rid, StartTime=@st, EndTime=@et WHERE ID=@id";
                    cmd.Parameters.AddWithValue("rid", entity.RoomId);
                    cmd.Parameters.AddWithValue("uid", entity.UserId);
                    cmd.Parameters.AddWithValue("st", entity.StartTime);
                    cmd.Parameters.AddWithValue("et", entity.EndTime);
                    cmd.Parameters.AddWithValue("id", entity.Id);
                    cmd.ExecuteNonQuery();

                }

            }
        }
    }
}
