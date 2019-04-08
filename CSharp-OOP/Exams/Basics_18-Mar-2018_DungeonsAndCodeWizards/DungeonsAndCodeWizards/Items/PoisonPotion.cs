namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;

    public class PoisonPotion : Item
    {
        private const int DefaultWeight = 5;
        private const int DecreasePoints = 20;

        public PoisonPotion() : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= DecreasePoints;
        }
    }
}
