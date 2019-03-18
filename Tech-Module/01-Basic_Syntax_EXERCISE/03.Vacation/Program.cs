using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            decimal totalPrice = 0.0m;
            decimal price = 0.0m;

            if (type == "Students")
            {
                switch (day)
                {
                    case "Friday":
                        price = 8.45m;
                        break;
                    case "Saturday":
                        price = 9.80m;
                        break;
                    case "Sunday":
                        price = 10.46m;
                        break;
                }
                totalPrice = numberOfPeople * price;
                if (numberOfPeople >= 30)
                {
                    totalPrice *= 0.85m;
                }
            }
            else if (type == "Business")
            {
                switch (day)
                {
                    case "Friday":
                        price = 10.90m;
                        break;
                    case "Saturday":
                        price = 15.60m;
                        break;
                    case "Sunday":
                        price = 16m;
                        break;
                }
                totalPrice = numberOfPeople * price;
                if (numberOfPeople >= 100)
                {
                    totalPrice = (numberOfPeople - 10) * price;
                }
            }
            else if (type == "Regular")
            {
                switch (day)
                {
                    case "Friday":
                        price = 15m;
                        break;
                    case "Saturday":
                        price = 20m;
                        break;
                    case "Sunday":
                        price = 22.50m;
                        break;
                }
                totalPrice = numberOfPeople * price;
                if (numberOfPeople >= 10 && numberOfPeople <= 20)
                {
                    totalPrice *= 0.95m;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
