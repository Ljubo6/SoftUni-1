using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get => this.healthPoints;
            set
            {
                this.healthPoints = Math.Max(0, value);
            }
        }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            var pointsToDecrease = this.AttackPoints - target.DefensePoints;
            target.HealthPoints -= pointsToDecrease;
            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            var info = new StringBuilder();
            info.AppendLine($"- {this.Name}");
            info.AppendLine($" *Type: {this.GetType().Name}");
            info.AppendLine($" *Health: {this.HealthPoints:f2}");
            info.AppendLine($" *Attack: {this.AttackPoints:f2}");
            info.AppendLine($" *Defense: {this.DefensePoints:f2}");

            var targetsList = this.Targets.Count > 0 ? string.Join(',', this.Targets) : "None"; 

            info.AppendLine($" *Targets: {targetsList}");

            return info.ToString().TrimEnd();
        }
    }
}
