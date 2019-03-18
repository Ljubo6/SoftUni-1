using System;
using System.Text;

namespace P07.CustomTuple
{
    public class CustomTuple<T1, T2>
    {
        public T1 ItemOne { get; set; }
        public T2 ItemTwo { get; set; }

        public CustomTuple()
        {

        }

        public CustomTuple(T1 item1, T2 item2)
        {
            this.ItemOne = item1;
            this.ItemTwo = item2;
        }

        public override string ToString()
        {
            return $"{this.ItemOne} -> {this.ItemTwo}";
        }
    }
}
