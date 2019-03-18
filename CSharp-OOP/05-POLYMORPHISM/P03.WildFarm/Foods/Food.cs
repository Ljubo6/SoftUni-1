using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Foods
{
    public abstract class Food : IFood
    {
        public int Quantity { get; protected set; }

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
