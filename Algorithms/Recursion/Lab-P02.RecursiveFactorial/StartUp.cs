using System;

namespace Lab_P02.RecursiveFactorial
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            long factorial = Factorial(number);
            Console.WriteLine(factorial);
        }

        private static long Factorial(int number)
        {
            if(number == 1)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}
