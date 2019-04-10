using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit.Models
{
    public abstract class Soldier
    {
        protected Soldier(string name)
        {
            this.Name = name;
            this.IsAlive = true;
        }

        public string Name { get; private set; }

        private bool IsAlive { get; set; }

        public void Kill()
        {
            this.IsAlive = false;
        }

        public void ReactToKingAttack(object sender, EventArgs args)
        {
            if (IsAlive)
            {
                this.PrintOnConsole();
            }
        }

        protected abstract void PrintOnConsole();
    }
}
