using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        public Emerald(ClarityLevel clarityLevel) : base(clarityLevel)
        {
        }

        public override int Strenght => 1 + (int)ClarityLevel;
        public override int Agility => 4 + (int)ClarityLevel;
        public override int Vitality => 9 + (int)ClarityLevel;
    }
}
