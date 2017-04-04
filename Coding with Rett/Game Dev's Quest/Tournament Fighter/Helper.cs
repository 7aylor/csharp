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
    }
}
