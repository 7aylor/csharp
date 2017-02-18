using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    //Used for Player and enemies
    class Hero
    {
        //instance variables
        #region
        //int strength;
        //int intelligence;
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
            //this.strength = strength;
            //this.intelligence = intelligence;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.name = name;
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
                Console.WriteLine("Your inventory is empty\n");
            }
            else
            {
                Console.WriteLine("Items in Inventory");

                
                foreach (Item item in this.inventory)
                {
                    Console.WriteLine("\tItem: " + item.Name);
                    Console.WriteLine("\tType: " + item.Type);

                    
                    if(item.GetType() == typeof(Potion))
                    {
                        Console.WriteLine("\tPotion Size: " + item.Size + "\n");
                    }
                    if(item.GetType() == typeof(Weapon))
                    {
                        Console.WriteLine("\tDamange: " + item.Damage + "\n");
                    }
                    
                }
                Console.WriteLine();
            }
        }

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
        #endregion
    }

    //item classes
    #region
    //base class
    abstract class Item
    {
        protected string name;
        protected string type;
        protected int damage; //used for weapon
        protected int size; //used for potion

        public Item (string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
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
        public Weapon(string name, string type, int damage) : base (name, type)
        {
            this.name = name;
            this.type = type;
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
        public Potion(string name, string type, int size) : base(name, type)
        {
            this.name = name;
            this.type = type;
            this.size = size;
        }

    }
    #endregion
}
