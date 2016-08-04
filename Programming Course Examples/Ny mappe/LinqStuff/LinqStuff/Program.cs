using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> func = (a, b) => { return (a * a) + (b * b); };


            var agg = Enumerable.Range(1,300).Select(x=>x.ToString()).Aggregate((accumulated,next)=>accumulated + ", " + next);
            Console.WriteLine(func(2, 2));
            Console.WriteLine("Aggregate\n" + agg);

        }
    }
}
