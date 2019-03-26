using P07.InfernoInfinity.Attributes;
using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;
using System.Linq;

namespace P07.InfernoInfinity.Models.Weapons
{
    [Class("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        private int socketsCount;
        private int defaultMinDamage;
        private int defaultMaxDamage;

        public Weapon(RarityLevel rarityLevel, string name, int defaultMinDamage, int defaultMaxDamage)
        {
            this.Name = name;
            this.RarityLevel = rarityLevel;
            this.Sockets = new IGem[socketsCount];
            this.defaultMinDamage = defaultMinDamage;
            this.defaultMaxDamage = defaultMaxDamage;
        }

        public int MinDamage
        {
            get => this.defaultMinDamage * (int)RarityLevel + this.Sockets.Where(x => x != null).Sum(x => x.Strenght * 2 + x.Agility);
        }

        public int MaxDamage
        {
            get => this.defaultMaxDamage * (int)RarityLevel + this.Sockets.Where(x => x != null).Sum(x => x.Strenght * 3 + x.Agility * 4);
        }

        public string Name { get; private set; }

        public IGem[] Sockets { get; set; }

        public RarityLevel RarityLevel { get; set; }

        public override string ToString()
        {
            var strengthPoints = this.Sockets.Where(x => x != null).Sum(x => x.Strenght);
            var agilityPoints = this.Sockets.Where(x => x != null).Sum(x => x.Agility);
            var vitalityPoints = this.Sockets.Where(x => x != null).Sum(x => x.Vitality);

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{strengthPoints} Strength, +{agilityPoints} Agility, +{vitalityPoints} Vitality";
        }
    }
}
