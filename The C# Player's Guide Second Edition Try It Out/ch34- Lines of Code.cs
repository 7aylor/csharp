using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinesOfCode
{
    public static class StringExtension
    {
        public static int LineCount(this string s)
        {
            //split string by newline
            string[] lines = s.Split('\n');

            //counter of blank lines
            int blankCount = 0;

            //loop through lines
            for(int i = 0; i < lines.Length; i++)
            {
                //replace space, tab, and new lines charactes with ""
                lines[i] = lines[i].Replace(" ", "");
                lines[i] = lines[i].Replace("\t", "");
                lines[i] = lines[i].Replace("\n", "");

                //increase number of blank lines if line is ""
                if (lines[i].Equals(""))
                {
                    blankCount++;
                }
            }

            //return length of array minus blank lines
            return lines.Length - blankCount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //read file path, then print count of lines
            Console.WriteLine("*****Lines of Code Counter*****\n");
            Console.Write("Filepath: ");
            string filePath = Console.ReadLine(); 
            string file = File.ReadAllText(filePath);
            
            Console.ReadKey();
        }
    }
}
