using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string s = Console.ReadLine();
        
        //loop through string. If two characters next to eachother are the same, delete them re-loop
        for(int i = 0; i < s.Length - 1; i++){
            if(s[i] == s[i+1]){
                s = s.Remove(i, 2);
                i = -1;
            }
        }
        
        //if s is empty, print its empty, otherwise print s
        if(s.Equals("")){
            Console.WriteLine("Empty String");
        }
        else{
            Console.WriteLine(s);
        }
    }
}