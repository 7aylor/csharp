using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */      int numTimes = int.Parse(Console.ReadLine());
        for(int a = 0; a < numTimes; a++){
            string s = Console.ReadLine();
            int i = 0;
            int delCount = 0;
            while(i < s.Length - 1){
                if(s[i] == s[i+1]){
                    s.Remove(i);
                    delCount++;
                    i = 0;
                }
            }
            Console.WriteLine(delCount);
        }
    }
}