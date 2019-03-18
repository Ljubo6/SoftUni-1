using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Multiply_Big_Number
{
    class BigNumber
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine().TrimStart('0');
            int small = int.Parse(Console.ReadLine().Trim());
            int remainder = 0;
            List<string> result = new List<string>();

            if (small == 0 || number == string.Empty)

            {
                Console.WriteLine(0);
                return;
            }

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int lastDigit = int.Parse(number[i].ToString());
                int current = lastDigit * small + remainder;
                result.Insert(0, (current % 10).ToString());
                remainder = current / 10;
            }

            if (remainder > 0)
            {
                result.Insert(0, remainder.ToString());
            }
            
            Console.WriteLine(string.Join("", result));
        }
    }
}
