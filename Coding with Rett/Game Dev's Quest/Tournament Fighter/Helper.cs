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
            for (int i = 0; i < GameConstants.WINDOW_WIDTH; i++)
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
            Console.SetCursorPosition(0, GameConstants.PLAYER_NAV_HEIGHT);
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
            Console.WriteLine("Health: " + enemy.Health);
            Console.WriteLine("Strength: " + enemy.Strength);
            Console.WriteLine("Speed: " + enemy.Speed);
            Console.WriteLine("Defense: " + enemy.Defense);

            Console.SetCursorPosition(GameConstants.WINDOW_WIDTH - player.Name.Length, 3);
            Console.Write(player.Name);
            String printPlayerHealth = "Health: " + player.Health;
            Console.SetCursorPosition(GameConstants.WINDOW_WIDTH - printPlayerHealth.Length, 4);
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
            Console.Write("Attack Type: ");

            switch (enemyAttack)
            {
                case StatType.Defense:
                    Console.ForegroundColor = GameConstants.DEFENSE_COLOR;
                    break;
                case StatType.Speed:
                    Console.ForegroundColor = GameConstants.SPEED_COLOR;
                    break;
                case StatType.Strength:
                    Console.ForegroundColor = GameConstants.STRENGTH_COLOR;
                    break;
            }

            Console.Write(enemyAttack);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 8);

            string printPlayerAttack = "Attack Type: " + playerAttack;
            Console.SetCursorPosition(GameConstants.WINDOW_WIDTH - printPlayerAttack.Length, 8);
            Console.Write("Attack Type: ");

            switch (playerAttack)
            {
                case StatType.Defense:
                    Console.ForegroundColor = GameConstants.DEFENSE_COLOR;
                    break;
                case StatType.Speed:
                    Console.ForegroundColor = GameConstants.SPEED_COLOR;
                    break;
                case StatType.Strength:
                    Console.ForegroundColor = GameConstants.STRENGTH_COLOR;
                    break;
            }
            Console.Write(playerAttack);
            Console.ForegroundColor = ConsoleColor.Gray;

        }//end of printActionsInFightGameDisplay

        /// <summary>
        /// Clears the screen, prints the player stats, prints the player nav display,
        /// then sets cursor to main display (0, 3)
        /// </summary>
        public static void printCleanUI()
        {
            Console.Clear();
            GameCharacters.player.printStats();
            Helper.buildPlayerNav();
            Console.SetCursorPosition(0, 3);
        } 
    }

    /// <summary>
    /// holds an x and y value, making a coordinate of the console
    /// </summary>
    public struct consoleCoords
    {
        public int X { get; set; }
        public int Y { get; set; }

        public consoleCoords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void setCoords(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
