namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;
    using DungeonsAndCodeWizards.Contracts;
    using System;

    public abstract class Item : IItem
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; private set; }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
