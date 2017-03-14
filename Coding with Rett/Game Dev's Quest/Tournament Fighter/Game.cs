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
        public const int WINDOW_WIDTH = 81;
        public const int WINDOW_HEIGHT = 30;
        const ConsoleColor dialogueColor = ConsoleColor.Yellow;

        public static void play()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            Console.SetBufferSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            //#######DISABLE MOUSE IN CONSOLE?#####
            //Console.CursorVisible = false;

            //#######WORK ON TRANSITIONS#######
            //printTitleScreen();
            //printIntroStory();
            //GameCharacters.player.initPlayer();
            tutorialBattle();
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
            slowTyper("King Ragnar’s gate begins to take shape over the treetops in\nthe " + 
                              "distance while you daydream of times past…");

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
        /// After title screen, start intro battle
        /// </summary>
        static void tutorialBattle()
        {
            char[] yn = new char[] { 'y', 'Y', 'n', 'N' };
            Console.Clear();
            GameCharacters.player.printStats();
            slowTyper("You're pulled from your daydream when a booming voice yells:");
            slowTyper("@\t\"They's a toll f'dis here gate.\"", dialogueColor);
            slowTyper("Sliding from the shadows of the gate is a shrewd figure. You know him to be" +
                      "\nSmilin' Donnie, a smalltime crook who likes to grab at women and put his name" +
                      "\non things.");
            slowTyper("@\t\"So wot'll it be\"", dialogueColor);
            slowTyper("he says, impatiently tapping his sword on the side of his leg.");
            slowTyper("@\t\"You'onna pay tha fee or am I gonna 'ave to carve you up some?\"", dialogueColor);
            Console.Write("Pay 1 gold? (y/n) >");

            char playerChoice = Console.ReadKey().KeyChar;
            Helper.checkInput(ref playerChoice, yn);

            if(playerChoice == 'y' || playerChoice == 'Y')
            {
                Console.Clear();
                GameCharacters.player.Gold -= 1;

                slowTyper("\t\"You ain't gettin' through wit'is chump change. Empty yer purse.\"", dialogueColor);
                Console.Write("Pay 3 more gold? (y/n) >");
                playerChoice = Console.ReadKey().KeyChar;
                Helper.checkInput(ref playerChoice, yn);

                if(playerChoice == 'y' || playerChoice == 'Y')
                {
                    Console.Clear();
                    GameCharacters.player.Gold -= 3;
                    slowTyper("\t\"I've robbed hobos wit more money den'is.\"", dialogueColor);
                    Console.Write("Pay 6 more gold? (y/n) >");
                    playerChoice = Console.ReadKey().KeyChar;
                    Helper.checkInput(ref playerChoice, yn);

                    ///LEFT OFF HERE. CONTINUE TO FIGHT AFTER DIALOGUE
                    slowTyper("\t\"\"", dialogueColor);

                    
                }
            }
            else
            {

            }

            //Console.ReadKey(true);
        }

        /// <summary>
        /// Writes characters with a pause in between //
        /// </summary>
        /// <param name="s"></param>
        static void slowTyper(string s, ConsoleColor color=ConsoleColor.Gray)
        {
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            Console.ForegroundColor = color;

            //Loop through string and print each character, with pause in between each write
            foreach(char c in s)
            {
                ///TAKE A LOOK AT @ SYMBOL IF THAT SKIP THIS SECTION
                //@ symbol means to pause longer than usual
                if(c != '@')
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(500);
                }

                //If a key is pressed, skip to the written text
                if (Console.KeyAvailable)
                {
                    //check each character to make sure it is not '@' (Our pause character).
                    foreach(char ch in s)
                    {
                        //if the character is '@', remove it
                        if(ch == '@')
                        {
                            s = s.Remove(s.IndexOf(ch), 1);
                        }
                    }
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine(s);
                    break;
                }
            }
            Console.WriteLine();
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
