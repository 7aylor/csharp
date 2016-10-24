using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        //get number of numbers to test
        int numTimes = int.Parse(Console.ReadLine());
        
        //loop through each number and test if its prime
        for(int i = 0; i < numTimes; i++){
            long num = long.Parse(Console.ReadLine());
            Console.WriteLine(isPrime(num));
        }
    }
    
    static string isPrime(long num){
        //if its even, it is not prime
        if(num == 1){
            return "Not prime";
        }
        if(num == 2){
            return "Prime";
        }
        if(num % 2 == 0){
            return "Not prime";
        }
        
        //Get square root of number
        long sqr = (long)Math.Sqrt(num);
        
        //loop through numbers starting at 2 up to square root of num
        for(long i = 2; i <= sqr; i++){
            
            //if num is divisible by these odd numbers, its not prime
            if(num % i == 0){
                return "Not prime";
            }
        }
        
        //otherwise, its prime
        return "Prime";
    }
}