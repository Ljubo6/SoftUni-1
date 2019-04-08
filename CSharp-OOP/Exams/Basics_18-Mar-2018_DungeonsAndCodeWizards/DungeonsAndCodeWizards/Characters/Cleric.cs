namespace DungeonsAndCodeWizards.Characters
{
    using DungeonsAndCodeWizards.Bags;
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Data;
    using System;

    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, health: 50, armor: 25, abilityPoints: 40, bag: new Backpack(), faction: faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.CheckIfDead(this);
            this.CheckIfDead(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
