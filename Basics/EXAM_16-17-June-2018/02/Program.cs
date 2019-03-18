using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            double sleeve = double.Parse(Console.ReadLine());
            double front = double.Parse(Console.ReadLine());
            string cloth = Console.ReadLine().ToLower();
            string tie = Console.ReadLine().ToLower();

            double pricePerSqM = 0.0;

            double totalSize = ((sleeve + front) * 2) * 1.1 / 100;

            if (cloth == "linen")
            {
                pricePerSqM = 15;
            }
            else if (cloth == "cotton")
            {
                pricePerSqM = 12;
            }
            else if (cloth == "denim")
            {
                pricePerSqM = 20;
            }
            else if (cloth == "twill")
            {
                pricePerSqM = 16;
            }
            else if (cloth == "flannel")
            {
                pricePerSqM = 11;
            }

            double shirtPrice = totalSize * pricePerSqM + 10 ;

            if (tie == "yes")
            {
                shirtPrice = shirtPrice * 1.2;
            }

            Console.WriteLine($"The price of the shirt is: {shirtPrice:f2}lv.");
        }
    }
}
