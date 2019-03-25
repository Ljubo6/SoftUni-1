using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        public Ruby(ClarityLevel clarityLevel) 
            : base(clarityLevel)
        {
        }

        public override int Strenght => 7 + (int)ClarityLevel;
        public override int Agility => 2 + (int)ClarityLevel;
        public override int Vitality => 5 + (int)ClarityLevel;
    }
}
