using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Jump_Around
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 7, 12, 2, 10 };
                //Console.ReadLine()
                //.Split(' ')
                //.Select(int.Parse)
                //.ToArray();

            int position = 0;
            int newPosition = 0;
            int sum = 0;
            int moves = 0;

            while (true)
            {
                if (position <= numbers.Length - 1)
                {
                    sum = sum + numbers[position];
                    moves = numbers[position];
                    newPosition = position + moves;
                    
                }
                else if (position >= numbers.Length - position)
                {
                    sum = sum + numbers[position - moves];
                    moves = numbers[numbers.Length - position - 1];
                    position = position - moves;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
