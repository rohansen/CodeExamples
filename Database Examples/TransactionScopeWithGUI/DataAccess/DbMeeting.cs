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
    public class DbMeeting : ICRUD<Meeting>, IDisposable
    {
        private string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlConnection connection;
        public DbMeeting()
        {
            connection = new SqlConnection(CONNECTION_STRING);
        }
        /// <summary>
        /// Create == book
        /// </summary>
        /// <param name="entity"></param>
        public void Create(Meeting entity)
        {
            //Debug through code, wait at the breakpoint below.. 
            //Go to management studio; try and insert a row in the RANGE of a allready existing booking.
            //
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.Serializable };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew,to))
            {
                connection.Open();
                //Check for available timeslot
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM Meeting WHERE BeginTime >= @newBeginTime AND EndTime <= @newEndTime AND ConsultantId=@consultantId";
                    cmd.Parameters.AddWithValue("@newBeginTime", entity.BeginTime);
                    cmd.Parameters.AddWithValue("@newEndTime", entity.EndTime);
                    cmd.Parameters.AddWithValue("@consultantId", entity.ConsultantId);
                    var rowsreturned = (int)cmd.ExecuteScalar();
                    if (rowsreturned > 0)
                    {
                        connection.Close();
                        throw new Exception("Your booking overlaps other bookings.");
                        
                    }
                }
                //Book
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Meeting] (BeginTime, EndTime,UserId, ConsultantId) VALUES (@beginTime,@endTime, @userId, @consultantId)";
                    cmd.Parameters.AddWithValue("@beginTime", entity.BeginTime);
                    cmd.Parameters.AddWithValue("@endTime", entity.EndTime);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId);
                    cmd.Parameters.AddWithValue("@consultantId", entity.ConsultantId);
                    cmd.ExecuteNonQuery();
                }
                scope.Complete();
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Meeting Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Meeting> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Meeting> GetAllConsultantMeetings(int consultantId)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
            List<Meeting> meetings;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Meeting WHERE ConsultantId=@id";
                    cmd.Parameters.AddWithValue("@id", consultantId);
                    var reader = cmd.ExecuteReader();

                    meetings = new List<Meeting>();
                    while (reader.Read())
                    {
                        Meeting meeting = new Meeting();

                        meeting.BeginTime = reader.GetDateTime(reader.GetOrdinal("BeginTime"));
                        meeting.EndTime = reader.GetDateTime(reader.GetOrdinal("EndTime"));
                        meeting.ConsultantId = reader.GetInt32(reader.GetOrdinal("ConsultantId"));
                        meeting.UserId = reader.GetInt32(reader.GetOrdinal("UserId"));
                        meetings.Add(meeting);
                    }
                }
                scope.Complete();
                connection.Close();
            }

            return meetings;
        }
        public IEnumerable<Meeting> GetAllConsultantMeetingsOnDate(int consultantId, DateTime beginDate)
        {
            var startTime = new DateTime(beginDate.Year, beginDate.Month, beginDate.Day, 0, 0, 0, 0);
            var endtime = new DateTime(beginDate.Year, beginDate.Month, beginDate.Day, 23, 59, 59, 999);


            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };
            List<Meeting> meetings;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Meeting WHERE ConsultantId=@id AND BeginTime BETWEEN @startdate AND @enddate";
                    cmd.Parameters.AddWithValue("@id", consultantId);
                    cmd.Parameters.AddWithValue("@startdate", startTime);
                    cmd.Parameters.AddWithValue("@enddate", endtime);
                    var reader = cmd.ExecuteReader();

                    meetings = new List<Meeting>();
                    while (reader.Read())
                    {
                        Meeting meeting = new Meeting();

                        meeting.BeginTime = reader.GetDateTime(reader.GetOrdinal("BeginTime"));
                        meeting.EndTime = reader.GetDateTime(reader.GetOrdinal("EndTime"));
                        meeting.ConsultantId = reader.GetInt32(reader.GetOrdinal("ConsultantId"));
                        meeting.UserId = reader.GetInt32(reader.GetOrdinal("UserId"));
                        meetings.Add(meeting);
                    }
                }
                scope.Complete();
                connection.Close();
            }

            return meetings;
        }

        public void Update(Meeting entity)
        {
            throw new NotImplementedException();
        }
    }
}
