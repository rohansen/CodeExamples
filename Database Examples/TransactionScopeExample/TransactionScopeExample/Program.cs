using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionScopeExample.DbLayer;
using TransactionScopeExample.Models;

namespace TransactionScopeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DbQuiz dbq = new DbQuiz();
            var newQuiz = new Quiz { Title = "En tomats farve" };
            newQuiz.Answers.Add(new Answer { IsCorrectAnswer = false, Text = "Orange" });
            newQuiz.Answers.Add(new Answer { IsCorrectAnswer = false, Text = "Blå" });
            newQuiz.Answers.Add(new Answer { IsCorrectAnswer = true, Text = "Rød" });
            DbQuiz.Create(newQuiz);


        }
    }
}
