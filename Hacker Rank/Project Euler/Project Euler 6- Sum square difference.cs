using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            long n = Convert.ToInt64(Console.ReadLine());
            long sumNums = 0;
            long squareSumNums = 0;
            for(long i = n; i > 0; i--){
                sumNums += i;
                squareSumNums += i * i; 
            }
            sumNums = sumNums * sumNums;
            long difference = sumNums - squareSumNums;
            Console.WriteLine(difference);
            
        }
    }
}
