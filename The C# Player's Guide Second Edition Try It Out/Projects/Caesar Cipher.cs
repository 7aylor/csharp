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
            //welcome to the Caesar Cipher!
            Console.WriteLine("\t\t*****Welcome to Caesar's Cipher*****\n\n");
            Console.Write("To Encrypt a message, press 1. To Decrypt a message, press 2: ");

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
            Console.Write("What is the key? ");
            choiceString = Console.ReadLine();

            int key;

            //check input and if its good, convert to an integer
            while (!Int32.TryParse(choiceString, out key))
            {
                Console.WriteLine("Not a valid number, try again.");
                choiceString = Console.ReadLine();
            }

            //prompt to use a file instead of console
            Console.Write("Read from file? (y/n): ");
            choiceString = Console.ReadLine();

            char fileChar;

            //check input and if its good, convert to char
            while(!Char.TryParse(choiceString, out fileChar) && (fileChar != 'y' || fileChar != 'n'))
            {
                Console.WriteLine("Please type y for yes or n for no");
                choiceString = Console.ReadLine();
            }

            if (choice == 1)
            {
                if(fileChar == 'y')
                {
                    Encrypt(key, true);
                }
                else
                {
                    Encrypt(key, false);
                }
                
            }
            if(choice == 2)
            {
                if (fileChar == 'y')
                {
                    Decrypt(key, true);
                }
                else
                {
                    Decrypt(key, false);
                }
            }

            //wait to close for user interaction
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();   
        }

        static void Encrypt(int key, bool file)
        {

        }

        static void Decrypt(int key, bool file)
        {

        }
    }
}
