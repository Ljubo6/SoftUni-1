namespace DungeonsAndCodeWizards.Contracts
{
    using DungeonsAndCodeWizards.Items;
    using System.Collections.Generic;

    public interface IBag
    {
        int Capacity { get; }
        int Load { get; }
        IReadOnlyCollection<Item> Items { get; }

        void AddItem(Item item);
        Item GetItem(string name);
    }
}
