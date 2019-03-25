using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        public Gem(ClarityLevel clarityLevel)
        {
            this.ClarityLevel = clarityLevel;
        }

        public abstract int Strenght { get; }
        public abstract int Agility { get; }
        public abstract int Vitality { get; }
        public ClarityLevel ClarityLevel { get; private set; }
    }
}
