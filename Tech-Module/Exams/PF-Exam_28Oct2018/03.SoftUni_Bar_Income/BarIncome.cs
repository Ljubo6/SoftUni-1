using System;
using System.Text.RegularExpressions;

namespace _03.SoftUni_Bar_Income
{
    class BarIncome
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalCost = 0;

            while (input != "end of shift")
            {
                string namePattern = @"(?<=%)[A-Z][a-z]+(?=%)";
                string productPattern = @"(?<=\<)\w+(?=\>)";
                string quantityPattern = @"(?<=\|)\d+(?=\|)";
                string pricePattern = @"\d+\.?\d+(?=\$)";

                Match name = Regex.Match(input, namePattern);
                Match product = Regex.Match(input, productPattern);
                Match quantity = Regex.Match(input, quantityPattern);
                Match price = Regex.Match(input, pricePattern);


                if (name.Success && product.Success && quantity.Success && price.Success)
                {
                    double totalPrice = double.Parse(price.ToString()) * int.Parse(quantity.ToString());
                    totalCost += totalPrice;
                    Console.WriteLine($"{name.ToString()}: {product.ToString()} - {totalPrice:f2}");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalCost:f2}");
        }
    }
}
