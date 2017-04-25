using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{
    #region//enums
    enum ConsumableType { Steak, Stew, Potato, Porridge, Grog, Wine, Ale, Tea, Coffee }
    enum WeaponType { Bow, Axe, Sword, Spear, Knife, Hammer, Mace }
    enum ArmorType { Shield, PaddedArmor, LeatherArmor, ChainMail, ScaleArmor, PlateArmor }
    enum BuffType { Health, Speed, Strength, None }
    enum RankType { Challenger, Champion }
    enum StatType { Strength, Speed, Defense}
    #endregion

    /// <summary>
    /// Holds initialized character objects
    /// </summary>
    static class GameCharacters
    {
        //Player
        public static Player player = new Player("No Name", PlayerType.Player);

        //Fighters
        public static NPC Duncan = new NPC("Duncan", PlayerType.Fighter);
        public static NPC Grayson = new NPC("Grayson", PlayerType.Fighter);
        public static NPC Saigo = new NPC("Saigo", PlayerType.Fighter);
        public static NPC SmilinDonnie = new NPC("Smilin' Donnie", PlayerType.Fighter);

        //Villagers
        public static NPC Paul = new NPC("Paul", "Bartender", PlayerType.Villager);
        public static NPC Nina = new NPC("Nina", "Peasant", PlayerType.Villager);
        public static NPC Miriam = new NPC("Miriam", "Innkeeper", PlayerType.Villager);
        public static NPC Bernard = new NPC("Bernard", "Merchant" , PlayerType.Villager);
        public static NPC Bancroft = new NPC("Bancroft", "Merchant", PlayerType.Villager);
        public static NPC Norm = new NPC("Norm", "Dealer", PlayerType.Villager);

    }

    /// <summary>
    /// Holds initialized Locations objects
    /// </summary>
    static class GameLocations
    {
        public static Tavern tavern = new Tavern("Bucky's Big Gulps");

    }

    /// <summary>
    /// Holds initialized Consumable objects
    /// </summary>
    static class GameConsumables
    {
        //Food
        public static Consumable Steak = new Consumable(ConsumableType.Steak, BuffType.Health, BuffType.None, 10, 0, 10);
        public static Consumable Stew = new Consumable(ConsumableType.Stew, BuffType.Health, BuffType.None, 4, 0, 5);
        public static Consumable Potato = new Consumable(ConsumableType.Potato, BuffType.Health, BuffType.None, 2, 0, 3);
        public static Consumable Porridge = new Consumable(ConsumableType.Porridge, BuffType.Health, BuffType.None, 1, 0, 2);

        //Alcohol
        public static Consumable Grog = new Consumable(ConsumableType.Grog, BuffType.Strength, BuffType.Speed, 3, -3, 6);
        public static Consumable Wine = new Consumable(ConsumableType.Wine, BuffType.Strength, BuffType.Speed, 1, -1, 2);
        public static Consumable Ale = new Consumable(ConsumableType.Ale, BuffType.Strength, BuffType.Speed, 2, -2, 4);

        //Beverage
        public static Consumable Tea = new Consumable(ConsumableType.Tea, BuffType.Speed, BuffType.None, 1, 0, 3);
        public static Consumable Coffee = new Consumable(ConsumableType.Coffee, BuffType.Speed, BuffType.None, 4, 0, 10);
    }

    /// <summary>
    /// Holds initialized Weapon objects
    /// </summary>
    static class GameWeapons
    {

    }

    static class BlackJackDeck
    {
        public static DeckOfCards deck = new DeckOfCards();
    }
}
