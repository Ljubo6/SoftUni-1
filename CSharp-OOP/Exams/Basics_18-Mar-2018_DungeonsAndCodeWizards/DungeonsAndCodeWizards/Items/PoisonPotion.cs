using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards.Items
{
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
