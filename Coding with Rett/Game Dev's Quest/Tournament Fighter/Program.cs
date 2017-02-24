using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{

    class Program
    {
        static void Main(string[] args)
        {
            List<NPC> NPCs = new List<NPC>();

            NPC nina = new NPC("Nina", PlayerType.Villager);
            NPC duncan = new NPC("Duncan", PlayerType.Fighter, 100, 5, 7);

            NPCs.Add(nina);
            NPCs.Add(duncan);

            Tavern tavern = new Tavern("Bucky's Big Gulps");
            tavern.addNPCToLocation(nina);
            tavern.addNPCToLocation(duncan);

            tavern.printNPCsInLocation();

            //tavern.addMenuItem(new Consumable(ConsumableType.Ale, ))

            Console.ReadKey();
        }
    }
}
