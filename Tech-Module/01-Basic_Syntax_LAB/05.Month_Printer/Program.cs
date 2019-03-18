using System;

namespace _05.Month_Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                                "November", "December"};

            int monthIndex = int.Parse(Console.ReadLine());

            if (monthIndex >=1 && monthIndex <=12)
            {
                Console.WriteLine(month[monthIndex-1]);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
