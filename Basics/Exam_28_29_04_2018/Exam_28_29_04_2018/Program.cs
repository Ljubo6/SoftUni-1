using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_28_29_04_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            string sex = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double CardPrise = 0.00;
            double money = 0.00;

            if (sport == "Gym")
            {
                if (sex == "m") { CardPrise = 42; }
                else { CardPrise = 35; }
            }
            if (sport == "Boxing")
            {
                if (sex == "m") { CardPrise = 41; }
                else { CardPrise = 37; }
            }
            if (sport == "Yoga")
            {
                if (sex == "m") { CardPrise = 45; }
                else { CardPrise = 42; }
            }
            if (sport == "Zumba")
            {
                if (sex == "m") { CardPrise = 34; }
                else { CardPrise = 31; }
            }
            if (sport == "Dances")
            {
                if (sex == "m") { CardPrise = 51; }
                else { CardPrise = 53; }
            }
            if (sport == "Pilates")
            {
                if (sex == "m") { CardPrise = 39; }
                else { CardPrise = 37; }
            }
            if (age <= 19)
            {
                CardPrise = CardPrise * 0.8;
                if (sum >= CardPrise)
                {
                    Console.WriteLine($"You purchased a 1 month pass for {sport}.");
                }
                else
                {
                    money = CardPrise - sum;
                    Console.WriteLine($"You don't have enough money! You need ${money, 2} more.");

                }
            }
            else
            {
                if (sum >= CardPrise)
                {
                    Console.WriteLine($"You purchased a 1 month pass for {sport}.");
                }
                else
                {
                    money = CardPrise - sum;
                    Console.WriteLine($"You don't have enough money! You need ${money, 2} more.");
                }
            }
        }
    }
}
