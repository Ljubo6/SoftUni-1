using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

    public class ReversedList<T> : IEnumerable<T>
    {
        private T[] data;

        public ReversedList()
        {
            this.data = new T[2];
        }

        public void Add(T item)
        {
            if (this.Count >= this.data.Length - 1)
            {
                this.Resize();
            }

            this.data[this.Count++] = item;
        }

        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.data.ToArray()[this.Count - 1 - index];
            }

            set
            {
                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                this.data[index] = value;
            }
        }

        private void Resize()
        {
            T[] newArr = new T[this.data.Length * 2];
            Array.Copy(this.data, newArr, this.Count);
            this.data = newArr;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = this.Count - 1 - index; i < this.Count; i++)
            {
                this.data[i] = this.data[i + 1];
            }

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Capacity { get { return this.data.Length; } }
    }
