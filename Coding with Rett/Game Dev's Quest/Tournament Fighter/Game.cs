﻿using System;
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
            GameCharacters.player.initPlayer();
            //tutorialBattle();
            fight(GameCharacters.player, GameCharacters.SmilinDonnie);
        }

        /// <summary>
        /// Print title screen
        /// </summary>
        static void printTitleScreen()
        {
            ConsoleColor defaultColor = ConsoleColor.Gray;
            ConsoleColor flag = ConsoleColor.Red;
            ConsoleColor roof = ConsoleColor.Yellow;

            Console.WriteLine("\t      Welcome to Tournament Fighter!\n");
            Console.Write("\t\t               ");
            Console.ForegroundColor = flag;
            Console.WriteLine("T~~");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("\t\t               |");
            Console.WriteLine("\t\t              /\"\\");
            Console.Write("\t\t      ");
            Console.ForegroundColor = flag;
            Console.Write("T~~");
            Console.ForegroundColor = defaultColor;
            Console.Write("     |'| ");
            Console.ForegroundColor = flag;
            Console.WriteLine("T~~");
            Console.ForegroundColor = defaultColor;
            Console.Write("\t\t  ");
            Console.ForegroundColor = flag;
            Console.Write("T~~");
            Console.ForegroundColor = defaultColor;
            Console.Write(" |    ");
            Console.ForegroundColor = flag;
            Console.Write("T~");
            Console.ForegroundColor = roof;
            Console.Write(" WWWW");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("|");
            Console.Write("\t\t  |  /\"\\   |  |  |/\\");
            Console.ForegroundColor = flag;
            Console.WriteLine("T~~");
            Console.ForegroundColor = defaultColor;
            Console.Write("\t\t /\"\\ ");
            Console.ForegroundColor = roof;
            Console.Write("WWW");
            Console.ForegroundColor = defaultColor;
            Console.Write(" / \"\\ |' |");
            Console.ForegroundColor = roof;
            Console.Write("WW");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("|");
            Console.Write("\t\t");
            Console.ForegroundColor = roof;
            Console.Write("WWWWW");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("/\\| /   \\|'/\\|/\"\\");
            Console.Write("\t\t|   /__\\/]");
            Console.ForegroundColor = roof;
            Console.Write("WWW");
            Console.ForegroundColor = defaultColor;
            Console.Write("[\\/__\\");
            Console.ForegroundColor = roof;
            Console.WriteLine("WWWW");
            Console.ForegroundColor = defaultColor;
            Console.Write("\t\t|\"  ");
            Console.ForegroundColor = roof;
            Console.Write("WWWW");
            Console.ForegroundColor = defaultColor;
            Console.Write("'|I_I|'");
            Console.ForegroundColor = roof;
            Console.Write("WWWW");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("'  |");
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

            Console.Write("\n\n                                       |");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(">>>");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                                       |");
            Console.WriteLine("                                   _  _|_  _");
            Console.WriteLine("                                  |;|_|;|_|;|");
            Console.WriteLine("                                  \\.    .  /");
            Console.WriteLine("                                   \\:  .  /");
            Console.WriteLine("                                    ||:  .|");
            Console.WriteLine("                                    ||:   |       \\,/");
            Console.WriteLine("                                    ||: , |            /`\\");
            Console.WriteLine("                                    ||:   |");
            Console.Write("     ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("__");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                            _||_   |");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("--`~    '--~~__            __ ----~    ~`---,              ___");
            Console.WriteLine("                ~---__ ,--~'                  ~~----_____-~'   `~");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }

        /// <summary>
        /// After title screen, start intro battle
        /// </summary>
        static void tutorialBattle()
        {
            //yes and no characters used to check user input
            char[] yn = new char[] { 'y', 'n' };

            //clear the screen and print stats at top
            Console.Clear();
            GameCharacters.player.printStats();

            //Story
            slowTyper("You're pulled from your daydream when a booming voice yells:");
            slowTyper("@\t\"They's a toll f'dis here gate.\"", dialogueColor);
            slowTyper("Sliding from the shadows of the gate is a shrewd figure. You know him to be" +
                      "\nSmilin' Donnie, a smalltime crook who likes to grab at women and put his name" +
                      "\non things.");
            slowTyper("@\t\"So wot'll it be\"", dialogueColor);
            slowTyper("he says, impatiently tapping his sword on the side of his leg.");
            slowTyper("@\t\"You'onna pay tha fee or am I gonna 'ave to carve you up some?\"", dialogueColor);
            Console.Write("Pay 1 gold? (y/n) >");

            //get player input and check to make sure its y, Y, n, or N
            char playerChoice = Console.ReadKey().KeyChar;
            Helper.checkInput(ref playerChoice, yn);

            //if they chose yes, remove 1 gold from player and continue
            if(playerChoice == 'y')
            {
                Console.Clear();

                //using the Gold setter prints the updated stats at top of screen
                GameCharacters.player.Gold -= 1;

                slowTyper("\t\"You ain't gettin' through wit'is chump change. Empty yer purse.\"", dialogueColor);
                Console.Write("Pay 3 more gold? (y/n) >");
                playerChoice = Console.ReadKey().KeyChar;
                Helper.checkInput(ref playerChoice, yn);

                //if they chose yes, remove 3 gold from player and continue
                if (playerChoice == 'y')
                {
                    Console.Clear();
                    GameCharacters.player.Gold -= 3;
                    slowTyper("\t\"I've robbed hobos wit more money den'is.\"", dialogueColor);
                    Console.Write("Pay 6 more gold? (y/n) >");
                    playerChoice = Console.ReadKey().KeyChar;
                    Helper.checkInput(ref playerChoice, yn);

                    //if they chose yes, remove 6 gold from player and continue
                    if (playerChoice == 'y')
                    {
                        Console.Clear();
                        GameCharacters.player.Gold -= 6;
                        slowTyper("\t\"How I'mapposed ta build me wall wit'is?\"", dialogueColor);
                    }
                    //no more gold removed and fighting will commence
                    else
                    {
                        Console.Clear();
                        GameCharacters.player.printStats();
                        slowTyper("\t\"It was either cake or death, mate, and we're fresh outa cake.\"", dialogueColor);
                    }
                }
                //no more gold removed and fighting will commence
                else
                {
                    Console.Clear();
                    GameCharacters.player.printStats();
                    slowTyper("\t\"Keep your silver then, mate, your gonna need it to cross the River \n\tStyx.\"", dialogueColor);
                }
            }
            //no gold removed and fighting will commence
            else
            {
                Console.Clear();
                GameCharacters.player.printStats();
                slowTyper("\t\"Not gonna pay, eh? We'll see about'at.\"", dialogueColor);
            }

            slowTyper("Smilin' Donnie unsheathes a nasty looking blade, barely giving you time to think.");

            //FIGHT FUNCTION

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

        static void fight(Player player, NPC enemy)
        {
            //print the enemy health and prompt to pick stat a b c
            StatType enemyAttack = enemy.pickBattleStat();
            StatType playerAttack = player.pickBattleStat(enemy);

            Console.WriteLine(enemy.Name + " attacks with " + enemyAttack);
            Console.WriteLine(player.Name + " attacks with " + playerAttack);
            inflictDamageOnLoser(player, enemy, playerAttack, enemyAttack);
            //Loop through all of this and clean it up.

        }

        /// <summary>
        /// Calculates the winning stat and inflicts damage on the loser
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        /// <param name="playerAttack"></param>
        /// <param name="enemyAttack"></param>
        static void inflictDamageOnLoser(NPC player, NPC enemy, StatType playerAttack, StatType enemyAttack)
        {
            //enemy Strength
            if (enemyAttack == StatType.Strength)
            {
                //both Strength
                if (playerAttack == StatType.Strength)
                {
                    Console.WriteLine("It's a tie! No damage dealt");
                }
                //player Speed, enemy Strength
                else if (playerAttack == StatType.Speed)
                {
                    Console.WriteLine(player.Name + " deals " + player.Speed + " damage to " + enemy.Name);
                    enemy.Health -= player.Speed;
                }
                //player Defense, enemy Strength
                else
                {
                    Console.WriteLine(enemy.Name + " deals " + enemy.Defense + " damage to " + enemy.Name);
                    player.Health -= enemy.Strength;
                }
            }
            //enemy Speed
            else if (enemyAttack == StatType.Speed)
            {
                //player Strength, enemgy Speed
                if (playerAttack == StatType.Strength)
                {
                    Console.WriteLine(enemy.Name + " deals " + enemy.Defense + " damage to " + enemy.Name);
                    player.Health -= enemy.Strength;

                }
                //both Speed
                else if (playerAttack == StatType.Speed)
                {
                    Console.WriteLine("It's a tie! No damage dealt");

                }
                //player Defense, enemy Speed
                else
                {
                    Console.WriteLine(player.Name + " deals " + player.Speed + " damage to " + enemy.Name);
                    enemy.Health -= player.Speed;
                }
            }
            //enemy Defense
            else
            {
                //player Strength, enemgy Defense
                if (playerAttack == StatType.Strength)
                {
                    Console.WriteLine(enemy.Name + " deals " + enemy.Defense + " damage to " + enemy.Name);
                    player.Health -= enemy.Strength;

                }
                //player Speed, enemy Defense
                else if (playerAttack == StatType.Speed)
                {
                    Console.WriteLine(player.Name + " deals " + player.Speed + " damage to " + enemy.Name);
                    enemy.Health -= player.Speed;
                }
                //both Defense
                else
                {
                    Console.WriteLine("It's a tie! No damage dealt");
                }
            }
        }
    }
}
