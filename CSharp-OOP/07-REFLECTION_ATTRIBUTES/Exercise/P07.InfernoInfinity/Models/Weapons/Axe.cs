using System;
using System.Collections.Generic;
using System.Text;
using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        protected const int socketsCount = 4;

        public Axe(RarityLevel rarityLevel, string name) 
            : base(rarityLevel, name)
        {
            this.Sockets = new IGem[socketsCount];
        }

        protected override int DefaultMinDamage => 5;
        protected override int DefaultMaxDamage => 10;
    }
}
