using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrogRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Number of frogs in the race
            int numFrogs = 5;

            //create a list of threads that represent the frogs racing
            List<Thread> frogs = new List<Thread>(numFrogs);

            //create each new thread, start the thread, and add it to the frogs list
            for(int i = 0; i < numFrogs; i++)
            {
                //use FrogRace as method delegate
                Thread thread = new Thread(FrogRace);
                thread.Start(i + 1);
                frogs.Add(thread);
            }

            //go through the threads and wait for each of them to finished before moving on
            foreach(Thread thread in frogs)
            {
                thread.Join();
            }

            Console.WriteLine("The race has finished!");
            Console.ReadLine();
        }

        //creates random number
        public static Random rand = new Random();

        //FrogRace used for each thread to randomly have a pause between jumps
        public static void FrogRace(object frogNum)
        {
            //cast object to int
            int frog = (int)frogNum;

            //loop through ten jumps
            for(int i = 0; i < 10; i++)
            {
                //write the frog jumped and sleep between jumps
                Console.WriteLine("Frog " + frogNum + " jumped.");
                Thread.Sleep(rand.Next(1000));
            }

            //write when frog finished jumping ten times
            Console.WriteLine("Frog " + frogNum + " finished!");
        }
    }
}
