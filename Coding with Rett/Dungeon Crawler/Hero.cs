using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public enum WeaponType {Axe, Sword, Bow, Pike, Staff};
    public enum PotionType { Damage, Health, Speed };

    //Used for Player and enemies
    class Hero
    {
        //instance variables
        #region
        int health;
        int speed; //helps determine who goes first in a battle
        int attack;
        String name;
        Random rand = new Random();
        List<Item> inventory = new List<Item>();
        int inventoryCount = 0;
        #endregion

        //constructors
        #region
        /// <summary>
        /// Hero Constructor
        /// </summary>
        /// <param name="health"></param>
        /// <param name="speed"></param>
        /// <param name="attack"></param>
        /// <param name="name"></param>
        /// 
        public Hero(int health, int speed, int attack, String name)
        {
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.name = name;
        }

        public Hero(int health, int speed, int attack, String name, List<Item> inventory)
        {
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.name = name;
            this.inventory = inventory;
        }
        #endregion

        //access modifiers (getters and setter)
        #region
        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }

        public int Attack
        {
            get
            {
                return this.attack;
            }
            set
            {
                this.attack = value;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }
        #endregion

        //functions
        #region
        /// <summary>
        /// Call on attacking hero, pass in Enemy hero to give damage to them
        /// </summary>
        /// <param name="Enemy"></param>
        public int inflictDamage(Hero Enemy)
        {

            float hitChance = (rand.Next(0, 11)) / 10f;

            if(hitChance > 0.1)
            {
                int attackModifier = rand.Next(0, attack + 1);
                Enemy.health -= attackModifier;
                if(Enemy.health < 0)
                {
                    Enemy.health = 0;
                }
                return attackModifier;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// prints the inventory of the Player hero
        /// </summary>
        public void printInventory()
        {
            if(this.inventory.Count == 0)
            {
                Console.WriteLine(this.name + " inventory is empty\n");
            }
            else
            {
                Console.WriteLine("Items in " + this.name + "'s Inventory");

                foreach (Item item in this.inventory)
                {
                    printItem(item);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print a specific item in the Hero's inventory
        /// </summary>
        /// <param name="item"></param>
        public void printItem(Item item)
        {
            Console.WriteLine("\tItem Name: " + item.Name);
            if (item.GetType() == typeof(Potion))
            {
                Console.WriteLine("\tPotion Type: " + item.PotionType);
            }
            if (item.GetType() == typeof(Weapon))
            {
                Console.WriteLine("\tWeapon Type: " + item.WeaponType);
            }
            if (item.GetType() == typeof(Potion))
            {
                Console.WriteLine("\tPotion Size: " + item.Size + "\n");
            }
            if (item.GetType() == typeof(Weapon))
            {
                Console.WriteLine("\tDamage: " + item.Damage + "\n");
            }
        } 

        /// <summary>
        /// Add item to inventory
        /// </summary>
        /// <param name="item"></param>
        public void addItemToInvetory(Item item)
        {
            if(inventoryCount >= 5)
            {
                Console.WriteLine("Inventory is full.");
            }
            else
            {
                this.inventory.Add(item);
                inventoryCount++;
            }
        }

        /// <summary>
        /// Remove item from inventory
        /// </summary>
        /// <param name="item"></param>
        public void removeItemFromInventory(Item item)
        {
            if(this.inventory.Count > 0)
            {
                this.inventory.RemoveAt(this.inventory.IndexOf(item));
            }

        }

        /// <summary>
        /// Sets health of Hero to 0
        /// </summary>
        public void killHero()
        {
            this.health = 0;
            if(this.inventory.Count > 0)
            {
                int index = rand.Next(0, this.inventory.Count);
                Item item = this.inventory[index];

                Console.WriteLine(this.name + " dropped: ");
                printItem(item);
            }

            //Don't forget to figure out how to pass item to player/prompt if they want to pick up item
        }
        #endregion
    }

    //item classes
    #region
    //base class
    abstract class Item
    {
        protected string name;
        protected WeaponType weaponType; //used for weapon
        protected PotionType potionType; //used for potion
        protected int damage; //used for weapon
        protected int size; //used for potion

        public Item (string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public WeaponType WeaponType
        {
            get
            {
                return this.weaponType;
            }
        }

        public PotionType PotionType
        {
            get
            {
                return this.potionType;
            }
        }

        //only used for weapon
        public int Damage
        {
            get
            {
                return this.damage;
            }
        }
        //only used for potion
        public int Size
        {
            get
            {
                return this.size;
            }
        }
    }

    class Weapon : Item
    {

        /// <summary>
        /// Weapon Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="damage"></param>
        public Weapon(string name, WeaponType type, int damage) : base (name)
        {
            this.name = name;
            this.weaponType = type;
            this.damage = damage;
        }

    }

    class Potion : Item
    {
        /// <summary>
        /// Potion Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="size"></param>
        public Potion(string name, PotionType type, int size) : base(name)
        {
            this.name = name;
            this.potionType = type;
            this.size = size;
        }

    }
    #endregion
}
