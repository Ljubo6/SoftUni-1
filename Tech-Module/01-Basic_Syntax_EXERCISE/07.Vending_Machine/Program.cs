using System;

namespace _07.Vending_Machine
{
    class Program
    {
        static void PrintNoMoney()
        {
            Console.WriteLine("Sorry, not enough money");
        }

        static void Main()
        {
            string input = Console.ReadLine();
            decimal amountInserted = 0.0m;
            decimal totalAmount = 0.0m;
            

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

                if (purchase == "nuts")
                {
                    if (totalAmount < 2)
                    {
                        PrintNoMoney();
                    }
                    else
                    {
                        totalAmount -= 2;
                        Console.WriteLine($"Purchased {purchase}");
                    }
                }
                else if (purchase == "water")
                {
                    if (totalAmount < 0.7m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        totalAmount -= 0.7m;
                        Console.WriteLine($"Purchased {purchase}");
                    }
                }
                else if (purchase == "crisps")
                {
                    if (totalAmount < 1.5m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        totalAmount -= 1.5m;
                        Console.WriteLine($"Purchased {purchase}");
                    }
                }
                else if (purchase == "soda")
                {
                    if (totalAmount < 0.8m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        totalAmount -= 0.8m;
                        Console.WriteLine($"Purchased {purchase}");
                    }
                }
                else if (purchase == "coke")
                {
                    if (totalAmount < 1m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        totalAmount -= 1m;
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




static void MakePurchase()
{
    string purchase = Console.ReadLine();
    if (purchase == "Nuts")
    {
        Console.WriteLine("yes");
    }
    else
    {
        Console.WriteLine("no");
    }
}
