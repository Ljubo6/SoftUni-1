using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int[] command = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int bomb = command[0];
            int power = command[1];

            for (int index = 0; index < numbers.Count; index++)
            {
                if (bomb == numbers[index])
                {
                    int leftMinLen = Math.Min(index, power);
                    int rightMinLen = Math.Min(numbers.Count - 1 - index, power);

                    for (int next = index; next <= index + rightMinLen; next++)
                    {
                        numbers[next] = 0;
                    }
                    for (int prev = index - 1; prev >= index - leftMinLen; prev--)
                    {
                        numbers[prev] = 0;
                    }
                 
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}