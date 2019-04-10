using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit.Models
{
    public class King : ICharacter
    {
        public event EventHandler KingUnderAttack;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void GetAttacked()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            KingUnderAttack?.Invoke(this, EventArgs.Empty);
        }

    }
}
