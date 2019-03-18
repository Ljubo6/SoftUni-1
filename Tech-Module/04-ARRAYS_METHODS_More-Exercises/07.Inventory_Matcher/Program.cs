using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Inventory_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine().Split(' ').ToArray();
            long[] quantity = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            double[] price = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            while (true)
            {
                string command = Console.ReadLine();
                if (command != "done")
                {
                    int indexRequested = Array.IndexOf(products, command);
                    Console.WriteLine($"{products[indexRequested]} costs: {price[indexRequested]}; Available quantity: {quantity[indexRequested]}");
                }
                else
                {
                    break;
                }

                
            }

        }
    }
}
