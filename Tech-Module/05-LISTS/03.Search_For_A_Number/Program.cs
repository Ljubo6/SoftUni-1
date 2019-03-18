using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Search_For_A_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int[] manipulation = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            for (int i = manipulation[0]; i <= numbers.Count - 1; i++)
            {
                numbers.RemoveAt(i);
            }

            for (int i = 0; i < manipulation[1]; i++)
            {
                numbers.RemoveAt(0);
            }

            bool isPresent = numbers.Contains(manipulation[2]);

            if (isPresent == true)
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
