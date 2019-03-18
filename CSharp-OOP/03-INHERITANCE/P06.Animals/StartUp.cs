using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        while (true)
        {
            string type = Console.ReadLine();

            if (type == "Beast!")
            {
                break;
            }

            string[] info = Console.ReadLine().Split();

            try
            {
                type = type.ToLower();

                if (type == "cat")
                {
                    var cat = new Cat(info[0], int.Parse(info[1]), info[2]);
                    animals.Add(cat);
                }
                else if (type == "dog")
                {
                    var dog = new Dog(info[0], int.Parse(info[1]), info[2]);
                    animals.Add(dog);
                }
                else if (type == "frog")
                {
                    var frog = new Frog(info[0], int.Parse(info[1]), info[2]);
                    animals.Add(frog);
                }
                else if (type == "tomcat")
                {
                    var tomcat = new Tomcat(info[0], int.Parse(info[1]));
                    animals.Add(tomcat);
                }
                else if (type == "kitten")
                {
                    var kitten = new Kittens(info[0], int.Parse(info[1]));
                    animals.Add(kitten);
                }
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}
