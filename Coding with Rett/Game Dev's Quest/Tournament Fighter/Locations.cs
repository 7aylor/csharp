using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{

    /// <summary>
    /// Generic base class that all Locations will inherit from
    /// </summary>
    abstract class Location
    {
        //name of the location
        protected string name;
        //List of all characters at the Location
        protected List<NPC> characters = new List<NPC>();

        /// <summary>
        /// default constructor that can be inherited from, 
        /// can't use to instantiate an abstract class
        /// </summary>
        /// <param name="name"></param>
        public Location(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Add a non-player character to the List of characters in the Location object
        /// </summary>
        /// <param name="npc"></param>
        public void addNPCToLocation(NPC npc)
        {
            characters.Add(npc);
        }

        /// <summary>
        /// Remove a non-player character to the List of characters in the Location object
        /// </summary>
        /// <param name="npc"></param>
        public void removeNPCFromLocation(NPC npc)
        {
            characters.RemoveAt(characters.IndexOf(npc));
        }

        /// <summary>
        /// Print all characters in the location
        /// </summary>
        public void printNPCsInLocation()
        {
            //if there are people at the location, print all of their names
            if(characters.Count > 0)
            {
                foreach (NPC c in characters)
                {
                    Console.WriteLine(c.Name);
                }
            }
            //otherwise, print that no one is at the location
            else
            {
                Console.WriteLine("No one is at " + this.name);
            }
        }
    }

    /// <summary>
    /// Tavern Class, inherits from Location base class
    /// </summary>
    class Tavern : Location
    {
        //{ Steak, Stew, Potato, Porridge, Grog, Wine, Ale, Tea, Coffee }
        List<Consumable> menu = new List<Consumable>();

        /// <summary>
        /// Tavern Class Base Constructor, inherits from Location base class
        /// Initializes menu items
        /// </summary>
        /// <param name="name"></param>
        public Tavern(string name) : base(name)
        {
            this.name = name;

            //loop through each type of consumable, and add one of each type to the
            //menu list, that way the tavern always has one of each type of consumable
            foreach (ConsumableType item in Enum.GetValues(typeof(ConsumableType)))
            {
                switch (item)
                {
                    case ConsumableType.Ale:
                        menu.Add(GameConsumables.Ale);
                        break;
                    case ConsumableType.Coffee:
                        menu.Add(GameConsumables.Coffee);
                        break;
                    case ConsumableType.Grog:
                        menu.Add(GameConsumables.Grog);
                        break;
                    case ConsumableType.Porridge:
                        menu.Add(GameConsumables.Porridge);
                        break;
                    case ConsumableType.Potato:
                        menu.Add(GameConsumables.Potato);
                        break;
                    case ConsumableType.Steak:
                        menu.Add(GameConsumables.Steak);
                        break;
                    case ConsumableType.Stew:
                        menu.Add(GameConsumables.Stew);
                        break;
                    case ConsumableType.Tea:
                        menu.Add(GameConsumables.Tea);
                        break;
                    case ConsumableType.Wine:
                        menu.Add(GameConsumables.Wine);
                        break;
                }
            }
        }
        /// <summary>
        /// Add a consumable item to the menu list
        /// </summary>
        /// <param name="c"></param>

        public void addMenuItem(Consumable c)
        {
            menu.Add(c);
        }

        /// <summary>
        /// print the entire menu at the Tavern
        /// </summary>
        public void printMenu()
        {
            foreach(Consumable item in menu)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void startGambling()
        {

        }

        public void meetPeople()
        {

        }

        public void printTavernUI()
        {
            Helper.printCleanUI();
            Console.WriteLine("Welcome to " + this.name + "!\n");
            Console.WriteLine("The tavern is neat and orderly.");
            Helper.buildPlayerNav();
            Console.WriteLine("What would you like to do?\n");
            Console.Write("1) See a menu\t\t2) See who's here\n");

            Console.Write("3) Play the arcade\t4) Try your luck at blackjack\n\n");



            //
        }

        //public void order
    }
}
