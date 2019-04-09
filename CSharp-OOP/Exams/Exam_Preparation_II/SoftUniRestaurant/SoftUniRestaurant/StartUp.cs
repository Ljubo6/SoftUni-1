namespace SoftUniRestaurant
{
    using SoftUniRestaurant.Core;

    public class StartUp
    {
        public static void Main()
        {
            RestaurantController restaurantController = new RestaurantController();
            var engine = new Engine(restaurantController);
            engine.Run();
        }
    }
}
