using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Fighter
{
    class GameConstants
    {
        //height and width of the console window
        public const int WINDOW_WIDTH = 81;
        public const int WINDOW_HEIGHT = 30;

        //color of dialogue
        public const ConsoleColor DIALOGUE_COLOR = ConsoleColor.Yellow;

        //color when player hits enemy
        public const ConsoleColor PLAYER_HIT_COLOR = ConsoleColor.DarkGreen;

        //color when enemy hits player
        public const ConsoleColor ENEMY_HIT_COLOR = ConsoleColor.DarkRed;

        //Colors of Stats
        public const ConsoleColor STRENGTH_COLOR = ConsoleColor.Red;
        public const ConsoleColor SPEED_COLOR = ConsoleColor.Green;
        public const ConsoleColor DEFENSE_COLOR = ConsoleColor.Cyan;

        //defines the top position of the player navigation portion of the window
        public const int PLAYER_NAV_HEIGHT = 18;

        //Maximum length of player name
        public const int PLAYER_NAME_MAX_LENGTH = 10;
    }
}
