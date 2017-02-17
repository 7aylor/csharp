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

            //playGame();

            Weapon sword = new Weapon("Longclaw", "Sword", 5);
            Potion healthPotion = new Potion("Small Health Potion", "Health Potion", 3);

            Hero player = new Hero(100, 5, 5, "player");

            //player.printInventory();

            //player.addItemToInvetory(sword);
            //player.printInventory();

            //player.addItemToInvetory(healthPotion);
            //player.printInventory();

            Console.WriteLine(sword.GetType());
            Console.WriteLine(healthPotion.GetType());

            Console.ReadKey();
        }

        static void playGame()
        {
            char choice;
            Hero player = new Hero(100, 8, 5, "Player");
            Console.WriteLine("\t\t\tWelcome to Dungeon Crawler!!\n\n");

            Console.Write("You see a gate in front of you, walk through? (y/n): ");
            choice = Console.ReadKey().KeyChar;

            choice = checkChar(choice);

            if (choice == 'y' || choice == 'Y')
            {
                fightGorlack(player);
            }
            else
            {
                Console.WriteLine("\nWell, thanks for playing. Bye!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        static void fightGorlack(Hero player)
        {
            Hero Gorlack = new Hero(20, 4, 2, "Gorlack the Weak");
            Console.Clear();
            Console.WriteLine("\nAs you walk through the gate, A menacing figure emerges from the shadows.\n");
            Console.WriteLine("You recognize the hideous face of Gorlack the Weak.\n\n");
            Console.Write("\"You've gone far enough. Prepare to meet your death! ");

            char choice;

            Console.WriteLine("Fight or flee? (y/n)");

            choice = Console.ReadKey().KeyChar;
            choice = checkChar(choice);

            if(choice == 'y' || choice == 'Y')
            {
                attackSequence(player, Gorlack);
            }
            else
            {
                Console.WriteLine("You flee in terror. Game Over.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        static void attackSequence(Hero player, Hero enemy)
        {
            Hero firstToAttack = whoGoesFirst(player, enemy);

            if (firstToAttack == player)
            {
                attackPhase(player, enemy);
            }
            else
            {
                attackPhase(enemy, player);
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("\nYou have died... Thanks for playing.\n");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (enemy.Health <= 0)
            {
                Console.WriteLine("\nYou have slain " + enemy.Name + "! You live to fight another day...");
            }
        }

        static Hero whoGoesFirst(Hero player, Hero enemy)
        {
            Random randomInitiative = new Random();
            float playerSpeedModifier = randomInitiative.Next(0, 11) / 10f;
            float enemySpeedModifier = randomInitiative.Next(0, 11) / 10f;

            if (player.Speed * playerSpeedModifier > enemy.Speed * enemySpeedModifier)
            {
                return player;
            }
            else
            {
                return enemy;
            }
        }

        static void attackPhase(Hero first, Hero second)
        {
            int firstDmg;
            int secDmg;
            char choice;

            while (first.Health > 0 && second.Health > 0)
            {
                Console.Clear();
                Console.WriteLine(first.Name + " vs. " + second.Name);
                firstDmg = first.inflictDamage(second);
                if (firstDmg == 0)
                {
                    Console.WriteLine("\n" + first.Name + " missed.");
                }
                else
                {
                    Console.WriteLine("\n" + first.Name + " hits " + second.Name + " for " + firstDmg + " damage.");
                }

                secDmg = second.inflictDamage(first);

                if(secDmg == 0)
                {
                    Console.WriteLine(second.Name + " missed.");
                }
                else
                {
                    Console.WriteLine(second.Name + " hits " + first.Name + " for " + secDmg + " damage.");
                }

                Console.WriteLine("\n" + first.Name + " Health: " + first.Health);
                Console.WriteLine("\n" + second.Name + " Health: " + second.Health);

                if(first.Health > 0 && second.Health > 0)
                {
                    Console.Write("\n\nContinue battle? (y/n)");
                    choice = Console.ReadKey().KeyChar;

                    choice = checkChar(choice);

                    if (choice == 'n' || choice == 'N')
                    {
                        Console.WriteLine("\nYou have run away...\n");
                        break;
                    }
                }
            }
        }

        static char checkChar(char choice)
        {
            while (choice != 'y' && choice != 'Y' && choice != 'n' && choice != 'N')
            {
                Console.WriteLine();
                Console.Write("Invalid input, please try again: ");
                choice = Console.ReadKey().KeyChar;
            }

            return choice;
        }

    }
}
