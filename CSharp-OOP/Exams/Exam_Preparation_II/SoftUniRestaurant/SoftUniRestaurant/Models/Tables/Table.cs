namespace SoftUniRestaurant.Models.Tables
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private IList<IFood> FoodOrders;
        private IList<IDrink> DrinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.FoodOrders = new List<IFood>();
            this.DrinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.numberOfPeople = 0;
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; } = false;

        public decimal Price => this.FoodOrders.Sum(f => f.Price) 
            + this.DrinkOrders.Sum(d => d.Price) 
            + this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.DrinkOrders.Clear();
            this.FoodOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.Price;
        }

        public string GetFreeTableInfo()
        {
            var info = new StringBuilder();
            info.AppendLine($"Table: {this.TableNumber}");
            info.AppendLine($"Type: {this.GetType().Name}");
            info.AppendLine($"Capacity: {this.Capacity}");
            info.AppendLine($"Price per Person: {this.PricePerPerson}");

            return info.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            var foodOrders = this.FoodOrders.Any() ? this.FoodOrders.Count.ToString() : "None";
            var drinkOrders = this.DrinkOrders.Any() ? this.DrinkOrders.Count.ToString() : "None";

            var info = new StringBuilder();
            info.AppendLine($"Table: {this.TableNumber}");
            info.AppendLine($"Type: {this.GetType().Name}");
            info.AppendLine($"Number of people: {this.NumberOfPeople}");
            info.AppendLine($"Food orders: {foodOrders}");

            foreach (var food in this.FoodOrders)
            {
                info.AppendLine(food.ToString());
            }

            info.AppendLine($"Drink orders: {drinkOrders}");

            foreach (var drink in this.DrinkOrders)
            {
                info.AppendLine(drink.ToString());
            }

            return info.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
