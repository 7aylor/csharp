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

        public int Speed
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

        public int Strength
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

        public int Defense
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

            //set health to 50 then add max stat times five
            this.health = 50 + (max * 5);
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
        public int Gold
        {
            get
            {
                return this.gold;
            }
            set
            {
                this.gold = value;
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
            checkInputOnBuildPlayer(ref playerChoice);
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
            checkInputOnBuildPlayer(ref playerChoice);
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
            checkInputOnBuildPlayer(ref playerChoice);
            //balance the stats
            buildPlayerStats(playerChoice);

            //Question 4
            printQuestionsToBuildStats("You've acquired a freshly baked sweet cake, but a local scoundrel has cornered you. " +
                                       "He wants it for himself. What do you do?", 
                                       "a) You throw it to the ground, crushing it under your heel. If you can't have it, no one will.",
                                       "b) Stuff it in your mouth before he can stop you.", 
                                       "c) Offer to split it with him. After all, it's only a sweet cake.");

            //get character from user
            playerChoice = Console.ReadKey().KeyChar;
            //make sure user inputs a, b, or c
            checkInputOnBuildPlayer(ref playerChoice);
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
            checkInputOnBuildPlayer(ref playerChoice);
            //balance the stats
            buildPlayerStats(playerChoice);
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
            printStats();
        }

        /// <summary>
        /// Prints the stats of the player on a single line
        /// </summary>
        public void printStats()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write("Strength: " + Strength + "\tSpeed: " + Speed + "\tDefense: " + Defense + "\n");
        }
        
        private void checkInputOnBuildPlayer(ref char playerChoice)
        {
            //check user input (Can abstract this into a function later)
            while (playerChoice != 'a' && playerChoice != 'A' && playerChoice != 'b' && playerChoice != 'B'
                  && playerChoice != 'c' && playerChoice != 'C')
            {
                Console.Write("\nInvalid input. Please try again: ");
                playerChoice = Console.ReadKey().KeyChar;
            }
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
            Console.WriteLine("\n" + question + "\n");
            Console.WriteLine(answerA); //strength
            Console.WriteLine(answerB); //speed
            Console.WriteLine(answerC + "\n"); //defense
            Console.Write(">");
        }
        
    }

}

