using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200d;
        private const double AttackPointsAdjusment = 50d;
        private const double DefencePointsAdjusment = 25d;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.AggressiveMode = true;
            this.AdjustPointsToMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            this.AggressiveMode = !this.AggressiveMode;
            this.AdjustPointsToMode();
        }

        private void AdjustPointsToMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AttackPoints += AttackPointsAdjusment;
                this.DefensePoints -= DefencePointsAdjusment;
            }
            else
            {
                this.AttackPoints -= AttackPointsAdjusment;
                this.DefensePoints += DefencePointsAdjusment;
            }
        }

        public override string ToString()
        {
            var modeStatus = this.AggressiveMode ? "ON" : "OFF";

            var info = new StringBuilder();
            info.AppendLine(base.ToString());
            info.AppendLine($" *Aggressive: {modeStatus}");
            return info.ToString().TrimEnd();
        }
    }
}
