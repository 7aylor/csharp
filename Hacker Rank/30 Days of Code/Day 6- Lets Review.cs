using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = int.Parse(Console.ReadLine());
        
        for(int a = 0; a < n; a++){

            string userInput = Console.ReadLine();
            string even = "";
            string odd = "";

            for(int i = 0; i < userInput.Length; i++){
                if(i % 2 == 0){
                    even += userInput[i];
                }
                else{
                    odd += userInput[i];
                }
            }

            string newString = even + " " + odd;

            Console.WriteLine(newString);
        }
    }
}