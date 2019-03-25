using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        public Amethyst(ClarityLevel clarityLevel) : base(clarityLevel)
        {
        }

        public override int Strenght => 2 + (int)ClarityLevel;
        public override int Agility => 8 + (int)ClarityLevel;
        public override int Vitality => 4 + (int)ClarityLevel;
    }
}
