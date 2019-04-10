using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit.Models
{
    public class Footman : Soldier, ICharacter
    {
        public Footman(string name) : base(name)
        {
        }

        protected override void PrintOnConsole()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
