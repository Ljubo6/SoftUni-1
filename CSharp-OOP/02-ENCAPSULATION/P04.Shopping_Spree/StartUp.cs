using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var customers = new List<Person>();
        var products = new List<Product>();

        string[] inputCumstomers = Console.ReadLine()
            .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string[] inputProducts = Console.ReadLine()
            .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        for (int i = 0; i < inputCumstomers.Length; i += 2)
        {
            try
            {
                customers.Add(new Person(inputCumstomers[i], decimal.Parse(inputCumstomers[i + 1])));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        for (int i = 0; i < inputProducts.Length; i += 2)
        {
            try
            {
                products.Add(new Product(inputProducts[i], decimal.Parse(inputProducts[i + 1])));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        string[] command = Console.ReadLine().Split();
        while (command[0] != "END")
        {
            string person = command[0];
            string product = command[1];

            Person currentBuyer = customers[customers.FindIndex(x => x.Name == person)];
            Product currentProduct = products[products.FindIndex(x => x.Name == product)];

            if (currentBuyer.Money >= currentProduct.Cost)
            {
                currentBuyer.ShoppingBag.Add(currentProduct);
                Console.WriteLine($"{currentBuyer.Name} bought {currentProduct.Name}");
                currentBuyer.Money -= currentProduct.Cost;
            }
            else
            {
                Console.WriteLine($"{currentBuyer.Name} can't afford {currentProduct.Name}");
            }
            command = Console.ReadLine().Split();
        }

        foreach (Person person in customers)
        {
            if (person.ShoppingBag.Count > 0)
            {
                Console.WriteLine($"{person.Name} - {string.Join(", ", person.ShoppingBag.Select(x => x.Name))}");
            }
            else
            {
                Console.WriteLine($"{person.Name} - Nothing bought");
            }
        }
    }
}