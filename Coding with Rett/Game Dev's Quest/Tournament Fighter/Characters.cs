using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{
    enum PlayerType { Villager, Fighter, Player };

    /// <summary>
    /// INPC Interface
    /// </summary>
    interface INPC
    {
        string Name
        {
            get;
        }

        string Occupation
        {
            get;
        }

        int Health
        {
            get;
            set;
        }

        int Speed
        {
            get;
            set;
        }

        int Strength
        {
            get;
            set;
        }
    }

    /// <summary>
    /// IPlayer interface, inherits from INPC interface
    /// </summary>
    interface IPlayer : INPC
    {
        int Gold
        {
            get;
            set;
        }

        int Rank
        {
            get;
            set;
        }

        int ActionPoints
        {
            get;
            set;
        }
    }

    /// <summary>
    /// NPC Class
    /// </summary>
    class NPC : INPC
    {
        string name;
        string occupation;
        int health;
        int speed;
        int strength;
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
        public NPC(string name, PlayerType type, int health, int speed, int strength)
        {
            this.name = name;
            this.type = type;
            this.health = health;
            this.speed = speed;
            this.strength = strength;
        }

        #region //getters and setters
        public string Name
        {
            get
            {
                return this.name;
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
        #endregion

        //methods
    }

    /// <summary>
    /// Player Class, inherits from NPC
    /// </summary>
    class Player : NPC, IPlayer
    {
        int gold;
        int rank;
        int actionPoints;

        public Player(string name, PlayerType type ,int health, int speed, int strength, int gold, int rank, int actionPoints) 
            : base(name, type, health, speed, strength)
        {
            this.gold = gold;
            this.rank = rank;
            this.actionPoints = actionPoints;
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
    }

}

