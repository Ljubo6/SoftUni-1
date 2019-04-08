namespace DungeonsAndCodeWizards.Contracts
{
    public interface IDungeonMaster
    {
        string JoinParty(string[] args);
        string AddItemToPool(string[] args);
        string PickUpItem(string[] args);
        string UseItem(string[] args);
        string UseItemOn(string[] args);
        string GiveCharacterItem(string[] args);
        string GetStats();
        string Attack(string[] args);
        string Heal(string[] args);
        string EndTurn(string[] args);
        bool IsGameOver();
    }
}
