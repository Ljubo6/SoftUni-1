using System;
using System.Collections.Generic;

namespace _07.Vending_Machine
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            decimal amountInserted = 0.0m;
            decimal totalAmount = 0.0m;

            Dictionary<string, decimal> ProductsPrices = new Dictionary<string, decimal>();
            ProductsPrices.Add("nuts", 2.0m);
            ProductsPrices.Add("water", 0.7m);
            ProductsPrices.Add("crisps", 1.5m);
            ProductsPrices.Add("soda", 0.8m);
            ProductsPrices.Add("coke", 1.0m);


            while (input != "Start")
            {
                bool isMoney = decimal.TryParse(input, out amountInserted);
                if (isMoney)
                {
                    if (amountInserted == 0.1m || amountInserted == 0.2m ||
                        amountInserted == 0.5m || amountInserted == 1.0m ||
                        amountInserted == 2.0m)
                    {
                        totalAmount += amountInserted;
                        input = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"Cannot accept {amountInserted}");
                        input = Console.ReadLine();
                    }
                }
            }

            while (true)
            {
                string purchase = Console.ReadLine().ToLower();

                if (ProductsPrices.ContainsKey(purchase))
                {
                    if (totalAmount < ProductsPrices[purchase])
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        totalAmount -= ProductsPrices[purchase];
                        Console.WriteLine($"Purchased {purchase}");
                    }
                }
                else if (purchase == "end")
                {
                    Console.WriteLine($"Change: {totalAmount:f2}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
        }
    }
}