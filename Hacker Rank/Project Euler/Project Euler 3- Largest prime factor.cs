using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            long n = Convert.ToInt64(Console.ReadLine());
            long largestPrime = 2;
            
            //Loop through odds up to square root of n
            for(long i = 3 ; i <= Math.Sqrt(n); i+=2){
                //while n is divisible by 2, keep dividing it by 2
                while(n % 2 == 0){
                    n = n / 2;
                }
                
                //while n is divisible by i, keep dividing it by i
                while(n % i == 0){
                    n = n / i;
                }
                //if n is still greater than 2, it is the biggest prime
                if(n > 2){
                    largestPrime = n;
                }
                
                //otherwise, i is the biggest prime
                else{
                    largestPrime = i;
                }
            }
            //print the largest prime
            Console.WriteLine(largestPrime);
        }
    }
}
