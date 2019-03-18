using System;
using System.Globalization;

namespace _02.Coffee_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());
            string n = "01";
            int m = int.Parse(n);

            decimal totalPrice = 0.0m;

            for (int i = 0; i < ordersCount; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                int capsulesCount = int.Parse(Console.ReadLine());

                int daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                decimal pricePerMonth = (daysInMonth * capsulesCount) * pricePerCapsule;
                Console.WriteLine($"The price for the coffee is: ${pricePerMonth:f2}");
                totalPrice += pricePerMonth;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
