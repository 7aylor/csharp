using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(factorial(n));
    }
    
    static int factorial(int num){
        if(num == 1){
            return 1;
        }
        else{
            return num * factorial(num - 1);
        }
    }
}