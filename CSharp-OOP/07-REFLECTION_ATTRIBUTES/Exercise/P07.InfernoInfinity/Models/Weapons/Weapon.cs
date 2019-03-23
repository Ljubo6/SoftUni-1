using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P07.InfernoInfinity.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int socketsCount;

        public Weapon(RarityLevel rarityLevel, string name)
        {
            this.Name = name;
            this.RarityLevel = rarityLevel;
            this.Sockets = new IGem[socketsCount];
        }

        public int MinDamage
        {
            get => this.DefaultMinDamage * (int)RarityLevel + this.Sockets.Where(x => x != null).Sum(x => x.Strenght * 2 + x.Agility);
        }

        public int MaxDamage
        {
            get => this.DefaultMaxDamage * (int)RarityLevel + this.Sockets.Where(x => x != null).Sum(x => x.Strenght * 3 + x.Agility * 4);
        }

        public string Name { get; private set; }

        public IGem[] Sockets { get; set; }

        public RarityLevel RarityLevel { get; set; }

        protected abstract int DefaultMinDamage { get; }

        protected abstract int DefaultMaxDamage { get; }

        public void AddGem(int index, IGem gem)
        {
            if(index < this.Sockets.Length)
            {
                this.Sockets[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index < this.Sockets.Length)
            {
                this.Sockets[index] = null;
            }
        }

        protected virtual int CalculateDamage(int defaultMinDemage)
        {
            return defaultMinDemage * (int)RarityLevel;
        }
    }
}
