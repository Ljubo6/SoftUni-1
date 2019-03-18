using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_OperaciiChisla
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            string symbolOperator = Console.ReadLine();
            double result = 0.0;

            if (symbolOperator == "+")
            {
                result = number1 + number2;
                Console.Write($"{number1} {symbolOperator} {number2} = {result} - ");
                if (result % 2 == 0)
                { Console.WriteLine("even"); }
                else { Console.WriteLine("odd"); }
            }

            if (symbolOperator == "-")
            {
                result = number1 - number2;
                Console.Write($"{number1} {symbolOperator} {number2} = {result} - ");
                if (result % 2 == 0)
                { Console.WriteLine("even"); }
                else { Console.WriteLine("odd"); }
            }

            if (symbolOperator == "*")
            {
                result = number1 * number2;
                Console.Write($"{number1} {symbolOperator} {number2} = {result} - ");
                if (result % 2 == 0)
                { Console.WriteLine("even"); }
                else { Console.WriteLine("odd"); }
            }

            if (symbolOperator == "/")
            {
                if (number2 == 0)
                { Console.WriteLine($"Cannot divide {number1} by zero"); }
                else
                {
                    result = number1 / number2;
                    Console.WriteLine($"{number1} {symbolOperator} {number2} = {result:f2}");
                }
            }

            if (symbolOperator == "%")
            {
                if (number2 == 0)
                { Console.WriteLine($"Cannot divide {number1} by zero"); }
                else
                {
                    result = number1 % number2;
                    Console.Write($"{number1} {symbolOperator} {number2} = {result}");
                }
            }          

        }
    }
}
