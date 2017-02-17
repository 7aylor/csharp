using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            char choice;


            Console.WriteLine("\t\t\tWelcome to Dungeon Crawler!!\n\n");

            Console.Write("You see a gate in front of you, walk through? (y/n): ");
            choice = Console.ReadKey().KeyChar;

            while (choice != 'y' && choice != 'Y' && choice != 'n' && choice != 'N')
            {
                Console.WriteLine();
                Console.Write("Invalid input, please try again: ");
                choice = Console.ReadKey().KeyChar;
            }

            if(choice == 'y' || choice == 'Y')
            {

            }
            else
            {
                Console.WriteLine("\nWell, thanks for playing. Bye!");
                Console.ReadKey();
                return;
            }

            Hero player = new Hero(100, 8, 5, 3);
            Hero enemy = new Hero(20, 4, 2, 1);
            
            Console.WriteLine("\nEnemy's health before Attack: " + enemy.Health);
            player.inflictDamage(enemy);
            Console.WriteLine("\nEnemy's health after Attack: " + enemy.Health);



            Console.ReadKey();
        }

        
    }
}
