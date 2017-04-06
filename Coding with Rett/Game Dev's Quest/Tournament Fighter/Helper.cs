using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{
    class Helper
    {
        public static void ClearLine(int width, int height)
        {
            Console.SetCursorPosition(width, height);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(width, height);
        }

        /// <summary>
        /// Checks the user input to ensure it is one of the characters in the chars array.
        /// </summary>
        /// <param name="playerChoice">the user input of the player</param>
        /// <param name="chars">An array of correct possible inputs</param>
        public static void checkInput(ref char playerChoice, char[] chars)
        {
            //bool used to determine success of check
            bool passedCheck = false;

            //while we haven't passed the check
            while (!passedCheck)
            {
                playerChoice = Char.ToLower(playerChoice);
                //loop through all correct possible characters
                for (int i = 0; i < chars.Length; i++)
                {
                    //if there is a match, we have passed the check, and break the loop
                    if (playerChoice == chars[i])
                    {
                        passedCheck = true;
                        break;
                    }
                }
                //if we made it through the loop and we haven't passed the check, invalid input
                if (!passedCheck)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write("\ninvalid input. please try again: ");
                    playerChoice = Console.ReadKey().KeyChar;
                }
            }
        }//end of check input

        /// <summary>
        /// Printers horizontal divider and alternates the colors
        /// </summary>
        public static void printDivider()
        {
            for (int i = 0; i < Game.WINDOW_WIDTH; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("=");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("=");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Sets position to top of player nav and prints a divider
        /// </summary>
        public static void buildPlayerNav()
        {
            Console.SetCursorPosition(0, Game.PLAYER_NAV_HEIGHT);
            printDivider();
        }

        /// <summary>
        /// Sets the positions in the Game Display for the player and enemy, then prints healths
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public static void printHeroesInFightGameDisplay(NPC player, NPC enemy)
        {
            Console.SetCursorPosition(0, 3);
            Console.Write(enemy.Name);
            Console.SetCursorPosition(0, 4);
            Console.Write("Health: " + enemy.Health);
            Console.SetCursorPosition(Game.WINDOW_WIDTH - Game.PLAYER_NAME_MAX_LENGTH, 3);
            Console.Write(player.Name);
            String printPlayerHealth = "Health: " + player.Health;
            Console.SetCursorPosition(Game.WINDOW_WIDTH - printPlayerHealth.Length, 4);
            Console.Write(printPlayerHealth);
        }

        /// <summary>
        /// Prints the action the hero chooses in the fight
        /// </summary>
        /// <param name="playerAttack"></param>
        /// <param name="enemyAttack"></param>
        public static void printActionsInFightGameDisplay(StatType playerAttack, StatType enemyAttack)
        {
            Console.SetCursorPosition(0, 8);
            Console.Write("Attack Type: " + enemyAttack);
            Console.SetCursorPosition(0, 8);

            string printPlayerAttack = "Attack Type: " + playerAttack;
            Console.SetCursorPosition(Game.WINDOW_WIDTH - printPlayerAttack.Length, 8);
            Console.Write(printPlayerAttack);
        }
    }
}
