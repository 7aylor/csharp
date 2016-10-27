using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        //Read input
        string time = Console.ReadLine();
        
        //get the string not couting hours and PM or AM
        string shortTime = time.Substring(2,6);
        
        //if its PM and not 12, add 12 to the hours
        if(time[8].Equals('p') || time[8].Equals('P') && time.Substring(0,2) != "12"){
            int hour = int.Parse(time.Substring(0,2));
            hour += 12;
            time = hour.ToString() + shortTime;
        }
        //if its am and its 12, make it 00
        else if((time[8].Equals('a') || time[8].Equals('A')) && time.Substring(0,2) == "12"){
            time = "00" + shortTime;
        }
        //otherwise, time without AM or PM
        else{
            time = time.Substring(0, 8);
        }
        //print time
        Console.WriteLine(time);
    }
}
