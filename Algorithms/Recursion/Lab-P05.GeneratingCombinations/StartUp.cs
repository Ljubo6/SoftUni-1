using System;
using System.Linq;

namespace Lab_P05.GeneratingCombinations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var set = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());
            var vector = new int[number];

            GenerateCombination(set, vector, 0, 0);
        }

        private static void GenerateCombination(int[] set, int[] vector, int index, int border)
        {
            if(index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenerateCombination(set, vector, index + 1, i + 1);
                }
            } 
        }
    }
}
