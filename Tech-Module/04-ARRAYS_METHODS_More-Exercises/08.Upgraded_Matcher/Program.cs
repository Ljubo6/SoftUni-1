using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Upgraded_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine().Split(' ').ToArray();
            string quantityInput = Console.ReadLine();
            decimal[] price = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

             //quantity = new long[products.Length];
            long[] quantity = quantityInput.Split(' ').Select(long.Parse).ToArray();
            Array.Resize(ref quantity, products.Length);


            while (true)
            {
                string command = Console.ReadLine();
                if (command != "done")
                {
                    string[] nameQty = command.Split(' ').ToArray();
                    string orderProduct = nameQty[0];
                    long orderQty = Int64.Parse(nameQty[1]);

                    int indexRequested = Array.IndexOf(products, orderProduct);

                    if (quantity[indexRequested] >= orderQty)
                    {
                        Console.WriteLine($"{orderProduct} x {orderQty} costs {(orderQty * price[indexRequested]):f2}");
                        quantity[indexRequested] = quantity[indexRequested] - orderQty;
                    }
                    else 
                    {
                        Console.WriteLine($"We do not have enough {orderProduct}");
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
