using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{
    interface ICharacter
    {
        string Name
        {
            get;
            set;
        }
    }

    interface IFighter : ICharacter
    {
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

    interface IPlayer : IFighter
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
    /// Villager Class
    /// </summary>
    class Villager : ICharacter
    {
        string name;
        //location

        /// <summary>
        /// Villager Constructor
        /// </summary>
        /// <param name="name"></param>
        public Villager(string name)
        {
            this.name = name;
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
        #endregion
    }

    /// <summary>
    /// Fighter Class, inherits from Villager
    /// </summary>
    class Fighter : IFighter
    {
        string name;
        int health;
        int speed;
        int strength;

        /// <summary>
        /// Fighter Constructor inherits from Villager Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="speed"></param>
        /// <param name="strength"></param>
        public Fighter(string name, int health, int speed, int strength)
        {
            this.name = name;
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
            set
            {
                this.name = value;
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
    /// Player Class, inherits from Fighter 
    /// </summary>
    class Player : Fighter, IPlayer
    {
        int gold;
        int rank;
        int actionPoints;

        public Player(string name, int health, int speed, int strength, int gold, int rank, int actionPoints) 
            : base(name, health, speed, strength)
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

