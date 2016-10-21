using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieRolling
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = false;
            do {
                int diceNum = 0;
                int numSides = 6;
                int total = 0;
                char letter = ' ';
                Console.Clear();
                Console.WriteLine("\t\t\t***Dice Sum***");
                Console.Write("Number of Dice: ");
                int.TryParse(Console.ReadLine(), out diceNum);
                Console.Write("Number of Sides: ");
                int.TryParse(Console.ReadLine(), out numSides);
                Random rand = new Random();

                for (int i = 0; i < diceNum; i++)
                {
                    total += rand.Next(numSides);
                }

                Console.WriteLine("Sum of rolls after {0} rolls with {1} sided die: {2}", diceNum, numSides, total);
                Console.Write("Play again? (y/n)");
                char.TryParse(Console.ReadLine(), out letter);
                if (letter == 'y' || letter == 'Y')
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }

            }while(playAgain == true);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
