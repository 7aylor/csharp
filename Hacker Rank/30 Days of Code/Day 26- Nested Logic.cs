using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        //get the returned date
        string returned = Console.ReadLine();
        
        //get the date it was supposed to be returned
        string returnDate = Console.ReadLine();
        
        //split that string into an array of strings
        string[] retString = returned.Split(' ');
        string[] dueString = returnDate.Split(' ');
        
        //array for nums that are day, month, year
        int[] retNums = new int[3];
        int[] dueNums = new int[3];
        
        //convert strings arrays to int arrays
        for(int i = 0; i < 3; i++){
            retNums[i] = int.Parse(retString[i]);
            dueNums[i] = int.Parse(dueString[i]);
        }
        
        //total fine
        int fine = 0;

        //if the return year is less than the due year, there is no fine
        if(retNums[2] < dueNums[2]){
            fine = 0;
        }
        else{
            //if the return year is greater than the due year, fine is 10000
            if(retNums[2] > dueNums[2]){
                fine = 10000;
            }
            //if the return month is in the same year but greater than the due month, multiply the 
            //difference of the months by 500
            else if(retNums[1] > dueNums[1]){
                fine = 500 * (retNums[1] - dueNums[1]);
            }
            //if the return month is in the same month, but the return day is greater than the due day,
            //multiply the difference of the days by 15
            else if(retNums[0] > dueNums[0]){
                fine = 15 * (retNums[0] - dueNums[0]);
            }
        }              
        Console.WriteLine(fine);
    }
}