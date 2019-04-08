namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;

    public class HealthPotion : Item
    {
        private const int DefaultWeight = 5;
        private const int IncreasePoints = 20;

        public HealthPotion() : base(DefaultWeight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += IncreasePoints;
        }
    }
}
