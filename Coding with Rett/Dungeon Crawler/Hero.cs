using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
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
        /// Constructor
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
        /// 
        /// </summary>
        /// <param name="enemy"></param>
        public int inflictDamage(Hero enemy)
        {

            float hitChance = (rand.Next(0, 11)) / 10f;

            if(hitChance > 0.1)
            {
                int attackModifier = rand.Next(0, attack + 1);
                enemy.health -= attackModifier;
                if(enemy.health < 0)
                {
                    enemy.health = 0;
                }
                return attackModifier;
            }
            else
            {
                return 0;
            }
        }

        public void printInventory()
        {
            if(this.inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty\n");
            }
            else
            {
                Console.WriteLine("Items in Inventory");

                /*
                foreach (Item item in this.inventory)
                {
                    Console.WriteLine("\tItem: " + item.Name);
                    Console.WriteLine("\tType: " + item.Type + "\n");

                    
                    if(item.GetType() == typeof(Potion))
                    {
                        Console.WriteLine("Potion Size: " item);
                    }
                    if(item.GetType() == typeof(Weapon))
                    {
                        
                    }
                    
                }*/
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

    abstract class Item
    {
        protected string name;
        protected string type;

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
    }

    class Weapon : Item
    {
        int damage;

        /// <summary>
        /// weapon constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="damage"></param>
        public Weapon(string name, string type, int damage)
        {
            this.name = name;
            this.type = type;
            this.damage = damage;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
        }

    }

    class Potion : Item
    {
        int size;
        /// <summary>
        /// Potion constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="size"></param>
        public Potion(string name, string type, int size)
        {
            this.name = name;
            this.type = type;
            this.size = size;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }

    }
}
