using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scroller
{
    class Program
    {
        const ConsoleColor obstacleColor = ConsoleColor.Green;
        const int WIDTH = 64;
        const int HEIGHT = 16;
        enum Direction { up, down, left, right }

        class Coord
        {
            int x;
            int y;

            public Coord(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int X
            {
                get
                {
                    return this.x;
                }
                set
                {
                    this.x = value;
                }
            }
            public int Y
            {
                get
                {
                    return this.y;
                }
                set
                {
                    this.y = value;
                }
            }
        }

        class Player
        {
            Coord coord;
            int maxDifficult = 5;
            int difficulty = 3;
            int length;
            int maxLength = 20;
            int score = 0;
            bool alive = true;
            char symbol = 'O';
            List<Coord> body = new List<Coord>();
            Direction direction;
            ConsoleColor color;
            Random randomDirection = new Random();

            public Player(int x, int y, ConsoleColor color)
            {
                coord = new Coord(x, y);
                body.Add(coord);
                this.color = color;
                this.length = 1;

                int randResult = randomDirection.Next(4);

                switch (randResult)
                {
                    case 0:
                        direction = Direction.up;
                        break;
                    case 1:
                        direction = Direction.down;
                        break;
                    case 2:
                        direction = Direction.right;
                        break;
                    case 3:
                        direction = Direction.left;
                        break;
                }

                //displayScore();
            }
            #region//getters and setters
            public int X
            {
                get
                {
                    return this.coord.X;
                }
                set
                {
                    this.coord.X = value;
                }
            }
            public int Y
            {
                get
                {
                    return this.coord.Y;
                }
                set
                {
                    this.coord.Y = value;
                }
            }
            public int Difficulty
            {
                get
                {
                    return this.difficulty;
                }
            }
            public int Score
            {
                get
                {
                    return this.score;
                }
            }
            public Direction Direction
            {
                get
                {
                    return this.direction;
                }
            }
            public char Symbol
            {
                get
                {
                    return this.symbol;
                }
            }
            public ConsoleColor Color
            {
                get
                {
                    return this.color;
                }
                set
                {
                    this.color = value;
                }
            }
            public int Length
            {
                get
                {
                    return this.length;
                }
                set
                {
                    this.length = value;
                }
            }

            public bool Alive
            {
                get
                {
                    return this.alive;
                }
                set
                {
                    this.alive = value;
                }
            }
            #endregion

            public void eatApple()
            {
                if(length != maxLength)
                {
                    length++;
                    body.Add(new Coord(coord.X, coord.Y));
                }
                score += 10;
                displayScore();
            }

            public void displayScore()
            {
                Console.SetCursorPosition(0, HEIGHT + 1);
                Console.Write("Score: " + score);
            }

            public void checkCollision(Level level, Apple apple)
            {
                if(level.LevelArray[coord.X, coord.Y] != ' ')
                {
                    if(level.LevelArray[coord.X, coord.Y] == apple.Symbol)
                    {
                        this.eatApple();
                        apple.spawnApple(level);
                    }
                    if (level.LevelArray[coord.X, coord.Y] == '|' || level.LevelArray[coord.X, coord.Y] == '=')
                    //   || level.LevelArray[coord.X, coord.Y] == symbol)
                    {
                        Console.Clear();
                        alive = false;
                        Console.WriteLine("You lose");
                    }
                }
            }

            public void movePlayer()
            {
                if (direction == Direction.up)
                {
                    coord.Y--;
                    foreach(Coord c in body)
                    {
                        c.Y--;
                    }
                }
                else if (direction == Direction.down)
                {
                    coord.Y++;
                    foreach (Coord c in body)
                    {
                        c.Y++;
                    }
                }
                else if (direction == Direction.left)
                {
                    coord.X--;
                    foreach (Coord c in body)
                    {
                        c.X--;
                    }
                }
                else if (direction == Direction.right)
                {
                    coord.X++;
                    foreach (Coord c in body)
                    {
                        c.X++;
                    }
                }
            } 

            public void increaseDifficulty()
            {
                if(difficulty != maxDifficult)
                {
                    difficulty++;
                }
            }

            public void printPlayer()
            {
                if(direction == Direction.up)
                {
                    Coord temp;
                    temp = body.Last();
                    Console.SetCursorPosition(temp.X, temp.Y + 1);
                    Console.Write(' ');
                    temp = null;
                }
                if (direction == Direction.down)
                {
                    Coord temp;
                    temp = body.Last();
                    Console.SetCursorPosition(temp.X, temp.Y - 1);
                    Console.Write(' ');
                    temp = null;
                }
                if (direction == Direction.left)
                {
                    Coord temp;
                    temp = body.Last();
                    Console.SetCursorPosition(temp.X + 1, temp.Y);
                    Console.Write(' ');
                    temp = null;
                }
                if (direction == Direction.right)
                {
                    Coord temp;
                    temp = body.Last();
                    Console.SetCursorPosition(temp.X - 1, temp.Y);
                    Console.Write(' ');
                    temp = null;
                }
                Console.SetCursorPosition(coord.X, coord.Y);
                Console.ForegroundColor = color;
                Console.Write(symbol);
                Console.ForegroundColor = ConsoleColor.White;
            }

            public void checkDirectionChange()
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
                    {
                        direction = Direction.right;
                    }
                    else if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                    {
                        direction = Direction.left;
                    }
                    else if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                    {
                        direction = Direction.up;
                    }
                    else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                    {
                        direction = Direction.down;
                    }
                }
            }

        }

        class Apple
        {
            int x;
            int y;
            char symbol = '*';
            ConsoleColor color;
            Random locX = new Random();
            Random locY = new Random();

            public Apple(int x, int y, ConsoleColor color)
            {
                this.x = x;
                this.y = y;
                this.color = color;
            }

            #region//getters and setters
            public int X
            {
                get
                {
                    return this.x;
                }
                set
                {
                    this.x = value;
                }
            }
            public int Y
            {
                get
                {
                    return this.y;
                }
                set
                {
                    this.y = value;
                }
            }
            public char Symbol
            {
                get
                {
                    return this.symbol;
                }
            }
            public ConsoleColor Color
            {
                get
                {
                    return this.color;
                }
                set
                {
                    this.color = value;
                }
            }
            #endregion

            public void spawnApple(Level level)
            {
                this.x = locX.Next(1, WIDTH - 1);
                this.y = locY.Next(1, HEIGHT - 1);
                level.LevelArray[x, y] = this.Symbol;
                printApple();
            }

            public void printApple()
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = color;
                Console.Write(symbol);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        class Level
        {
            char[,] level = new char[WIDTH, HEIGHT];

            public Level()
            {
                //build top row
                for (int i = 1; i < WIDTH - 1; i++)
                {
                    level[i, 0] = '=';
                }

                //sides
                for (int i = 0; i < HEIGHT; i++)
                {
                    level[0, i] = '|';
                    level[WIDTH - 1, i] = '|';
                }


                //build bottom row
                for (int i = 1; i < WIDTH - 1; i++)
                {
                    level[i, HEIGHT - 1] = '=';
                }
            }

            public char[,] LevelArray
            {
                get
                {
                    return this.level;
                }
            }

            public void printLevel(Player player, Apple apple)
            {
                for (int i = 0; i < HEIGHT; i++)
                {
                    for (int j = 0; j < WIDTH; j++)
                    {
                        if(level[j, i] == player.Symbol)
                        {
                            Console.ForegroundColor = player.Color;
                            Console.Write(this.level[j, i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (level[j, i] == apple.Symbol)
                        {
                            Console.ForegroundColor = apple.Color;
                            Console.Write(this.level[j, i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write(this.level[j, i]);
                        }
                    }
                    Console.Write('\n');
                }
            }

            public void addElement(char element, int x, int y, ConsoleColor color)
            {
                level[x, y] = element;
                //Console.ForegroundColor = color;
                //Console.SetCursorPosition(x, y);
                //Console.Write(element);
                //Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Level level = new Level();
            Player player = new Player(WIDTH / 2, HEIGHT / 2, ConsoleColor.Green);
            Apple apple = new Apple(10, 10, ConsoleColor.Red);

            level.addElement(player.Symbol, player.X, player.Y, player.Color);
            level.addElement(apple.Symbol, apple.X, apple.Y, apple.Color);


            //buildLevel(ref level);
            //printLevel(level, player.x, player.y);
            //addElement(ref level, APPLE, 10, 10, ConsoleColor.Green);
            //addElement(ref level, APPLE, 10, 10, ConsoleColor.Green);

            //Timer t = new Timer(callBackTimer, player, 0, 1000);

            level.printLevel(player, apple);
            //player.increaseDifficulty();


            while (player.Alive)
            {
                apple.printApple();
                player.printPlayer();
                player.checkCollision(level, apple);
                player.checkDirectionChange();
                player.movePlayer();
                if(player.Direction == Direction.up || player.Direction == Direction.down)
                {
                    Thread.Sleep(500 - (player.Difficulty * 10));
                }
                else
                {
                    Thread.Sleep(500 - (player.Difficulty * 20));
                }
            }

            ConsoleKey key = Console.ReadKey(true).Key;
            #region //presses
            /*
            while (key != ConsoleKey.X)
            {
                if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
                {
                    goRight(ref level, ref player.x, player.y);
                }
                if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                {
                    goLeft(ref level, ref player.x, player.y);
                }
                if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                {
                    goUp(ref level, player.x, ref player.y);
                }
                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                {
                    goDown(ref level, player.x, ref player.y);
                }

                if (player.x == 10 && player.y == 10)
                {
                    player.eat();
                }
                */
                key = Console.ReadKey(true).Key;
            }

        #endregion
        #region//oldcode
        /*
        static void goRight(ref char[,] level, ref int x, int y)
        {
            if (x < WIDTH - 2 && !checkObstacle(level, x + 1, y))
            {
                x++;
                level[x - 1, y] = ' ';
                Console.SetCursorPosition(x - 1, y);
                Console.Write(' ');

                Console.ForegroundColor = ConsoleColor.Red;
                level[x, y] = PLAYER;
                Console.SetCursorPosition(x, y);
                Console.Write(PLAYER);
            }
        }

        static void goLeft(ref char[,] level, ref int x, int y)
        {
            if (x > 1 && !checkObstacle(level, x - 1, y))
            {
                x--;
                level[x + 1, y] = ' ';
                Console.SetCursorPosition(x + 1, y);
                Console.Write(' ');

                Console.ForegroundColor = ConsoleColor.Red;
                level[x, y] = PLAYER;
                Console.SetCursorPosition(x, y);
                Console.Write(PLAYER);
            }
        }

        static void goUp(ref char[,] level, int x, ref int y)
        {
            if (y > 1 && !checkObstacle(level, x, y - 1))
            {
                y--;
                level[x, y + 1] = ' ';
                Console.SetCursorPosition(x, y + 1);
                Console.Write(' ');

                Console.ForegroundColor = ConsoleColor.Red;
                level[x, y] = PLAYER;
                Console.SetCursorPosition(x, y);
                Console.Write(PLAYER);
            }
        }

        static void goDown(ref char[,] level, int x, ref int y)
        {
            if (y < HEIGHT - 2 && !checkObstacle(level, x, y + 1))
            {
                y++;
                level[x, y - 1] = ' ';
                Console.SetCursorPosition(x, y - 1);
                Console.Write(' ');

                level[x, y] = PLAYER;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x, y);
                Console.Write(PLAYER);
            }
        }

        static bool checkObstacle(char[,] level, int x, int y)
        {
            if (level[x, y] == '|' || level[x, y] == '-' || level[x, y] == '_' || level[x, y] == '=')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
        #endregion

    }
}

