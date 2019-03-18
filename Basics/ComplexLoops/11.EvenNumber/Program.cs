using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter even number:");
                int number = 0;
                bool isInt = int.TryParse(Console.ReadLine(), out number);

                if (isInt)
                {
                    if (number % 2 == 0)
                    {
                        Console.WriteLine($"Even number entered: {number}");
                        break;

                    }
                    Console.WriteLine("The number is not even.");
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }
    }
}
