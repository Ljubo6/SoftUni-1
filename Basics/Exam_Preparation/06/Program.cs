using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            //char stopLetter = char.Parse(Console.ReadLine());

            for (int i = firstLetter; i <= secondLetter; i++)
            {
                for (int a = firstLetter; a <= secondLetter; a++)
                {
                    for (int b = firstLetter; b <= secondLetter; b++)
                    {
                        Console.Write(firstLetter);
                        firstLetter++;
                    }
                    Console.Write(firstLetter);
                }
                Console.Write(firstLetter);
            }
            Console.WriteLine();
            
        }
    }
}
