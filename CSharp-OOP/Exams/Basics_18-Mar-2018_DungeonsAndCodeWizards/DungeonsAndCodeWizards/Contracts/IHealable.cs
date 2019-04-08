namespace DungeonsAndCodeWizards.Contracts
{
    using DungeonsAndCodeWizards.Characters;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IHealable
    {
        void Heal(Character character);
    }
}
