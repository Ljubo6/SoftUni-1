using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards.Items
{
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
