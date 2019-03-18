using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_UmnataLili
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageLili = int.Parse(Console.ReadLine());
            double washingmachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            int toysNumber = 0;
            int moneySaved = 0;
            int moneyBirthday = 0;

            for (int i = 1; i <= ageLili; i++)
            {
                if (i % 2 == 0)
                {
                    moneyBirthday = moneyBirthday + 10;
                    moneySaved = moneySaved + moneyBirthday;
                    
                }
                else { toysNumber++; }
            }

            int totalMoney = (moneySaved - ageLili / 2) + toysNumber * toyPrice;
            double difference = Math.Abs(totalMoney - washingmachinePrice);

            if (totalMoney >= washingmachinePrice)
            {
                Console.WriteLine($"Yes! {difference:f2}");
            }
            else
            {
                Console.WriteLine($"No! {difference:f2}");
            }

        }
    }
}
