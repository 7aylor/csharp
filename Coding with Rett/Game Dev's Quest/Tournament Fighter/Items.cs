using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{
    enum ConsumableType { Steak, Stew, Potato, Porridge, Grog, Wine, Ale, Tea, Coffee }
    enum WeaponType { Bow, Axe, Sword, Spear, Knife, Hammer, Mace }
    enum ArmorType { Shield, PaddedArmor, LeatherArmor, ChainMail, ScaleArmor, PlateArmor }
    
    class Consumable
    {
        ConsumableType name;
        int buff;
        int debuff;
        int cost;

        public Consumable(ConsumableType name, int buff, int debuff, int cost)
        {
            this.name = name;
            this.buff = buff;
            this.debuff = debuff;
            this.cost = cost;
        }

        ConsumableType Name
        {
            get
            {
                return this.name;
            }
        }

        int Buff
        {
            get
            {
                return this.buff;
            }
        }

        int Debuff
        {
            get
            {
                return this.debuff;
            }
        }

        int Cost
        {
            get
            {
                return this.cost;
            }
        }
    }

    class Weapon
    {
        string name;
        WeaponType type;
        int damage;

        public Weapon(string name, WeaponType type, int damage)
        {
            this.name = name;
            this.type = type;
            this.damage = damage;
        }

        string Name
        {
            get
            {
                return this.name;
            }
        }

        WeaponType Type
        {
            get
            {
                return this.type;
            }
        }

        int Damage
        {
            get
            {
                return this.damage;
            }
        }
    }

    class Armor
    {
        string name;
        ArmorType type;
        int defense;

        public Armor(string name, ArmorType type, int defense)
        {
            this.name = name;
            this.type = type;
            this.defense = defense;
        }

        string Name
        {
            get
            {
                return this.name;
            }
        }

        ArmorType Type
        {
            get
            {
                return this.type;
            }
        }

        int Defense
        {
            get
            {
                return this.defense;
            }
        }

    }

}
