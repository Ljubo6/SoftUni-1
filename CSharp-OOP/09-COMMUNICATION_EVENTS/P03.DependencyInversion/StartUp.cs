using System;

namespace P03.DependencyInversion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var calc = new PrimitiveCalculator();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if(input[0] == "End")
                {
                    return;
                }

                if(input[0] == "mode")
                {
                    calc.ChangeStrategy(input[1][0]);
                }
                else
                {
                    var firstOperand = int.Parse(input[0]);
                    var secondOperand = int.Parse(input[1]);
                    var result = calc.PerformCalculation(firstOperand, secondOperand);
                    Console.WriteLine(result);
                }

            }
        }
    }
}
