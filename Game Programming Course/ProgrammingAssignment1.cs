using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tell users purpose of program
            Console.WriteLine("\t*************It's All Greek to Me!*************\n\n");
            Console.WriteLine("Input: two sets of x and y coordinates representing points.");
            Console.WriteLine("Output: the angle and distance between the two points\n\n");
            Console.WriteLine("Please Input the first x and y pair");

            //get x1 and check that it has good input
            Console.Write("First X: ");
            string userIn = Console.ReadLine();
            double x1 = checkInput(userIn);

            //get y1 and check that it has good input
            Console.Write("First Y: ");
            userIn = Console.ReadLine();
            double y1 = checkInput(userIn);

            //print out the first point's coordinates, then prompt for the next
            Console.WriteLine("First Pair: ({0}, {1})\n", x1, y1);
            Console.WriteLine("Please Input the second x and y pair");

            //get x2 and check that it has good input
            Console.Write("Second X: ");
            userIn = Console.ReadLine();
            double x2 = checkInput(userIn);

            //get y2 and check that it has good input
            Console.Write("Second Y: ");
            userIn = Console.ReadLine();
            double y2 = checkInput(userIn);

            //print out the second point's coordinates
            Console.WriteLine("Second Pair: ({0}, {1})\n", x2, y2);

            //calculate distance and angle between points and print results
            Console.WriteLine("Distance between points: " + DistanceBetweenPoints(x1, y1, x2, y2));
            Console.WriteLine("Angle between points: " + AngleBetweenPoints(x1, y1, x2, y2));

            //prompt user to press a key to exit
            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }

        //check the user input and ensure that its a double, otherwise the user has to try again
        static double checkInput(string input)
        {
            double output;
            while(!double.TryParse(input, out output))
            {
                Console.Write("Incorrect input, please try again: ");
                input = Console.ReadLine();
            }

            return output;
        }

        //caclulate distance between points
        static double DistanceBetweenPoints(double x1, double y1, double x2, double y2)
        {
            return Math.Round(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y2 - y1, 2)), 3);
        }

        //calculate angle between points
        static double AngleBetweenPoints(double x1, double y1, double x2, double y2)
        {
            return Math.Round((Math.Atan2((y2 - y1), (x2 - x1)) * 180 / Math.PI), 3);
        }

    }
}
