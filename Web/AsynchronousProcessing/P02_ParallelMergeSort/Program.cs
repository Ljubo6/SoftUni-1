using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace P02_ParallelMergeSort
{

    public class Program
    {
        public static int[] GenerateRandomArray(int to)
        {
            int[] unsortedArray = new int[to];

            var random = new Random();

            for (int i = 0; i < to; i++)
            {
                unsortedArray[i] = random.Next();
            }

            return unsortedArray;
        }

        public static async Task Main(string[] args)
        {
            var array = GenerateRandomArray(300_000);
            var sw = new Stopwatch();

            sw.Start();
            var result = await ParallelMergeSort<int>.Sort(array);
            sw.Stop();

            Console.WriteLine($"All good! Time elapsed: {sw.ElapsedMilliseconds}ms");
        }
    }
}
