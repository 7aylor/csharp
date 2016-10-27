using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        
        //create a line n times
        for(int i = 1; i <= n; i++){
            
            //build the line
            string line = "";
            
            //build the spaces
            for(int j = n; j > i; j--){
                line += " ";
            }
            
            //build the #s
            for(int j = 0; j < i; j++){
                line += "#";
            }
            
            //write the line to the console
            Console.WriteLine(line);
        }
    }
}
