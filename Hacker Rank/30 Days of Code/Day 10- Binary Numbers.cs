using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
       //stack to hold 1s and 0s
        Stack<string> binaryStack = new Stack<string>();
        
        //longest streak of 1s in a row
        int longestStreak = 0;
        
        //temp holder for longest streak
        int currentStreak = 0;
        
        //divide n by two and get the remainder to determine the binary string
        //push each remainder onto the stack to create the binary string
        while(n > 0){
            string remainder = Convert.ToString(n%2);
            n = n/2;
            binaryStack.Push(remainder);
        }
        
        //length of binary stack used for loop
        int length = binaryStack.Count;
        
        //loop through the stack, pop the top off and check if it is a 1
        //if it is, increase the current streak. if the current streak is
        //longer than the longest streak, set longest streak to current streak
        //Otherwise, current streak is set back to 0
        for(int i = 0; i < length; i++){
            if(binaryStack.Pop().Equals("1")){
                currentStreak++;
                if(currentStreak > longestStreak){
                    longestStreak = currentStreak;
                }
            }
            else{
                currentStreak = 0;
            }
        }
        
        //output longest streak to console
        Console.WriteLine(longestStreak);
    }
}
