using System;
using System.Collections.Generic;

namespace P08.StackFibonacci
{
    class Fibonacci
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<long> fibonacci = new Stack<long>();
            fibonacci.Push(0L);
            fibonacci.Push(1L);


            for (int i = 0; i < count-1; i++)
            {
                long last = fibonacci.Pop();
                long prev = fibonacci.Peek();
                fibonacci.Push(last);
                fibonacci.Push(last + prev);
            }

            Console.WriteLine(fibonacci.Peek());
        }
    }
}
