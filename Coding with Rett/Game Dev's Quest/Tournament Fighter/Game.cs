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
            //#######Lock Console Window Size WE NEED TO FIGURE THIS OUT
            Console.SetWindowSize(GameConstants.WINDOW_WIDTH, GameConstants.WINDOW_HEIGHT);
            Console.SetBufferSize(GameConstants.WINDOW_WIDTH, GameConstants.WINDOW_HEIGHT);
            //#######DISABLE MOUSE IN CONSOLE?#####
            //Console.CursorVisible = false;

            printTitleScreen();
            printIntroStory();
            GameCharacters.player.initPlayer();
            tutorialBattle();
            enterTheVillage();

            //game loop will check number of days 

        }

        #region //Storyline Functions

        /// <summary>
        /// Print title screen
        /// </summary>
        static void printTitleScreen()
        {
            ConsoleColor defaultColor = ConsoleColor.Gray;
            ConsoleColor flag = ConsoleColor.Red;
            ConsoleColor roof = ConsoleColor.Yellow;

            Console.WriteLine("\t\t         Welcome to Tournament Fighter!\n");
            Console.Write("\t\t\t                  ");
            Console.ForegroundColor = flag;
            Console.WriteLine("T~~");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("\t\t\t                  |");
            Console.WriteLine("\t\t\t                 /\"\\");
            Console.Write("\t\t\t         ");
            Console.ForegroundColor = flag;
            Console.Write("T~~");
            Console.ForegroundColor = defaultColor;
            Console.Write("     |'| ");
            Console.ForegroundColor = flag;
            Console.WriteLine("T~~");
            Console.ForegroundColor = defaultColor;
            Console.Write("\t\t\t     ");
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
            Console.Write("\t\t\t     |  /\"\\   |  |  |/\\");
            Console.ForegroundColor = flag;
            Console.WriteLine("T~~");
            Console.ForegroundColor = defaultColor;
            Console.Write("\t\t\t    /\"\\ ");
            Console.ForegroundColor = roof;
            Console.Write("WWW");
            Console.ForegroundColor = defaultColor;
            Console.Write(" / \"\\ |' |");
            Console.ForegroundColor = roof;
            Console.Write("WW");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("|");
            Console.Write("\t\t\t   ");
            Console.ForegroundColor = roof;
            Console.Write("WWWWW");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("/\\| /   \\|'/\\|/\"\\");
            Console.Write("\t\t\t   |   /__\\/]");
            Console.ForegroundColor = roof;
            Console.Write("WWW");
            Console.ForegroundColor = defaultColor;
            Console.Write("[\\/__\\");
            Console.ForegroundColor = roof;
            Console.WriteLine("WWWW");
            Console.ForegroundColor = defaultColor;
            Console.Write("\t\t\t   |\"  ");
            Console.ForegroundColor = roof;
            Console.Write("WWWW");
            Console.ForegroundColor = defaultColor;
            Console.Write("'|I_I|'");
            Console.ForegroundColor = roof;
            Console.Write("WWWW");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("'  |");
            Console.WriteLine("\t\t\t   |   |' |/  -  \\|' |'  |");
            Console.WriteLine("\t\t\t   |'  |  |LI=H=LI|' |   |");
            Console.WriteLine("\t\t\t   |   |' | |[_]| |  |'  |");
            Console.WriteLine("\t\t\t   |   |  |_|###|_|  |   |");
            Console.WriteLine("\t\t\t   '---'--'-/___\\-'--'---'\n\n");

            /////This may need some editing
            Console.Write("\t\tPlease enter your name to begin your journey: ");
            string name = Console.ReadLine();
            int currentLineHeight = Console.CursorTop;
            int currentLineLeft = Console.CursorLeft;

            while(name.Length > GameConstants.PLAYER_NAME_MAX_LENGTH || name.Length <= 0)
            {
                Console.SetCursorPosition(currentLineLeft, currentLineHeight - 1);
                Helper.ClearLine(currentLineLeft, currentLineHeight);
                Console.Write("Please use a name with at least 1 character and under " + (GameConstants.PLAYER_NAME_MAX_LENGTH + 1) + " characters: ");
                name = Console.ReadLine();
            }
            /*
            
            int count = 0;
            int key = Console.ReadKey().KeyChar;
            int startPosition = Console.CursorLeft;

            while (key != ConsoleKey.Enter)
            {
                if (count < GameConstants.PLAYER_NAME_MAX_LENGTH)
                {
                    if ((key == ConsoleKey.Backspace || key == ConsoleKey.Delete) && count > 0)
                    {
                        count = 0;
                        Helper.ClearLine(0, Console.CursorTop);
                    }
                    else if(key == ConsoleKey.A || key == ConsoleKey.B || key == ConsoleKey.C ||
                            key == ConsoleKey.D || key == ConsoleKey.E || key == ConsoleKey.F ||
                            key == ConsoleKey.G || key == ConsoleKey.H || key == ConsoleKey.I ||
                            key == ConsoleKey.J || key == ConsoleKey.B || key == ConsoleKey.C ||
                            )
                    else
                    {
                        name += key;
                        count++;
                        key = Console.ReadKey().Key;
                    }
                }
            }
            //Console.Write("\n\n\t\t     Press any key to begin your journey...");
            //Console.ReadKey();

            */

            GameCharacters.player.Name = name;
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
        /// After title screen, start intro battle. Goes through entire first encounter with Smilin' Donnie
        /// including a fight.
        /// </summary>
        static void tutorialBattle()
        {
            //yes and no characters used to check user input
            char[] yn = new char[] { 'y', 'n' };

            //clear the screen and print stats at top and the player nav bar at the bottom
            Helper.printCleanUI();

            //Story
            slowTyper("You're pulled from your daydream when a booming voice yells:");
            slowTyper("@\t\"They's a toll f'dis here gate.\"", GameConstants.DIALOGUE_COLOR);
            slowTyper("Sliding from the shadows of the gate is a shrewd figure. You know him to be" +
                      "\nSmilin' Donnie, a smalltime crook who likes to grab at women and put his name" +
                      "\non things.");
            slowTyper("@\t\"So wot'll it be\"", GameConstants.DIALOGUE_COLOR);
            slowTyper("he says, impatiently tapping his sword on the side of his leg.");
            slowTyper("@\t\"You'onna pay tha fee or am I gonna 'ave to carve you up some?\"", GameConstants.DIALOGUE_COLOR);
            Helper.buildPlayerNav();
            Console.Write("Pay 1 gold? (y/n) \n\n>");

            //get player input and check to make sure its y, Y, n, or N
            char playerChoice = Console.ReadKey().KeyChar;
            Helper.checkInput(ref playerChoice, yn);

            //if they chose yes, remove 1 gold from player and continue
            if(playerChoice == 'y')
            {
                Console.Clear();

                //using the Gold setter prints the updated stats at top of screen
                GameCharacters.player.Gold -= 1;
                Helper.buildPlayerNav();
                Console.SetCursorPosition(0, 3);

                slowTyper("\t\"You ain't gettin' through wit'is chump change. Empty yer purse.\"", GameConstants.DIALOGUE_COLOR);
                Helper.buildPlayerNav();
                Console.Write("Pay 3 more gold? (y/n) \n\n>");
                playerChoice = Console.ReadKey().KeyChar;
                Helper.checkInput(ref playerChoice, yn);

                //if they chose yes, remove 3 gold from player and continue
                if (playerChoice == 'y')
                {
                    Console.Clear();
                    GameCharacters.player.Gold -= 3;
                    Helper.buildPlayerNav();
                    Console.SetCursorPosition(0, 3);
                    slowTyper("\t\"I've robbed hobos wit more money den'is.\"", GameConstants.DIALOGUE_COLOR);
                    Helper.buildPlayerNav();
                    Console.Write("Pay 5 more gold? (y/n) \n\n>");
                    playerChoice = Console.ReadKey().KeyChar;
                    Helper.checkInput(ref playerChoice, yn);

                    //if they chose yes, remove 5 gold from player and continue
                    if (playerChoice == 'y')
                    {
                        Console.Clear();
                        GameCharacters.player.Gold -= 5;
                        Helper.buildPlayerNav();
                        Console.SetCursorPosition(0, 3);
                        slowTyper("\t\"How I'mapposed ta build me wall wit'is?\"", GameConstants.DIALOGUE_COLOR);
                    }
                    //no more gold removed and fighting will commence
                    else
                    {
                        Helper.printCleanUI();
                        slowTyper("\t\"It was either cake or death, mate, and we're fresh outa cake.\"", GameConstants.DIALOGUE_COLOR);
                    }
                }
                //no more gold removed and fighting will commence
                else
                {
                    Helper.printCleanUI();
                    slowTyper("\t\"Keep your silver then, mate, your gonna need it to cross the River \n\tStyx.\"", GameConstants.DIALOGUE_COLOR);
                }
            }
            //no gold removed and fighting will commence
            else
            {
                Helper.printCleanUI();
                slowTyper("\t\"Not gonna pay, eh? We'll see about'at.\"", GameConstants.DIALOGUE_COLOR);
            }

            slowTyper("Smilin' Donnie unsheathes a nasty looking blade, barely giving you time to think.");
            Console.WriteLine("Press any key to begin fight...");
            Console.ReadKey(true);
            Console.Clear();
            GameCharacters.player.printStats();

            //FIGHT FUNCTION
            NPC winner = fight(GameCharacters.player, GameCharacters.SmilinDonnie, 5);

            //if you beat Smilin' Donnie, he runs away
            if(winner == GameCharacters.player)
            {
                //clear the UI and print the winning message
                Helper.printCleanUI();
                slowTyper("No need fer blood mate, you keep ya monay.\n", GameConstants.DIALOGUE_COLOR);

                //if Donnie hasn't taken any money
                if(GameCharacters.player.Gold >= 10)
                {
                    //he drops 5 gold
                    slowTyper("Smilin' Donnie runs away dropping gold along the way.\n");
                    Console.WriteLine("You gain 5 gold.");
                    GameCharacters.player.Gold += 5;
                }
                else
                {
                    //if the player has given money, he drops that money + 5
                    slowTyper("Smilin' Donnie runs away tossing your coins on the ground. You realize he \ndropped more than he took.\n");
                    int goldGained = 10 - GameCharacters.player.Gold + 5;

                    Console.WriteLine("You gain " + goldGained + " gold.");
                    GameCharacters.player.Gold += goldGained;
                }
            }
            //Donnie wins the fight
            else
            {
                //clear the UI and Donnie takes all of the money
                GameCharacters.player.Health = 5;
                Helper.printCleanUI();
                slowTyper("You ain't even wirf da blood on me blade mate.\n", GameConstants.DIALOGUE_COLOR);
                slowTyper("Smilin' Donnie takes all of your gold and makes down the road toward the village.\n");
                Console.WriteLine("You lose " + GameCharacters.player.Gold + " gold.");
                GameCharacters.player.Gold = 0;
            }

        }

        /// <summary>
        /// After the intro battle, enter the Village
        /// </summary>
        static void enterTheVillage()
        {

        }
        #endregion

        #region //Game Mechanic Functions

        /// <summary>
        /// Writes characters with a pause in between. Allows you to choose a text color, or defaults to gray
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

        /// <summary>
        /// Loops through a fight scene allowing the player to choose an attack against the enemy NPC. 
        /// Takes the player and the enemy NPC as well as asking for a health limit that determines when
        /// the battle is over. Returns the winning NPC object.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        /// <param name="healthLimit"></param>
        /// <returns></returns>
        static NPC fight(Player player, NPC enemy, int healthLimit)
        {
            while (player.Health > healthLimit && enemy.Health > healthLimit)
            {
                Console.WriteLine();

                Helper.printHeroesInFightGameDisplay(player, enemy);

                //print the enemy health and prompt to pick stat a b c
                StatType enemyAttack = enemy.pickBattleStat();
                StatType playerAttack = player.pickBattleStat(enemy);

                Helper.printActionsInFightGameDisplay(playerAttack, enemyAttack);
                inflictDamageOnLoser(player, enemy, playerAttack, enemyAttack);

                Console.SetCursorPosition(GameConstants.WINDOW_WIDTH / 4, GameConstants.PLAYER_NAV_HEIGHT - 2);
                Console.WriteLine("Press any key to continue fighting...");
                Console.ReadKey(true);
                Console.Clear();
                GameCharacters.player.printStats();

                if(player.Health <= healthLimit)
                {
                    return enemy;
                }
                else if(enemy.Health <= healthLimit)
                {
                    return player;
                }
            }

            //returns null if no winner (shouldn't ever get here)
            return null;
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
            //Thread.Sleep(1);
            Random damage = new Random();
            int dmg;

            Console.SetCursorPosition(GameConstants.WINDOW_WIDTH / 4, GameConstants.PLAYER_NAV_HEIGHT - 6);
            //enemy strength
            if (enemyAttack == StatType.Strength)
            {
                //both strength
                if (playerAttack == StatType.Strength)
                {
                    Console.WriteLine("It's a tie! No damage dealt");
                }
                //player speed, enemy strength. Player beats Enemy. speed beats strength.
                else if (playerAttack == StatType.Speed)
                {
                    Console.ForegroundColor = GameConstants.PLAYER_HIT_COLOR;
                    dmg = damage.Next(player.Speed < 7 ? 1 : player.Speed - 7, player.Speed + 1);
                    Console.WriteLine(player.Name + " deals " + dmg + " damage to " + enemy.Name);
                    enemy.Health -= dmg;
                }
                //player defense, enemy strength. Enemy beats Player. strength beats defense.
                else
                {
                    Console.ForegroundColor = GameConstants.ENEMY_HIT_COLOR;
                    dmg = damage.Next(enemy.Strength < 7 ? 1 : enemy.Strength - 7, enemy.Strength + 1);
                    Console.WriteLine(enemy.Name + " deals " + dmg + " damage to " + player.Name);
                    player.Health -= dmg;
                }
            }
            //enemy speed
            else if (enemyAttack == StatType.Speed)
            {
                //player strength, enemy speed. Enemy beats Player. speed beats strength.
                if (playerAttack == StatType.Strength)
                {
                    Console.ForegroundColor = GameConstants.ENEMY_HIT_COLOR;
                    dmg = damage.Next(enemy.Speed < 7 ? 1 : enemy.Speed - 7, enemy.Speed + 1);
                    Console.WriteLine(enemy.Name + " deals " + dmg + " damage to " + player.Name);
                    player.Health -= dmg;

                }
                //both speed
                else if (playerAttack == StatType.Speed)
                {
                    Console.WriteLine("It's a tie! No damage dealt");

                }
                //player defense, enemy speed. Player beats Enemy. defense beats speed.
                else
                {
                    Console.ForegroundColor = GameConstants.PLAYER_HIT_COLOR;
                    dmg = damage.Next(player.Defense < 7 ? 1 : player.Defense - 7, player.Defense + 1);
                    Console.WriteLine(player.Name + " deals " + dmg + " damage to " + enemy.Name);
                    enemy.Health -= dmg;
                }
            }
            //enemy defense
            else
            {
                //player strength, enemy defense. Player beats Enemy. strength beats defense.
                if (playerAttack == StatType.Strength)
                {
                    Console.ForegroundColor = GameConstants.PLAYER_HIT_COLOR;
                    dmg = damage.Next(player.Strength < 7 ? 1 : player.Strength - 7, player.Strength + 1);
                    Console.WriteLine(player.Name + " deals " + dmg + " damage to " + enemy.Name);
                    enemy.Health -= dmg;
                }
                //player speed, enemy defense. Enemy beats Player. defense beats speed.
                else if (playerAttack == StatType.Speed)
                {
                    Console.ForegroundColor = GameConstants.ENEMY_HIT_COLOR;
                    dmg = damage.Next(enemy.Speed < 7 ? 1 : enemy.Speed - 7, enemy.Speed + 1);
                    Console.WriteLine(enemy.Name + " deals " + dmg + " damage to " + player.Name);
                    player.Health -= dmg;
                }
                //both defense
                else
                {
                    Console.WriteLine("It's a tie! No damage dealt");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }//End of inflictDamage Method

        /// <summary>
        /// Controls the game play in the town
        /// </summary>
        static void gameLoop()
        {

        }

        #endregion
    }
}
