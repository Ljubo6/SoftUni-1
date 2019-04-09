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
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.pricePerPerson = pricePerPerson;
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public int TableNumber { get; }

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

        private int NumberOfPeople
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

        public bool IsReserved { get; private set; }

        public decimal Price => this.foodOrders.Sum(f => f.Price) 
            + this.drinkOrders.Sum(d => d.Price) 
            + this.numberOfPeople * this.pricePerPerson;

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
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
            info.AppendLine($"Capacity: {this.capacity}");
            info.AppendLine($"Price per Person: {this.pricePerPerson:f2}");

            return info.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            var foodOrders = this.foodOrders.Any() ? this.foodOrders.Count.ToString() : "None";
            var drinkOrders = this.drinkOrders.Any() ? this.drinkOrders.Count.ToString() : "None";

            var info = new StringBuilder();
            info.AppendLine($"Table: {this.TableNumber}");
            info.AppendLine($"Type: {this.GetType().Name}");
            info.AppendLine($"Number of people: {this.numberOfPeople}");
            info.AppendLine($"Food orders: {foodOrders}");

            foreach (var food in this.foodOrders)
            {
                info.AppendLine(food.ToString());
            }

            info.AppendLine($"Drink orders: {drinkOrders}");

            foreach (var drink in this.drinkOrders)
            {
                info.AppendLine(drink.ToString());
            }

            return info.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
