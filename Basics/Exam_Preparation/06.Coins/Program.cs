using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            change = change * 100.00;

            int coins2Leva = 0;
            int coins1Leva = 0;
            int coins50st = 0;
            int coins20st = 0;
            int coins10st = 0;
            int coins5st = 0;
            int coins2st = 0;
            int coins1st = 0;

            while (change > 0)
            {
                coins2Leva = (int)(change / 200);
                change = change % 200;
                coins1Leva = (int)(change / 100);
                change = change % 100;
                coins50st = (int)(change / 50);
                change = change % 50;
                coins20st = (int)(change / 20);
                change = change % 20;
                coins10st = (int)(change / 10);
                change = change % 10;
                coins5st = (int)(change / 5);
                change = change % 5;
                coins2st = (int)(change / 2);
                change = change % 2;
                coins1st = (int)(change / 1);
                change = change % 1;
                int allCoins = coins2Leva + coins1Leva  + coins50st + coins20st + coins10st + coins5st + coins2st + coins1st;
                Console.WriteLine(allCoins);
                break;
                
            }
        }
    }
}
