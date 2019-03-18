using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int DNAlenght = int.Parse(Console.ReadLine());
            int startingLetter = char.Parse(Console.ReadLine());
            
            
            for (int i = 1; i <= DNAlenght; i++)
            {
                Console.Write(".", ((7 - i) / 2));
            }
        }
    }
}
