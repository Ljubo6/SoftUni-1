using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Data;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Characters
{
    public abstract class Character : ICharacter
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.IsAlive = true;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => this.health;
            set
            {
                this.health = Math.Min(value, this.BaseHealth);
                if (this.health <= 0)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => this.armor;
            set
            {
                this.armor = Math.Min(value, this.BaseArmor);
                if (this.armor < 0)
                {
                    this.armor = 0;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; private set; }

        public virtual double RestHealMultiplier => 0.2;

        public void GiveCharacterItem(Item item, Character character)
        {
            this.CheckIfDead(this);
            this.CheckIfDead(character);
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.CheckIfDead(this);
            this.Bag.AddItem(item);
        }

        public void Rest()
        {
            this.CheckIfDead(this);
            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void TakeDamage(double hitPoints)
        {
            this.CheckIfDead(this);
            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
                return;
            }
            else if (this.Armor > 0)
            {
                var healthDecreasePoints = hitPoints - this.Armor;
                this.Armor = 0;
                this.Health -= healthDecreasePoints;
                return;
            }
            else
            {
                this.Health -= hitPoints;
            }

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.CheckIfDead(this);
            this.CheckIfDead(character);
            item.AffectCharacter(character);
        }

        public override string ToString()
        {
            var status = this.IsAlive ? "Alive" : "Dead";
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }

        protected void CheckIfDead(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
