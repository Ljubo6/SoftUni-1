namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;

        private decimal totalIncome;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            var foodType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            var newFood = (IFood)Activator.CreateInstance(foodType, new object[] { name, price });
            this.menu.Add(newFood);

            return $"Added {name} ({newFood.GetType().Name}) with price {newFood.Price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var drinkType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            var newDrink = (IDrink)Activator.CreateInstance(drinkType, new object[] { name, servingSize, brand });
            this.drinks.Add(newDrink);

            return $"Added {name} ({brand}) to the drink pool";

        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var tableType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type+"Table");

            var newTable = (ITable)Activator.CreateInstance(tableType, new object[] { tableNumber, capacity });
            this.tables.Add(newTable);

            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(t => t.Capacity >= numberOfPeople && t.IsReserved == false);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = GetTableByNumber(tableNumber);

            if(table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var food = this.menu.FirstOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = GetTableByNumber(tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.GetTableByNumber(tableNumber);
            var output = $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {table.GetBill():f2}";
            this.totalIncome += table.GetBill();
            table.Clear();
            return output;
        }

        public string GetFreeTablesInfo()
        {
            var freeTablesInfo = new StringBuilder();

            foreach (var table in this.tables.Where(t => !t.IsReserved))
            {
                freeTablesInfo.AppendLine(table.GetFreeTableInfo());
            }

            return freeTablesInfo.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var occupiedTablesInfo = new StringBuilder();

            foreach (var table in this.tables.Where(t => t.IsReserved))
            {
                occupiedTablesInfo.AppendLine(table.GetOccupiedTableInfo());
            }

            return occupiedTablesInfo.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        private ITable GetTableByNumber(int tableNumber)
        {
            return this.tables.FirstOrDefault(t => t.TableNumber >= tableNumber);
        }
    }
}
