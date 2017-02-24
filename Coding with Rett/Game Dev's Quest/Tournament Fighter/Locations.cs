using System;
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
            this.characters.Add(npc);
        }

        public void printNPCsInLocation()
        {
            foreach(NPC c in characters)
            {
                Console.WriteLine(c.Name);
            }
        }
    }

    class Tavern : Location
    {
        //{ Steak, Stew, Potato, Porridge, Grog, Wine, Ale, Tea, Coffee }
        List<Consumable> menu = new List<Consumable>();

        public Tavern(string name) : base(name)
        {
            this.name = name;
        }

        public void addMenuItem(Consumable c)
        {
            this.menu.Add(c);
        }

        public void printMenu()
        {

        }

        public void startGamling()
        {

        }

        public void meetPeople()
        {

        }

        //public void order
    }
}
