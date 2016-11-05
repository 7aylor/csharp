using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //prompt user
            Console.WriteLine("\t\t*****Welcome to Caesar's Cipher*****\n\n");
            Console.Write("To Encrypt a message, press 1. To Decrypt a message, press 2:");

            //choice of encryption or decryption
            int choice;

            //read their choice
            String choiceString = Console.ReadLine();

            //check their input and if its good, convert to an integer
            while (!Int32.TryParse(choiceString, out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("Not a valid number, try again.");

                choiceString = Console.ReadLine();
            }

            //prompt for encryption key
            Console.WriteLine("What is the key?");
            choiceString = Console.ReadLine();

            int key;

            //check input and if its good, convert to an integer
            while (!Int32.TryParse(choiceString, out key) || key < 1 || key > 2)
            {
                Console.WriteLine("Not a valid number, try again.");

                choiceString = Console.ReadLine();
            }

            if (choice == 1)
            {
                Encrypt(key);
            }
            if(choice == 2)
            {
                Decrypt(key);
            }

            //wait to close for user interaction
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();   
        }

        static void Encrypt(int key)
        {

        }

        static void Decrypt(int key)
        {

        }
    }
}
