using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int digit1 = 1; digit1 <= 9; digit1++)
            {
                if (number % digit1 == 0)
                {
                    for (int digit2 = 1; digit2 <= 9; digit2++)
                    {
                        if (number % digit2 == 0)
                        {
                            for (int digit3 = 1; digit3 <= 9; digit3++)
                            {
                                if (number % digit3 == 0)
                                {
                                    for (int digit4 = 1; digit4 <= 9; digit4++)
                                    {
                                        if (number % digit4 == 0)
                                        {
                                            Console.Write($"{digit1}{digit2}{digit3}{digit4} ");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

        }
    }
}
