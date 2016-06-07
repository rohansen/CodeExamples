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
    public class DbQuiz
    {

        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;


        //Returns the correct answerId
        public static int Create(Quiz quiz)
        {
            int correctAnswerId = -1;
            TransactionOptions options = new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted };//her kan i sætte isolation om nødvendigt
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                connection.Open();
                int quizId = InserQuizCommand(connection, quiz);
                foreach (var answer in quiz.Answers)
                {
                    answer.QuizId = quizId;
                    DbAnswer.InsertAnswerCommand(connection, answer);

                    if (answer.IsCorrectAnswer)
                        correctAnswerId = answer.AnswerId; //Den beskytter dog ikke imod at i har flere korrekte svar (kan ikke huske om det var muligt)
                }

                scope.Complete();
                connection.Dispose();
            }
            return correctAnswerId;

        }

        public static int InserQuizCommand(SqlConnection con, Quiz quiz)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Quiz (Title) OUTPUT Inserted.QuizId VALUES (@title)";
            cmd.Parameters.AddWithValue("title", quiz.Title);
            return (int)cmd.ExecuteScalar(); //returner det netop indsatte id

        }
        
    }
}
