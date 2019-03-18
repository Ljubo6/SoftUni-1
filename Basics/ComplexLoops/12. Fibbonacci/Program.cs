using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Fibbonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstNumber = 1;
            int secondNumber = 1;
            int newNumber = 0; 
            

            if (n < 2) { Console.WriteLine(1); }
            else
            {
                for (int i = 1; i < n; i++)
                {
                    newNumber = firstNumber + secondNumber;
                    firstNumber = secondNumber;
                    secondNumber = newNumber;
                    

                }
                Console.WriteLine(newNumber);
            }

        }
    }
}
