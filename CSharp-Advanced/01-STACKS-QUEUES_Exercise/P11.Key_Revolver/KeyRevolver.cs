using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.Key_Revolver
{
    public class KeyRevolver
    {
        public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());
            int shots = 0;

            Stack<int> bullets = new Stack<int>(bulletsArray);
            Queue<int> locks = new Queue<int>(locksArray);


            while (bullets.Any() && locks.Any())
            {
                if (locks.Peek() >= bullets.Pop()) //lock is shot
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else // lock is not shot but bullet is lost
                {
                    Console.WriteLine("Ping!");
                }

                shots++;

                if (shots == gunBarrelSize && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    shots = 0;
                }
            }

            if (!locks.Any())
            {
                int earned = intelligence - (bulletsArray.Length - bullets.Count) * bulletPrice;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
