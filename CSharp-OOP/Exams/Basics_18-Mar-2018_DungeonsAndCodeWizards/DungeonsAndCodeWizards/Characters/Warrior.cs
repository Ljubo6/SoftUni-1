namespace DungeonsAndCodeWizards.Characters
{
    using DungeonsAndCodeWizards.Bags;
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Data;
    using System;

    public class Warrior : Character, IAttackable
    {
        private const int DefaultBaseHealth = 100;
        private const int DefaultBaseArmor = 50;
        private const double DefaultAbilityPoints = 40;

        public Warrior(string name, Faction faction)
            : base(name, health: 100, armor: 50, abilityPoints: 40, bag: new Satchel(), faction: faction)
        {
        }

        public void Attack(Character character)
        {
            this.CheckIfDead(this);
            this.CheckIfDead(character);
            if (this == character)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            else if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
