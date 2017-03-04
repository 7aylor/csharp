﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{
    #region//enums
    enum ConsumableType { Steak, Stew, Potato, Porridge, Grog, Wine, Ale, Tea, Coffee }
    enum WeaponType { Bow, Axe, Sword, Spear, Knife, Hammer, Mace }
    enum ArmorType { Shield, PaddedArmor, LeatherArmor, ChainMail, ScaleArmor, PlateArmor }
    enum BuffType { Health, Speed, Strength, None }
    enum RankType { Challenger, Champion, }
    #endregion

    static class GameCharacters
    {
        //Player
        //public static Player player = new Player("No Name", 100, 5, 7, 10, 1, )

        //Fighters
        public static NPC Duncan = new NPC("Duncan", PlayerType.Fighter);
        public static NPC Grayson = new NPC("Grayson", PlayerType.Fighter);
        public static NPC Saigo = new NPC("Saigo", PlayerType.Fighter);

        //Villagers
        public static NPC Paul = new NPC("Paul", "Bartender", PlayerType.Villager);
        public static NPC Nina = new NPC("Nina", "Peasant", PlayerType.Villager);
        public static NPC Miriam = new NPC("Miriam", "Innkeeper", PlayerType.Villager);
        public static NPC Bernard = new NPC("Bernard", "Merchant" , PlayerType.Villager);
        public static NPC Bancroft = new NPC("Bancroft", "Merchant", PlayerType.Villager);

    }

    static class GameLocations
    {
        public static Tavern tavern = new Tavern("Bucky's Big Gulps");

    }

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

    static class GameWeapons
    {

    }
}
