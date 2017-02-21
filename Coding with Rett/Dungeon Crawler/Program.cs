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

            List<Item> RettsInventory = new List<Item>();
            RettsInventory.Add(new Weapon("Gunbar's Heavy Axe", WeaponType.Axe, 10));
            RettsInventory.Add(new Potion("Minor Health Potion", PotionType.Health, 10));

            Hero Enemy = new Hero(10, 5, 5, "Rett", RettsInventory);

            Enemy.printInventory();

            Console.ReadKey();
        }

        /// <summary>
        /// Starts the game. Used as the game controller
        /// </summary>
        static void playGame()
        {
            //iser input character
            char choice;

            //create our Player Hero
            Hero Player = new Hero(100, 8, 5, "Player");

            //Welcome player to the game!
            Console.WriteLine("\t\t\tWelcome to Dungeon Crawler!!\n\n");

            //First choice of what to do
            Console.Write("You see a gate in front of you, walk through? (y/n): ");

            //get Player input and check if its y or n
            choice = Console.ReadKey().KeyChar;

            choice = checkChar(choice);

            //if yes, fight Gorlack
            if (choice == 'y' || choice == 'Y')
            {
                fightGorlack(Player);
            }
            //otherwise, game is over
            else
            {
                Console.WriteLine("\nYou are not a curious adventurer. You turn around, leaving behind a whole world of fun!" + 
                                  "\n\nGame Over. Press any key to Exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Fighting Gorlack Scene. If player chooses not to fight, the game is over
        /// </summary>
        /// <param name="Player"></param>
        static void fightGorlack(Hero Player)
        {
            //Player's choice char
            char choice;

            //create Gorlack and write dialogue to the screen
            Hero Gorlack = new Hero(20, 4, 2, "Gorlack the Weak");
            Console.Clear();
            Console.WriteLine("\nAs you walk through the gate, A menacing figure emerges from the shadows.\n");
            Console.WriteLine("You recognize the hideous face of Gorlack the Weak.\n\n");
            Console.Write("\"You've gone far enough. Prepare to meet your death!\" ");

            //get input from the Player and check it
            Console.Write("Fight or flee? (y/n): ");

            choice = Console.ReadKey().KeyChar;
            choice = checkChar(choice);

            //if they choose to fight, go to attackSequence
            if(choice == 'y' || choice == 'Y')
            {
                attackSequence(Player, Gorlack);
            }
            //otherwise, the game is over
            else
            {
                Console.WriteLine("\nYou flee in terror. Game Over.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// The scaffolding of our fight mechanics
        /// </summary>
        /// <param name="Player"></param>
        /// <param name="Enemy"></param>
        static void attackSequence(Hero Player, Hero Enemy)
        {
            //deteremine who goes first in the fight
            Hero firstToAttack = whoGoesFirst(Player, Enemy);

            //let the first attacker go first
            if (firstToAttack == Player)
            {
                //player attacks Enemy
                attackPhase(Player, Enemy);
            }
            else
            {
                //Enemy attacks player
                attackPhase(Enemy, Player);
            }

            //if the player has no health, they have died and the game is over
            if (Player.Health <= 0)
            {
                Console.WriteLine("\nYou have died... Thanks for playing.\n");
                Console.ReadKey();
                Environment.Exit(0);
            }
            //if the Enemy has been slain, continue going forward
            else if (Enemy.Health <= 0)
            {
                Console.WriteLine("\nYou have slain " + Enemy.Name + "! You live to fight another day...");
            }
        }

        /// <summary>
        /// A random modifer if multiplied by the Hero's speed. Whichever Hero has the bigger number goes first
        /// </summary>
        /// <param name="Player"></param>
        /// <param name="Enemy"></param>
        /// <returns></returns>
        static Hero whoGoesFirst(Hero Player, Hero Enemy)
        {
            //Random number
            Random randomInitiative = new Random();

            //players speed modifier, a number between 0.0 and 1.0
            float PlayerSpeedModifier = randomInitiative.Next(0, 11) / 10f;

            //Enemy's speed modifier, a number between 0.0 and 1.0
            float EnemySpeedModifier = randomInitiative.Next(0, 11) / 10f;

            //Whichever hero has the biggest speed * modifer goes first
            if (Player.Speed * PlayerSpeedModifier > Enemy.Speed * EnemySpeedModifier)
            {
                Console.Write("\n\n" + Player.Name + " has the upperhand and attacks first! Press any key to start the fight...");
                Console.ReadKey();
                return Player;
            }
            else
            {
                Console.Write("\n\n" + Enemy.Name + " has the upperhand and attacks first! Press any key to start the fight...");
                Console.ReadKey();
                return Enemy;
            }
        }

        /// <summary>
        /// The specifics of the fight. Player can decide to continue fighting or flee
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        static void attackPhase(Hero first, Hero second)
        {
            int firstDmg;
            int secDmg;
            char choice;

            //Console.WriteLine(enemy.Name + "'s " + weapon.Type + " glances off your armor.")
            //Console.WriteLine(enemy.Name + "'s " + weapon.Type + " pierces your butt.");
            //

            while (first.Health > 0 && second.Health > 0)
            {
                //first Hero attacks and the result is written to the screen
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

                //second Hero attacks and the result is written to the screen
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

                //If the Heroes still have health, present the option to continue the battle
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Hero"></param>
        static void printCombatLog(Hero Hero)
        {
            string[] combatLogMeleeWeapons;
            string[] combatLogRangedWeapons;

            //combatLogMeleeWeapons[0] = Hero.Name + "'s " +  + " glances off your armor.";
        }


        /// <summary>
        /// Checks the char to ensure its a Y or N
        /// </summary>
        /// <param name="choice"></param>
        /// <returns>Returns a char that is either a Y, y, N, or n</returns>
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
