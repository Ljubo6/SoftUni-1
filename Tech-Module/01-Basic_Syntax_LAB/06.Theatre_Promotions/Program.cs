using System;

namespace _07.Theatre_Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayType = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;

            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
                return;
            }
            else
            {
                switch (dayType)
                {
                    case "weekday":
                        if (age >=0 && age<=18)
                        {
                            ticketPrice = 12;
                        }
                        else if (age > 18 && age <= 64 )
                        {
                            ticketPrice = 18;
                        }
                        else
                        {
                            ticketPrice = 12;
                        }
                        break;
                    case "weekend":
                        if (age >= 0 && age <= 18)
                        {
                            ticketPrice = 15;
                        }
                        else if (age > 18 && age <= 64)
                        {
                            ticketPrice = 20;
                        }
                        else
                        {
                            ticketPrice = 15;
                        }
                        break;
                    case "holiday":
                        if (age >= 0 && age <= 18)
                        {
                            ticketPrice = 5;
                        }
                        else if (age > 18 && age <= 64)
                        {
                            ticketPrice = 12;
                        }
                        else
                        {
                            ticketPrice = 10;
                        }
                        break;
                }
            }
            Console.WriteLine($"{ticketPrice}$");
        }
    }
}
