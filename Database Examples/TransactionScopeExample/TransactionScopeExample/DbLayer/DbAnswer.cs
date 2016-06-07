using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TransactionScopeExample.Models;

namespace TransactionScopeExample.DbLayer
{
    public class DbAnswer
    {
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public static void Create(Answer answer)
        {
            TransactionOptions options = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };//her kan i sætte isolation om nødvendigt
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                connection.Open();
                int answerId = InsertAnswerCommand(connection, answer);
                scope.Complete();
                connection.Dispose();
            }
        }

        public static int InsertAnswerCommand(SqlConnection con, Answer answer)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Answer (Text, IsCorrectAnswer,QuizId) OUTPUT Inserted.AnswerId VALUES (@text, @isCorrectAnswer,@quizId) ";
            cmd.Parameters.AddWithValue("text", answer.Text);
            cmd.Parameters.AddWithValue("isCorrectAnswer", answer.IsCorrectAnswer);
            cmd.Parameters.AddWithValue("quizId", answer.QuizId);
            return (int)cmd.ExecuteScalar(); //returner det netop indsatte id

        }

    }
}
