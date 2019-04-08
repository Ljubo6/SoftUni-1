using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Data;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private List<Character> characters;
        private Stack<Item> items;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();

            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var factionString = args[0];
            var characterTypeString = args[1];
            var name = args[2];

            if (!Enum.TryParse(factionString, out Faction faction))
            {
                throw new ArgumentException($"Invalid faction \"{factionString}\"");
            }

            var newCharacter = characterFactory.Create(characterTypeString, name, faction);
            this.characters.Add(newCharacter);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            var newItem = itemFactory.Create(itemName);
            this.items.Push(newItem);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = this.GetCharacter(characterName);

            if (!items.Any())
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var pickedItem = this.items.Pop();
            character.ReceiveItem(pickedItem);

            return $"{characterName} picked up {pickedItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = GetCharacter(characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.GetCharacter(giverName);
            var receiver = this.GetCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.GetCharacter(giverName);
            var receiver = this.GetCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);
            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var statsInfo = new StringBuilder();

            foreach (var character in characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                statsInfo.AppendLine(character.ToString());
            }

            return statsInfo.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = this.GetCharacter(attackerName);
            var receiver = this.GetCharacter(receiverName);

            if (!(attacker is Warrior))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            ((Warrior)attacker).Attack(receiver);

            var outputSb = new StringBuilder();
            outputSb.Append($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points!");
            outputSb.AppendLine($" {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                outputSb.AppendLine($"{receiver.Name} is dead!");
            }

            return outputSb.ToString().TrimEnd();

        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = this.GetCharacter(healerName);
            var receiver = this.GetCharacter(healingReceiverName);

            if (!(healer is Cleric))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            ((Cleric)healer).Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            var sb = new StringBuilder();

            foreach (var character in this.characters)
            {
                var healthBeforeRest = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if(this.characters.Where(c => c.IsAlive).Count() <= 1)
            {
                this.lastSurvivorRounds++;
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            return this.characters.Where(c => c.IsAlive).Count() <= 1 && this.lastSurvivorRounds > 1;
        }

        private Character GetCharacter(string characterName)
        {
            var character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}
