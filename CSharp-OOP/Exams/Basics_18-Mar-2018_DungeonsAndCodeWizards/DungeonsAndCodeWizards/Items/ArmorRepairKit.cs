using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards.Items
{
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
