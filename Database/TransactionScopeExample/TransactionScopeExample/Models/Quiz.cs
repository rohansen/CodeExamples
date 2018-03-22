using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionScopeExample.Models
{
    public class Quiz
    {
        public Quiz()
        {
            Answers = new List<Answer>();
        }
        public int QuizId { get; set; }
        public string Title { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
