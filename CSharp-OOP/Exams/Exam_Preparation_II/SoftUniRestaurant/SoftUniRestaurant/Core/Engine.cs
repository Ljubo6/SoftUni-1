namespace SoftUniRestaurant.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private RestaurantController restaurantController;

        public Engine(RestaurantController restaurantController)
        {
            this.restaurantController = restaurantController;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    Console.WriteLine(restaurantController.GetSummary());
                    return;
                }

                var data = input.Split();
                var command = data[0];
                var args = data.Skip(1).ToArray();
                var output = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            string type = args[0];
                            string name = args[1];
                            decimal price = decimal.Parse(args[2]);
                            output = this.restaurantController.AddFood(type, name, price);
                            break;
                        case "AddDrink":
                            type = args[0];
                            name = args[1];
                            int servingSize = int.Parse(args[2]);
                            string brand = args[3];
                            output = this.restaurantController.AddDrink(type, name, servingSize, brand);
                            break;
                        case "AddTable":
                            type = args[0];
                            int tableNumber = int.Parse(args[1]);
                            int capacity = int.Parse(args[2]);
                            output = this.restaurantController.AddTable(type, tableNumber, capacity);
                            break;
                        case "ReserveTable":
                            int numberOfPeople = int.Parse(args[0]);
                            output = this.restaurantController.ReserveTable(numberOfPeople);
                            break;
                        case "OrderFood":
                            tableNumber = int.Parse(args[0]);
                            string foodName = args[1];
                            output = this.restaurantController.OrderFood(tableNumber, foodName);
                            break;
                        case "OrderDrink":
                            tableNumber = int.Parse(args[0]);
                            string drinkName = args[1];
                            string drinkBrand = args[2];
                            output = this.restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand);
                            break;
                        case "LeaveTable":
                            tableNumber = int.Parse(args[0]);
                            output = this.restaurantController.LeaveTable(tableNumber);
                            break;
                        case "GetFreeTablesInfo":
                            output = this.restaurantController.GetFreeTablesInfo();
                            break;
                        case "GetOccupiedTablesInfo":
                            output = this.restaurantController.GetOccupiedTablesInfo();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    output = ex.InnerException.Message;
                }


                Console.WriteLine(output);
            }
        }
    }
}
