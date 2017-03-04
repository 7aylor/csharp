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
        /// NPC Base constructor
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
        /// NPC Constructor, overrides base constructor for villager type character
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
            this.initStats();
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
        public void setHealthFromMaxStat()
        {
            int max = 0;

            for (int i = 0; i < 3; i++)
            {
                if (this.speed > max)
                {
                    max = this.speed;
                }
                if (this.strength > max)
                {
                    max = this.strength;
                }
                if (this.defense > max)
                {
                    max = this.defense;
                }
            }

            this.health = 50 + (max * 5);
        }

        public void initStats()
        {
            Random rand = new Random();
            int randomNum = 0;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1);
                randomNum = rand.Next(3);
                if(randomNum == 0 && this.defense > 1)
                {
                    this.strength++;
                    this.defense--;
                }
                if (randomNum == 1 && this.strength > 1)
                {
                    this.speed++;
                    this.strength--;
                }
                if (randomNum == 2 && this.speed > 1)
                {
                    this.defense++;
                    this.speed--;
                }
            }
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

        public Player(string name, PlayerType type) : base(name, type)
        {
            this.gold = 10;
            this.rank = 1;
            this.actionPoints = 10;
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

        //Method for player to choose stats
    }

}

