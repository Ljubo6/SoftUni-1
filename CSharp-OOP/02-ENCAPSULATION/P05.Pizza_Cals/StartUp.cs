using System;

public class StartUp
{
    public static void Main()
    {
        var pizza = new Pizza();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            string[] pizzaInfo = input.Split();

            if(pizzaInfo[0] == "Pizza")
            {
                try
                {
                    pizza.Name = pizzaInfo[1];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            else if (pizzaInfo[0] == "Dough")
            {
                var pizzaDough = new Dough();

                try
                {
                    pizzaDough.Type = pizzaInfo[1];
                    pizzaDough.BakingTechnique = pizzaInfo[2];
                    pizzaDough.Weight = int.Parse(pizzaInfo[3]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                pizza.Dough = pizzaDough;
            }
            else if (pizzaInfo[0] == "Topping")
            {
                var pizzaTopping = new Topping();
                try
                {
                    pizzaTopping.Type = pizzaInfo[1];
                    pizzaTopping.Weight = int.Parse(pizzaInfo[2]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                pizza.AddTopping(pizzaTopping);
            }
        }

        if (pizza.ToppingsCount() > 10)
        {
            Console.WriteLine("Number of toppings should be in range [0..10].");
            return;
        }

        Console.WriteLine(pizza);
    }
}

