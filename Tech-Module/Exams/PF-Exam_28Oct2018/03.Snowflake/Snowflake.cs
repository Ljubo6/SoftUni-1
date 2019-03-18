using System;
using System.Text.RegularExpressions;

namespace _03.Snowflake
{
    class Snowflake
    {
        static void Main(string[] args)
        {
            string topSurface = Console.ReadLine();
            string topMantle = Console.ReadLine();
            string middlePart = Console.ReadLine();
            string bottomMantle = Console.ReadLine();
            string bottomSurface = Console.ReadLine();

            string snowflake = topSurface + "\n" + topMantle + "\n" + middlePart + "\n" + bottomMantle + "\n" + bottomSurface;

           
            string pattern = @"([^A-Za-z0-9]*)\n(([0-9]*_*)*)\n(([^A-Za-z0-9]*))*([0-9]*_*)*(?<core>[A-Za-z]*)([0-9]*_*)";

            Match match = Regex.Match(snowflake, pattern);

            if (match.Success)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(match.Groups["core"].Length);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
