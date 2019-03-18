using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int index = 0;

        public ListyIterator()
        {
            this.data = new List<T>();
        }

        public void Create(IEnumerable<T> collection)
        {
            this.data = collection.ToList();
        }

        public bool Move()
        { 
            if (this.HasNext())
            {
                this.index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            return this.index + 1 < data.Count;
        }

        public string Print()
        {
            if (this.data.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

           return this.data[index].ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
