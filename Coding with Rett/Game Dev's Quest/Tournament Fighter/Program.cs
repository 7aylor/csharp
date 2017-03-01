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
            GameLocations.tavern.addNPCToLocation(GameCharacters.Nina);
            GameLocations.tavern.printNPCsInLocation();

            GameLocations.tavern.removeNPCFromLocation(GameCharacters.Nina);
            GameLocations.tavern.printNPCsInLocation();



            Console.ReadKey();
        }
    }
}
