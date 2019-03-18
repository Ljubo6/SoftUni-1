using System;

namespace Additional_02.Last_Digits
{
    class Program
    {
        static void Main()
        {
            string[] digitsNames = new string[] {"zero", "one", "two", "three", "four",
                "five", "six", "seven", "eight", "nine" };
            int lastDigit = int.Parse(Console.ReadLine()) % 10;
            Console.WriteLine(digitsNames[lastDigit]);
        }
    }
}
