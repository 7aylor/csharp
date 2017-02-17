using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Hero
    {
        //int strength;
        //int intelligence;
        int health;
        int speed; //helps determine who goes first in a battle
        int attack;
        int defense;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="health"></param>
        /// <param name="speed"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// 
        public Hero(int health, int speed, int attack, int defense)
        {
            //this.strength = strength;
            //this.intelligence = intelligence;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.defense = defense;
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
            get;
            set;
        }

        public int Attack
        {
            get;
            set;
        }

        public int Defense
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enemy"></param>
        public void inflictDamage(Hero enemy)
        {
            enemy.health -= this.attack;
        }
    }
}
