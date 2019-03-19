using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_P04.TowerHanoi
{
    public class Program
    {
        private static Stack<int> source;
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();
        private static int numberOfDisks;
        private static int steps = 0;

        public static void Main(string[] args)
        {
            numberOfDisks = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());

            Print();
            MoveDisks(numberOfDisks, source, destination, spare);

        }

        private static void Print()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();

        }

        private static void MoveDisks(int disk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (disk == 1)
            {
                steps++;
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{steps}: Moved disk");
                Print();
            }
            else
            {
                MoveDisks(disk - 1, source, spare, destination);
                steps++;
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{steps}: Moved disk");
                Print();
                MoveDisks(disk - 1, spare, destination, source);
            }
        }
    }
}
