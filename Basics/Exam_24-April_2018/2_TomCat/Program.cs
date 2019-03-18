using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_TomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine());
            int workingDays = 365 - holidays;

            int minutesPlaying = holidays * 127 + workingDays * 63;
            int difference = Math.Abs(30000 - minutesPlaying);

            if (minutesPlaying <= 30000)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine((difference / 60) + " hours and " + (difference % 60) + " minutes less for play");
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine((difference / 60) + " hours and " + (difference % 60) + " minutes more for play");
            }
        }
    }
}
