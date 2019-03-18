using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            int year = input[2];
            int month = input[1];
            int day = input[0];


            var date = new DateTime(year, month, day);

            Console.WriteLine(date.DayOfWeek);


        }
    }
}
