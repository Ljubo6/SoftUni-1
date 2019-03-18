using System;
using System.Collections.Generic;
using System.Text;

namespace P08.Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        public T1 ItemOne { get; set; }
        public T2 ItemTwo { get; set; }
        public T3 ItemThree { get; set; }

        public Threeuple()
        {

        }

        public Threeuple(T1 item1, T2 item2, T3 item3)
        {
            this.ItemOne = item1;
            this.ItemTwo = item2;
            this.ItemThree = item3;
        }

        public override string ToString()
        {
            return $"{this.ItemOne} -> {this.ItemTwo} -> {this.ItemThree}";
        }
    }
}
