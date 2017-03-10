using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tournament_Fighter
{
    static class Game
    {
        public static void play()
        {
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.CursorVisible = false;
            //printTitleScreen();
            printIntroStory();
            //GameCharacters.player.initPlayer();
        }

        /// <summary>
        /// Print title screen
        /// </summary>
        static void printTitleScreen()
        {
            Console.WriteLine("\t      Welcome to Tournament Fighter!\n");
            Console.WriteLine("\t\t               T~~");
            Console.WriteLine("\t\t               |");
            Console.WriteLine("\t\t              /\"\\");
            Console.WriteLine("\t\t      T~~     |'| T~~");
            Console.WriteLine("\t\t  T~~ |    T~ WWWW|");
            Console.WriteLine("\t\t  |  /\"\\   |  |  |/\\T~~");
            Console.WriteLine("\t\t /\"\\ WWW / \"\\ |' |WW|");
            Console.WriteLine("\t\tWWWWW/\\| /   \\|'/\\|/\"\\");
            Console.WriteLine("\t\t|   /__\\/]WWW[\\/__\\WWWW");
            Console.WriteLine("\t\t|\"  WWWW'|I_I|'WWWW'  |");
            Console.WriteLine("\t\t|   |' |/  -  \\|' |'  |");
            Console.WriteLine("\t\t|'  |  |LI=H=LI|' |   |");
            Console.WriteLine("\t\t|   |' | |[_]| |  |'  |");
            Console.WriteLine("\t\t|   |  |_|###|_|  |   |");
            Console.WriteLine("\t\t'---'--'-/___\\-'--'---'");
            Console.Write("\n\n\t  Press any key to begin your journey...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints initial storyline at beginning of game
        /// </summary>
        static void printIntroStory()
        {
            Console.Clear();
            slowTyper("As you walk the windy road to Beacon Hill, the runner’s words \nstill echo in your mind: " +
                              "@\n\n\t\"King Ragnar offers fame and fortune to anyone who wins his tourney.\"");
            Console.ReadKey();
            slowTyper("\n\nKing Ragnar’s gate begins to take shape over the treetops in\nthe " + 
                              "distance while you daydream of times past…");
            Console.ReadKey();

            Console.WriteLine("\n\n                                       |>>>");
            Console.WriteLine("                                       |");
            Console.WriteLine("                                   _  _|_  _");
            Console.WriteLine("                                  |;|_|;|_|;|");
            Console.WriteLine("                                  \\.    .  /");
            Console.WriteLine("                                   \\:  .  /");
            Console.WriteLine("                                    ||:  .|");
            Console.WriteLine("                                    ||:   |       \\,/");
            Console.WriteLine("                                    ||: , |            /`\\");
            Console.WriteLine("                                    ||:   |");
            Console.WriteLine("     __                            _||_   |");
            Console.WriteLine("--`~    '--~~__            __ ----~    ~`---,              ___");
            Console.WriteLine("                ~---__ ,--~'                  ~~----_____-~'   `~");
            Console.ReadKey();

        }

        /// <summary>
        /// Writes characters with a pause in between //
        /// </summary>
        /// <param name="s"></param>
        static void slowTyper(string s)
        {
            int top = Console.CursorTop;
            int left = Console.CursorLeft;

            //Loop through string and print each character, with pause in between each write
            foreach(char c in s)
            {
                //@ symbol means to pause longer than usual
                if(c != '@')
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(1000);
                }

                //If a key is pressed, skip to the written text
                if (Console.KeyAvailable)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine(s);
                    break;
                }
            }
        }
    }
}
