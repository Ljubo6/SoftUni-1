using System;

namespace _04.Rate
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double simpleRate = deposit * 3 / 100.0;
            double depositSimple = deposit + months * simpleRate;
                                    
            for (int i = 1; i <= months; i++)
            {
                deposit = deposit * 1.027;
            }

            double diff = Math.Abs(depositSimple - deposit);

            Console.WriteLine($"Simple interest rate: {depositSimple:f2} lv.");
            Console.WriteLine($"Complex interest rate: {deposit:f2} lv.");

            if (depositSimple > deposit)
            {
                Console.WriteLine($"Choose a simple interest rate. You will win {diff:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Choose a complex interest rate. You will win {diff:f2} lv.");
            }
        }
    }
}
