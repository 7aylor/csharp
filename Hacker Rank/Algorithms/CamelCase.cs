using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string s = Console.ReadLine();
        //count of words, starts at one for first word
        int words = 1;
        
        //loop through letters
        for(int i = 0; i < s.Length; i++){
            //if there is an uppercase, words++
            if(char.IsUpper(s[i])){
                words++;
            }
        }
        //write number of words
        Console.WriteLine(words);
    }
}
