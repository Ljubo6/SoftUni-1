using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ASCII_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capitalsSum = 0;
            int smallSum = 0;
            int digitsSum = 0;
            int symbolsSum = 0;
            int largestSum = int.MinValue;
            string capitalsString = "";
            string smallString = "";
            string digitsString = "";
            string symbolsString = "";


            for (int i = 0; i < n; i++)
            {
                char command = char.Parse(Console.ReadLine());
                if (command >= 48 && command <=57)
                {
                    digitsSum = digitsSum + command;
                    digitsString = digitsString + "" + (char)command;
                }
                else if (command >= 65 && command <= 90)
                {
                    capitalsSum = capitalsSum + command;
                    capitalsString = capitalsString + "" + (char)command;
                }
                else if (command >= 97 && command <= 122)
                {
                    smallSum = smallSum + command;
                    smallString = smallString + "" + (char)command;
                }
                else
                {
                    symbolsSum = symbolsSum + command;
                    symbolsString = symbolsString + "" + (char)command;
                }
            }
            if (symbolsSum >= largestSum)
            {
                largestSum = symbolsSum;
            }
            if (smallSum >= largestSum)
            {
                largestSum = smallSum;
            }
            if (capitalsSum >= largestSum)
            {
                largestSum = capitalsSum;
            }
            if (digitsSum >= largestSum)
            {
                largestSum = digitsSum;
            }
            

            if (largestSum == capitalsSum)
            {
                Console.WriteLine($"Biggest ASCII sum is:{largestSum}");
                Console.WriteLine($"Combination of characters is:{capitalsString}");
            }
            else if (largestSum == smallSum)
            {
                Console.WriteLine($"Biggest ASCII sum is:{largestSum}");
                Console.WriteLine($"Combination of characters is:{smallString}");
            }
            if (largestSum == digitsSum)
            {
                Console.WriteLine($"Biggest ASCII sum is:{largestSum}");
                Console.WriteLine($"Combination of characters is:{digitsString}");
            }
            if (largestSum == symbolsSum)
            {
                Console.WriteLine($"Biggest ASCII sum is:{largestSum}");
                Console.WriteLine($"Combination of characters is:{symbolsString}");
            }
            
        }
    }
}
