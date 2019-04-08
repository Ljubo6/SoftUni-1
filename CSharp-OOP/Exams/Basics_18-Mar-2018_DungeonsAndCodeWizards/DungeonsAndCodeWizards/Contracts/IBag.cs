using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IBag
    {
        int Capacity { get; }
        int Load { get; }
        IReadOnlyCollection<Item> Items { get; }

        void AddItem(Item item);
        Item GetItem(string name);
    }
}
