using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            long n = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine(getFibNums(n).ToString());
        }
    }
    
    static long getFibNums(long limit){
        List<long> fibs = new List<long>();
        fibs.Add(1);
        fibs.Add(1);
        long evenTotal = 0;
        long lastFib = fibs[fibs.Count - 1];
        while(lastFib < limit){
            long nextFib = fibs[fibs.Count - 1] + fibs[fibs.Count - 2]; 
            fibs.Add(nextFib);
            lastFib = nextFib;
            if(nextFib % 2 == 0){
                evenTotal += nextFib;
            }
        }
        if(lastFib > limit){
            fibs.RemoveAt(fibs.Count - 1);
            if(lastFib % 2 == 0){
                evenTotal -= lastFib;
            }
        }
        
        return evenTotal;
    }
}
