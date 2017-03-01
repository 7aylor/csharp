using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{
    abstract class Location
    {
        protected string name;
        protected List<NPC> characters = new List<NPC>();

        public Location(string name)
        {
            this.name = name;
        }

        public void addNPCToLocation(NPC npc)
        {
            characters.Add(npc);
        }

        public void removeNPCFromLocation(NPC npc)
        {
            characters.RemoveAt(characters.IndexOf(npc));
        }

        public void printNPCsInLocation()
        {
            if(characters.Count > 0)
            {
                foreach (NPC c in characters)
                {
                    Console.WriteLine(c.Name);
                }
            }
            else
            {
                Console.WriteLine("No one is at " + this.name);
            }
        }
    }

    class Tavern : Location
    {
        //{ Steak, Stew, Potato, Porridge, Grog, Wine, Ale, Tea, Coffee }
        List<Consumable> menu = new List<Consumable>();

        /// <summary>
        /// Tavern Class Base Constructor
        /// </summary>
        /// <param name="name"></param>
        public Tavern(string name) : base(name)
        {
            this.name = name;
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

        public void addMenuItem(Consumable c)
        {
            menu.Add(c);
        }

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

        //public void order
    }
}
