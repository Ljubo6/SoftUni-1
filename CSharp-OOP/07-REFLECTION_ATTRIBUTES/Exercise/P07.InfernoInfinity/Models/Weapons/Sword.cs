using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        private const int socketsCount = 3;

        public Sword(RarityLevel rarityLevel, string name) : base(rarityLevel, name)
        {
            this.Sockets = new IGem[socketsCount];
        }

        protected override int DefaultMinDamage => 4;
        protected override int DefaultMaxDamage => 6;
    }
}
