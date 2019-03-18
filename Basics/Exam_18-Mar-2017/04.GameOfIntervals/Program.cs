using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double result = 0.0;
            int counter0to9 = 0;
            int counter10to19 = 0;
            int counter20to29 = 0;
            int counter30to39 = 0;
            int counter40to50 = 0;
            int countinvalid = 0;

           

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number >= 0 && number <= 9)
                {
                    result = result + number * 0.2;
                    counter0to9++;
                }
                if (number >= 10 && number <= 19)
                {
                    result = result + number * 0.3;
                    counter10to19++;
                }
                if (number >= 20 && number <= 29)
                {
                    result = result + number * 0.4;
                    counter20to29++;
                }
                if (number >= 30 && number <= 39)
                {
                    result = result + 50;
                    counter30to39++;
                }
                if (number >= 40 && number <= 50)
                {
                    result = result + 100;
                    counter40to50++;
                }
                if (number < 0 || number > 50)
                {
                    result = result / 2;
                    countinvalid++;
                }
            }

            double percetange0to9 = counter0to9 * 100.0 / n;
            double percetange10to19 = counter10to19  * 100.0 / n;
            double percetange20to29 = counter20to29  * 100.0 / n;
            double percetange30to39 = counter30to39  * 100.0 / n;
            double percetange40to50 = counter40to50  * 100.0 / n;
            double percentageinvalid = countinvalid  * 100.0 / n;

            Console.WriteLine($"{result:f2}");
            Console.WriteLine($"From 0 to 9: {percetange0to9:f2}%");
            Console.WriteLine($"From 10 to 19: {percetange10to19:f2}%");
            Console.WriteLine($"From 20 to 29: {percetange20to29:f2}%");
            Console.WriteLine($"From 30 to 39: {percetange30to39:f2}%");
            Console.WriteLine($"From 40 to 50: {percetange40to50:f2}%");
            Console.WriteLine($"Invalid numbers: {percentageinvalid:f2}%");
        }
    }
}
