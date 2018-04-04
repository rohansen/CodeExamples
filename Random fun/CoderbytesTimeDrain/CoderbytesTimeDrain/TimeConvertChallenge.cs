using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderbytesTimeDrain
{
    class TimeConvertChallenge
    {

        public static string TimeConvert(int num)
        {

            if (num >= 60)
            {
                int amountOfHours = num / 60;
                int amountOfMinutes = num - (amountOfHours * 60);
                return amountOfHours + ":" + amountOfMinutes;
            }
            else
            {
                return "0:" + num;
            }


        }

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(TimeConvert(int.Parse(Console.ReadLine())));


        }
    }
}
