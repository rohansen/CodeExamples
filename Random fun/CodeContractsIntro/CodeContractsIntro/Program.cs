using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
namespace CodeContractsIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            MathClass cl = new MathClass();
            Console.WriteLine(cl.SumOfDivisionWithPositiveDividend(new int[] {8,4},2));
        }
        
    }
    public class MathClass
    {
        private int sum = 0;
        
        public int SumOfDivisionWithPositiveDividend(int[] dividends, int divisor)
        {
            Contract.Requires(dividends.All(x=>x>0) && divisor > 0);
            int result = 0;
            for (int i = 0; i < dividends.Length; i++)
            {
                Contract.Invariant(sum <= 99);
                result+=dividends[i] / divisor;
            }
            return sum;
        }
    }
}
