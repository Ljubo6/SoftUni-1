namespace DungeonsAndCodeWizards.Contracts
{
    using DungeonsAndCodeWizards.Characters;

    public interface IItem
    {
        int Weight { get; }
        void AffectCharacter(Character character);
    }
}
