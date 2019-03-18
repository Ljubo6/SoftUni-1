using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var production = new Dictionary<string, int>();

            while (true)
            {
                string resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }
                else
                {
                    int quantity = int.Parse(Console.ReadLine());
                    if (!production.ContainsKey(resource))
                    {
                        production.Add(resource, quantity);
                    }
                    else
                    {
                        production[resource] += quantity;
                    }
                }
            }

            foreach (var kvp in production)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
