using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Pizza
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine()
                .Split(' ')
                .ToArray();
            int length = int.Parse(Console.ReadLine());

            string[] result = new string[10];
            int counter = 0;

            for (int i = 0; i < ingredients.Length; i++)
            {
                char[] ingredient = ingredients[i].ToCharArray();
                if (ingredient.Length == length)
                {
                    result[i] = ingredients[i];
                    counter++;
                    Console.WriteLine($"Adding {ingredients[i]}.");
                }
                if (counter == 10)
                {
                    break;
                }
            }

            string[] selectedOnly = (string.Join(" ", result))
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Console.WriteLine($"Made pizza with total of {counter} ingredients.");
            Console.Write("The ingredients are: ");
            for (int i = 0; i < selectedOnly.Length - 1; i++)
            {
                Console.Write(selectedOnly[i] + ", ");
            }
            Console.WriteLine($"{selectedOnly[selectedOnly.Length -1]}.");


        }
    }
}
