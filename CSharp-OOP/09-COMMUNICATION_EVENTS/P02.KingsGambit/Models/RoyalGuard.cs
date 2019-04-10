using P02.KingsGambit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit.Models
{
    public class RoyalGuard : Soldier, ICharacter
    {
        public RoyalGuard(string name) 
            : base(name)
        {
        }

        protected override void PrintOnConsole()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
