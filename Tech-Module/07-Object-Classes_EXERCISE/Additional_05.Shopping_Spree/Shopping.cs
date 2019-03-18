using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_05.Shopping_Spree
{
    class Shopping
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] inputPersons = Console.ReadLine()
                .Split(new char[] { ';', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] inputProducts = Console.ReadLine()
                .Split(new char[] { ';', '=', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < inputPersons.Length; i+=2)
            {
                people.Add(new Person(inputPersons[i], decimal.Parse(inputPersons[i + 1])));
            }

            for (int i = 0; i < inputProducts.Length; i += 2)
            {
                products.Add(new Product(inputProducts[i], decimal.Parse(inputProducts[i + 1])));
            }

            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                string person = command[0];
                string product = command[1];

                Person currentBuyer = people[people.FindIndex(x => x.Name == person)];
                Product currentProduct = products[products.FindIndex(x => x.Name == product)];

                if (currentBuyer.Money >= currentProduct.Cost)
                {
                    currentBuyer.BagOfProducts.Add(product);
                    Console.WriteLine($"{currentBuyer.Name} bought {currentProduct.Name}");
                    currentBuyer.Money -= currentProduct.Cost;

                }
                else
                {
                    Console.WriteLine($"{currentBuyer.Name} can't afford {currentProduct.Name}");
                }
                command = Console.ReadLine().Split();
            }

            foreach (Person person in people)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<string>();
        }

        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<string> BagOfProducts { get; set; }
    }

    class Product
    {
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
