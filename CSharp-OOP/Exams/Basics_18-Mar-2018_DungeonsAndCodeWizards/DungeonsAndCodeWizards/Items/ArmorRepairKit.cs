namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;

    public class ArmorRepairKit : Item
    {
        private const int DefaultWeight = 10;

        public ArmorRepairKit() : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
    }
}
