using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        enum MonthsOfTheYear
        {
            January, February, March, April, May,
            June, July, August, September, October, November, December
        };

        static void Main(string[] args)
        {
            int monthChoice = 0;
            MonthsOfTheYear thisYear = MonthsOfTheYear.January;

            do
            {
                Console.Write("Please enter 1-12 to choose a month: ");
                monthChoice = Convert.ToInt32(Console.ReadLine());
            } while (monthChoice < 1 || monthChoice > 12);

            switch (monthChoice)
            {
                case 2:
                    thisYear = MonthsOfTheYear.February;
                    break;
                case 3:
                    thisYear = MonthsOfTheYear.March;
                    break;
                case 4:
                    thisYear = MonthsOfTheYear.April;
                    break;
                case 5:
                    thisYear = MonthsOfTheYear.May;
                    break;
                case 6:
                    thisYear = MonthsOfTheYear.June;
                    break;
                case 7:
                    thisYear = MonthsOfTheYear.July;
                    break;
                case 8:
                    thisYear = MonthsOfTheYear.August;
                    break;
                case 9:
                    thisYear = MonthsOfTheYear.September;
                    break;
                case 10:
                    thisYear = MonthsOfTheYear.October;
                    break;
                case 11:
                    thisYear = MonthsOfTheYear.November;
                    break;
                case 12:
                    thisYear = MonthsOfTheYear.December;
                    break;
                default:
                    break;                    
            }

            Console.WriteLine("You have entered " + thisYear);

            Console.ReadKey();
        }
    }
}