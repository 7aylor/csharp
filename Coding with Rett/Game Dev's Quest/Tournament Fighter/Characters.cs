using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tournament_Fighter
{
    enum PlayerType { Villager, Fighter, Player };


    /// <summary>
    /// NPC Class
    /// </summary>
    class NPC
    {
        string name;
        string occupation;
        int health;
        int speed;
        int strength;
        int defense;
        PlayerType type;

        /// <summary>
        /// NPC Base constructor used mainly for villagers (non-fighters)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public NPC(string name, string occupation, PlayerType type)
        {
            this.name = name;
            this.occupation = occupation;
            this.type = type;
        }

        /// <summary>
        /// NPC Constructor, overrides base constructor used mainly for fighters
        /// Default stats (speed, strength, defense) are all set to 7, then balanced
        /// by calling initStats()
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="speed"></param>
        /// <param name="strength"></param>
        public NPC(string name, PlayerType type)
        {
            this.name = name;
            this.type = type;
            this.speed = 7;
            this.strength = 7;
            this.defense = 7;
            if(type == PlayerType.Fighter)
            {
                this.initStats();
            }
        }

        #region //getters and setters
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Occupation
        {
            get
            {
                return this.occupation;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }
        //virtual so Player subclass can override
        public virtual int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }
        //virtual so Player subclass can override
        public virtual int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.strength = value; 
            }
        }
        //virtual so Player subclass can override
        public virtual int Defense
        {
            get
            {
                return this.defense;
            }
            set
            {
                this.defense = value;
            }
        }
        #endregion

        //methods

        /// <summary>
        /// Finds the biggest stat and uses that as a modifier to create the player's health
        /// </summary>
        public void setHealthFromMaxStat()
        {
            //calls getBiggestStat to find which stat has the most points
            int biggestStat = getBiggestStatNumber();

            //set health to 50 then add max stat times five
            this.health = 50 + (biggestStat * 5);
        }

        /// <summary>
        /// Randomly initializes the NPC object's stats
        /// </summary>
        public void initStats()
        {
            //random number used to pick a random stat to change
            Random rand = new Random();

            //holds the next random value that rand returns
            int randomNum = 0;

            //loop ten times to modify default stat levels from 7, 7, 7
            for (int i = 0; i < 10; i++)
            {
                //sleep one milisecond to make sure the random number changes for each object
                Thread.Sleep(1);

                //get a random number between 0 and 2
                randomNum = rand.Next(3);

                //if the random number is 0 and defense is not less than 1, increase strength and decrease defense
                if(randomNum == 0 && this.defense > 1)
                {
                    this.strength++;
                    this.defense--;
                }
                //if the random number is 0 and strength is not less than 1, increase speed and decrease strength
                if (randomNum == 1 && this.strength > 1)
                {
                    this.speed++;
                    this.strength--;
                }
                //if the random number is 0 and speed is not less than 1, increase defense and decrease speed
                if (randomNum == 2 && this.speed > 1)
                {
                    this.defense++;
                    this.speed--;
                }
            }

            //take these numbers and initialize the health for our object
            this.setHealthFromMaxStat();
        }

        /// <summary>
        /// Returns a stat type that is used in battle ie Strength, Speed, Defense
        /// </summary>
        /// <returns>Returns a StatType</returns>
        public StatType pickBattleStat()
        {
            //random number, then pick a random between 0 and 3
            Random statRange = new Random();
            int random = statRange.Next(4);

            //gets the largest stat of our NPC
            StatType largestStat = getBiggestStat();

            //Gives weight to the largest stat ie, if the largest is strength, it has 50% chance of being picked
            //while other stats have 25% change of being picked.
            if (largestStat == StatType.Strength)
            {
                if (random == 0 || random == 1)
                {
                    return StatType.Strength;
                }
                else if(random == 2)
                {
                    return StatType.Speed;
                }
                else
                {
                    return StatType.Defense;
                }

            }
            else if (largestStat == StatType.Speed)
            {
                if (random == 0 || random == 1)
                {
                    return StatType.Speed;
                }
                else if (random == 2)
                {
                    return StatType.Strength;
                }
                else
                {
                    return StatType.Defense;
                }
            }
            else
            {
                if (random == 0 || random == 1)
                {
                    return StatType.Defense;
                }
                else if (random == 2)
                {
                    return StatType.Speed;
                }
                else
                {
                    return StatType.Strength;
                }
            }

        }

        /// <summary>
        /// pass in winning stat and enemy hero
        /// </summary>
        /// <param name="winningStat"></param>
        /// <param name="enemy"></param>
        public void dealDamage(StatType winningStat, NPC enemy)
        {
            //strength wins, remove strength stat from enemy health
            if(winningStat == StatType.Strength)
            {
                enemy.health -= this.strength;
            }
            //speed wins, remove speed stat from enemy health
            if (winningStat == StatType.Speed)
            {
                enemy.health -= this.speed;
            }
            //defense wins, remove defense stat from enemy health
            if (winningStat == StatType.Defense)
            {
                enemy.health -= this.defense;
            }
        }

        /// <summary>
        /// Gets the biggest stat number, ie if Strength is biggest at 10, will return 10
        /// </summary>
        /// <returns></returns>
        private int getBiggestStatNumber()
        {
            //Used to hold the current biggest stat
            int max = 0;

            //loop three times, once for each stat
            for (int i = 0; i < 3; i++)
            {
                //if speed bigger than max, it is the biggest so set max equal to speed
                if (this.speed > max)
                {
                    max = this.speed;
                }
                //if strength bigger than max, it is the biggest so set max equal to strength
                if (this.strength > max)
                {
                    max = this.strength;
                }
                //if defense bigger than max, it is the biggest so set max equal to defense
                if (this.defense > max)
                {
                    max = this.defense;
                }
            }

            return max;
        }

        /// <summary>
        /// Return 0 if Strength is the largest stat, 1 if Speed is largest stat, 2 if Defense is largest stat
        /// </summary>
        /// <returns></returns>
        private StatType getBiggestStat()
        {
            //strength is biggest
            if(this.strength >= this.speed && this.strength >= this.defense)
            {
                return StatType.Strength;
            }
            //speed is biggest
            else if (this.speed >= this.strength && this.speed >= this.defense)
            {
                return StatType.Speed;
            }
            //defense is biggest
            else
            {
                return StatType.Defense;
            }
        }

    }

    /// <summary>
    /// Player Class, inherits from NPC
    /// </summary>
    class Player : NPC
    {
        int gold;
        int rank; //come back to this
        int actionPoints;

        /// <summary>
        /// Player constructor, inherits from NPC base class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public Player(string name, PlayerType type) : base(name, type)
        {
            this.gold = 10;
            this.rank = 1;
            this.actionPoints = 10;
        }

        #region //getters and setters
        public override int Speed
        {
            get
            {
                return base.Speed;
            }
            set
            {
                base.Speed = value;
                printStats();
            }
        }
        public override int Strength
        {
            get
            {
                return base.Strength;
            }
            set
            {
                base.Strength = value;
                printStats();
            }
        }
        public override int Defense
        {
            get
            {
                return base.Defense;
            }
            set
            {
                base.Defense = value;
                printStats();
            }
        }

        public int Gold
        {
            get
            {
                return this.gold;
            }
            set
            {
                this.gold = value;
                printStats();
            }
        }

        public int Rank
        {
            get
            {
                return this.rank;
            }
            set
            {
                this.rank = value;
                printStats();
            }
        }

        public int ActionPoints
        {
            get
            {
                return this.actionPoints;
            }
            set
            {
                this.actionPoints = value;
                printStats();
            }
        }
        #endregion

        //Method for player to choose stats
        /// <summary>
        /// Prompts the person playing to answer a series of questions that will build the Player
        /// object's stats. 
        /// </summary>
        public void initPlayer()
        {
            Console.Clear();

            //used to save the user's input after answering a question
            char playerChoice;

            //print stats for the player to see
            printStats();

            //Question 1
            printQuestionsToBuildStats("You see a civilian being robbed. Do you:", 
                                       "a) Apprehend the robber?",
                                       "b) Lay a cunning trap for the robber?", 
                                       "c) Give the victim money from your own purse?");

            //get character from user
            playerChoice = Console.ReadKey().KeyChar;
            //make sure user inputs a, b, or c
            char[] abc = new char[] { 'a', 'A', 'b', 'B', 'c', 'C' };
            Helper.checkInput(ref playerChoice, abc);
            //balance the stats
            buildPlayerStats(playerChoice);

            //Question 2
            printQuestionsToBuildStats("Your village is under attack, which weapon do you grab first?",
                                       "a) A Broadsword to crush your enemies", 
                                       "b) A Bow to kill from a distance",
                                       "c) A Spear to keep your foe at bay");

            //get character from user
            playerChoice = Console.ReadKey().KeyChar;
            //make sure user inputs a, b, or c
            Helper.checkInput(ref playerChoice, abc);
            //balance the stats
            buildPlayerStats(playerChoice);

            //Question 3
            printQuestionsToBuildStats("A local merchant accuses you of stealing from his shop. He sent for the " +
                                       "guards to settle the matter. Do you:", 
                                       "a) A weapon as nice as this rightfully belongs to one who can weild it. It's not stealing if its yours", 
                                       "b) Make a break for the nearest exit", 
                                       "c) Wait for the guards to peacefully clear up this misunderstanding");

            //get character from user
            playerChoice = Console.ReadKey().KeyChar;
            //make sure user inputs a, b, or c
            Helper.checkInput(ref playerChoice, abc);
            //balance the stats
            buildPlayerStats(playerChoice);

            //Question 4
            printQuestionsToBuildStats("You've acquired a freshly baked sweet cake, but a local scoundrel has cornered \nyou. " +
                                       "He wants it for himself. What do you do?", 
                                       "a) You throw it to the ground, crushing it under your heel. If you can't have it, no one will.",
                                       "b) Stuff it in your mouth before he can stop you.", 
                                       "c) Offer to split it with him. After all, it's only a sweet cake.");

            //get character from user
            playerChoice = Console.ReadKey().KeyChar;
            //make sure user inputs a, b, or c
            Helper.checkInput(ref playerChoice, abc);
            //balance the stats
            buildPlayerStats(playerChoice);

            //Question 5
            printQuestionsToBuildStats("You see an attractive person in the courtyard. How do you get their attention?",
                                       "a) You find the heaviest thing you can carry and walk it past, making sure they catch your backside.", 
                                       "b) You challenge your mates to a footrace putting the finish line right past your spark",
                                       "c) Slowly take a seat near them and attempt at making intellectual conversation.");

            //get character from user
            playerChoice = Console.ReadKey().KeyChar;
            //make sure user inputs a, b, or c
            Helper.checkInput(ref playerChoice, abc);
            //balance the stats
            buildPlayerStats(playerChoice);
            //add player health
            this.setHealthFromMaxStat();
        }

        /// <summary>
        /// Used in tandem with initPlayer. When the user answers a question, pass the char to
        /// buildPlayerStats and balance stats based on choice.
        /// </summary>
        /// <param name="stat"></param>
        protected void buildPlayerStats(char stat)
        {
            //if they chose a strength answer, increase strength, decrease defense
            if(stat == 'a' || stat == 'A')
            {
                Strength++;
                Defense--;
            }
            //if they chose a speed answer, increase speed, decrease strength
            else if(stat == 'b' || stat == 'B')
            {
                Speed++;
                Strength--;
            }
            //if they chose a defense answer, increase defense, decrease speed
            else if(stat == 'c' || stat == 'C')
            {
                Defense++;
                Speed--;
            }

            Console.Clear();

            printStats();
        }

        /// <summary>
        /// Prints the stats of the player on a single line
        /// </summary>
        public void printStats()
        {
            //##############ADD HEALTH TO STAT BAR
            Helper.ClearLine(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Strength: " + Strength);
            Console.SetCursorPosition(17, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Speed: " + Speed);
            Console.SetCursorPosition(34, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Defense: " + Defense);
            Console.SetCursorPosition(51, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Gold: " + gold);
            Console.SetCursorPosition(64, 0);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Action Points: " + actionPoints);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Print questions, helper function to initPlayer
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answerA"></param>
        /// <param name="answerB"></param>
        /// <param name="answerC"></param>
        private void printQuestionsToBuildStats(string question, string answerA, string answerB, string answerC)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n" + question + "\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(answerA); //strength
            Console.WriteLine(answerB); //speed
            Console.WriteLine(answerC + "\n"); //defense
            Console.Write(">");
        }
        
    }

}

