using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CellPhone
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int phoneQuantity = int.Parse(Console.ReadLine());
            string brand = Console.ReadLine();
            double price = 0.0;

            switch (brand)
            {
                case "Gsm4e":
                    price = 20.5 * 0.99;
                    if (phoneQuantity >= 10 && phoneQuantity <=20)
                    {
                        price = price * 0.98;
                    }
                    if (phoneQuantity >= 11 && phoneQuantity <= 50)
                    {
                        price = price * 0.95;
                    }
                    if (phoneQuantity >50)
                    {
                        price = price * 0.93;
                    }
                    break;
                case "Mobifon4e":
                    price = 50.75 * 0.98;
                    if (phoneQuantity >= 10 && phoneQuantity <= 20)
                    {
                        price = price * 0.98;
                    }
                    if (phoneQuantity >= 11 && phoneQuantity <= 50)
                    {
                        price = price * 0.95;
                    }
                    if (phoneQuantity > 50)
                    {
                        price = price * 0.93;
                    }
                    break;
                case "Telefon4e ":
                    price = 115 * 0.97;
                    if (phoneQuantity >= 10 && phoneQuantity <= 20)
                    {
                        price = price * 0.98;
                    }
                    if (phoneQuantity >= 11 && phoneQuantity <= 50)
                    {
                        price = price * 0.95;
                    }
                    if (phoneQuantity > 50)
                    {
                        price = price * 0.93;
                    }
                    break;
            }
            double totalSum = Math.Round((price * phoneQuantity),2);
            double difference = Math.Abs(totalSum - budget);
            if (totalSum <= budget)
            {
                Console.WriteLine($"The company bought all mobile phones. {difference} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money for all mobiles. Company needs {difference} more leva.");
            }
        }
    }
}
