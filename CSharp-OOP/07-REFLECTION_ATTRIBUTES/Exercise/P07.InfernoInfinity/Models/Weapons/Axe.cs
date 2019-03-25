using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int socketsCount = 4;
        private const int defaultMinDamage = 5;
        private const int defaultMaxDamage = 10;

        public Axe(RarityLevel rarityLevel, string name) 
            : base(rarityLevel, name, defaultMinDamage, defaultMaxDamage)
        {
            this.Sockets = new IGem[socketsCount];
        }
    }
}
