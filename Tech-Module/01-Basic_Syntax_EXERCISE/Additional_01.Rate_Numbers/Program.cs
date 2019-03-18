using System;

namespace Additional_01.Rate_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inputNumbers = new double[3];

            for (int i = 0; i <= inputNumbers.Length - 1; i++)
            {
                inputNumbers[i] = double.Parse(Console.ReadLine());
            }

            Array.Sort(inputNumbers);
            Array.Reverse(inputNumbers);

            foreach (double number in inputNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
