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
            int maxDifficult = 5;
            int difficulty = 3;
            int maxLength = 20;
            int score = 0;
            bool alive = true;
            char symbol = 'O';
            List<Coord> body = new List<Coord>();
            Direction direction;
            ConsoleColor color;
            Random randomDirection = new Random();

            /// <summary>
            /// Default contructor for player object. Creates the player and a random direction
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="color"></param>
            public Player(int x, int y, ConsoleColor color)
            {
                this.color = color;

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
                body.Add(new Coord(x, y));
            }
            #region//getters and setters
            public int X
            {
                get
                {
                    return body[0].X;
                }
                set
                {
                    body[0].X = value;
                }
            }
            public int Y
            {
                get
                {
                    return body[0].Y;
                }
                set
                {
                    body[0].Y = value;
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

            void eatApple()
            {
                if(body.Count < maxLength)
                {
                    Coord temp = new Coord(body.Last().X, body.Last().Y);
                    if (direction == Direction.up)
                    {
                        temp.Y++;
                        body.Add(temp);
                    }
                    else if (direction == Direction.down)
                    {
                        temp.Y--;
                        body.Add(temp);
                    }
                    else if (direction == Direction.left)
                    {
                        temp.X++;
                        body.Add(temp);
                    }
                    else if (direction == Direction.right)
                    {
                        temp.X--;
                        body.Add(temp);
                    }
                    temp = null;
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
                int head = body.Count - 1;
                if (level.LevelArray[body[head].X, body[head].Y] != ' ')
                {
                    if(level.LevelArray[body[head].X, body[head].Y] == apple.Symbol)
                    {
                        this.eatApple();
                        apple.spawnApple(level);
                    }
                    if (level.LevelArray[body[head].X, body[head].Y] == '|' || level.LevelArray[body[head].X, body[head].Y] == '=')
                    //   || level.LevelArray[body[0].X, body[0].Y] == symbol)
                    {
                        Console.Clear();
                        alive = false;
                        Console.WriteLine("You lose");
                    }
                }
            }

            void movePlayer()
            {
                int head = body.Count - 1;
                Coord temp = new Coord(body[head].X, body[head].Y);
                if (direction == Direction.up)
                {
                    body[0].Y--;
                }
                else if (direction == Direction.down)
                {
                    body[0].Y++;
                }
                else if (direction == Direction.left)
                {
                    body[0].X--;
                }
                else if (direction == Direction.right)
                {
                    body[0].X++;
                }

                for (int i = body.Count - 1; i > 0; i--)
                {
                    body[i] = temp;
                    if (i < body.Count - 1)
                    {
                        temp = body[i];
                    }
                    Console.SetCursorPosition(0, 24 + i);
                    Console.WriteLine(body[i].X + " " + body[i].Y + " Count: " + body.Count);
                }
            } 

            public void increaseDifficulty()
            {
                if(difficulty != maxDifficult)
                {
                    difficulty++;
                }
            }

            public void printPlayer(Level level, Apple apple)
            {
                Console.SetCursorPosition(body[0].X, body[0].Y);
                Console.Write(' ');
                //level.addElement(' ', body.Last().X, body.Last().Y, ConsoleColor.White);
                movePlayer();
                checkCollision(level, apple);
                Console.ForegroundColor = color;
                foreach (Coord c in body)
                {
                    Console.SetCursorPosition(c.X, c.Y);
                    Console.Write(symbol);
                    //level.addElement(symbol, c.X, c.Y, color);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            public void checkDirectionChange()
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if ((key == ConsoleKey.D || key == ConsoleKey.RightArrow) && (direction != Direction.left))
                    {
                        direction = Direction.right;
                    }
                    else if ((key == ConsoleKey.A || key == ConsoleKey.LeftArrow) && (direction != Direction.right))
                    {
                        direction = Direction.left;
                    }
                    else if ((key == ConsoleKey.W || key == ConsoleKey.UpArrow) && (direction != Direction.down))
                    {
                        direction = Direction.up;
                    }
                    else if ((key == ConsoleKey.S || key == ConsoleKey.DownArrow) && (direction != Direction.up))
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
                //player.checkCollision(level, apple);
                player.checkDirectionChange();
                apple.printApple();
                player.printPlayer(level, apple);
                //player.movePlayer();
                //player.printPlayer();
                if (player.Direction == Direction.up || player.Direction == Direction.down)
                {
                    Thread.Sleep(200 - (player.Difficulty * 10));
                }
                else
                {
                    Thread.Sleep(200 - (player.Difficulty * 20));
                }
            }

            ConsoleKey key = Console.ReadKey(true).Key;
            }
    }
}

