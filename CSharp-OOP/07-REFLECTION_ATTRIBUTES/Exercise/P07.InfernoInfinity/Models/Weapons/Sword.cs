using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        private const int socketsCount = 3;
        private const int defaultMinDamage = 4;
        private const int defaultMaxDamage = 6;

        public Sword(RarityLevel rarityLevel, string name) 
            : base(rarityLevel, name, defaultMinDamage, defaultMaxDamage)
        {
            this.Sockets = new IGem[socketsCount];
        }
    }
}
