using System;
using System.Collections.Generic;
using System.Text;
using P05.Mordor.Foods;

namespace P05.Mordor.FoodFactorying
{
    public class FoodFactory
    {
        public Food CreteFood(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "apple":
                    return new Apple();
                case "cram":
                    return new Cram();
                case "honeycake":
                    return new HoneyCake();
                case "lembas":
                    return new Lembas();
                case "melon":
                    return new Melon();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return new Else();
                    break;
            }
        }
    }
}
