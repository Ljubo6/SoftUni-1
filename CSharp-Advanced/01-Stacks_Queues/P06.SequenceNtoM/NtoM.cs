using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.SequenceNtoM
{
    public class NtoM
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int nInput = input[0];
            int mInput = input[1];
            
            Queue<QueueNode> queue = new Queue<QueueNode>();
            QueueNode n = new QueueNode(nInput, null);

            queue.Enqueue(n);

            while (queue.Count > 0)
            {
                QueueNode current = queue.Dequeue();

                if (current.Value == mInput)
                {
                    Print(current);
                    return;
                }
                else if (current.Value > mInput)
                {
                    continue;
                }

                queue.Enqueue(new QueueNode(current.Value + 1, current));
                queue.Enqueue(new QueueNode(current.Value + 2, current));
                queue.Enqueue(new QueueNode(current.Value * 2, current));
            }
        }

        private static void Print(QueueNode firstItem)
        {
            QueueNode current = firstItem;
            Stack<int> result = new Stack<int>();

            while (current != null)
            {
                result.Push(current.Value);
                current = current.Prev;
            }

            Console.WriteLine(string.Join(" -> ", result));
        }
    }

    public class QueueNode
    {
        public int Value { get; set; }
        public QueueNode Prev { get; set; }

        public QueueNode(int value, QueueNode prev)
        {
            this.Value = value;
            this.Prev = prev;
        }
    }
}
