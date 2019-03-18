using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> data;

        public MyStack()
        {
            this.data = new List<T>();
        }

        public void Push(T[] input)
        {
            if (input.Length > 1)
            {
                for (int i = 1; i < input.Length; i++)
                {
                    this.data.Add(input[i]);
                }
            }
        }
        public T Pop()
        {
            if (this.data.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            T element = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
