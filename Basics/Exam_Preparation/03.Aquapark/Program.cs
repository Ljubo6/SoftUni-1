using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Aquapark
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            double hours = double.Parse(Console.ReadLine());
            int persons = int.Parse(Console.ReadLine());
            string daytime = Console.ReadLine().ToLower();
            double totalPrice = 0.00;
            double pricePerPerson = 0.00;

            if (month == "march" || month == "april" || month == "may")
            {
                switch (daytime)
                {
                    case "day":
                        pricePerPerson = 10.5;
                        totalPrice = persons * pricePerPerson;
                        if (persons >= 4)
                        {
                            pricePerPerson = pricePerPerson * 0.9;
                        }
                        if (hours >= 5)
                        {
                            pricePerPerson = pricePerPerson * 0.5;
                        }
                        break;
                    case "night":
                        pricePerPerson = 8.4;
                        if (persons >= 4)
                        {
                            pricePerPerson = pricePerPerson * 0.9;
                        }
                        if (hours >= 5)
                        {
                            pricePerPerson = pricePerPerson * 0.5;
                        }
                        break;
                }
                totalPrice = persons * pricePerPerson * hours;
            }

            if (month == "june" || month == "july" || month == "august")
            {
                switch (daytime)
                {
                    case "day":
                        pricePerPerson = 12.6;
                        totalPrice = persons * pricePerPerson;
                        if (persons >= 4)
                        {
                            pricePerPerson = pricePerPerson * 0.9;
                        }
                        if (hours >= 5)
                        {
                            pricePerPerson = pricePerPerson * 0.5;
                        }
                        break;
                    case "night":
                        pricePerPerson = 10.2;
                        if (persons >= 4)
                        {
                            pricePerPerson = pricePerPerson * 0.9;
                        }
                        if (hours >= 5)
                        {
                            pricePerPerson = pricePerPerson * 0.5;
                        }
                        break;
                }
                totalPrice = persons * pricePerPerson * hours;
            }
            Console.WriteLine($"Price per person for one hour: {pricePerPerson:f2}");
            Console.WriteLine($"Total cost of the visit: {totalPrice:f2}");
        }
    }
}

