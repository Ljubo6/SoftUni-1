using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100d;
        private const double AttackPointsAdjusment = 40d;
        private const double DefencePointsAdjusment = 30d;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;
            this.AdjustPointsToMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
            this.AdjustPointsToMode();
        }

        public override string ToString()
        {
            var modeStatus = this.DefenseMode ? "ON" : "OFF";

            var info = new StringBuilder();
            info.AppendLine(base.ToString());
            info.AppendLine($" *Defense: {modeStatus}");
            return info.ToString().TrimEnd();
        }

        private void AdjustPointsToMode()
        {
            if (this.DefenseMode == true)
            {
                this.AttackPoints -= AttackPointsAdjusment;
                this.DefensePoints += DefencePointsAdjusment;
            }
            else
            {
                this.AttackPoints += AttackPointsAdjusment;
                this.DefensePoints -= DefencePointsAdjusment;
            }
        }
    }
}
