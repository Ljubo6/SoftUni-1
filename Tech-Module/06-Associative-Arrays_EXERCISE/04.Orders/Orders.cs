using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            var quantity = new Dictionary<string, int>();
            var price = new Dictionary<string, double>();

            while (input[0] != "buy")
            {
                string product = input[0];
                double productPrice = double.Parse(input[1]);
                int productQuantity = int.Parse(input[2]);
                if (!quantity.ContainsKey(product))
                {
                    quantity.Add(product, productQuantity);
                    price.Add(product, productPrice);
                }
                else
                {
                    quantity[product] += productQuantity;
                    price[product] = productPrice;
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }

            foreach (var kvp in quantity)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value * price[kvp.Key]:f2}");
            }
        }
    }
}
