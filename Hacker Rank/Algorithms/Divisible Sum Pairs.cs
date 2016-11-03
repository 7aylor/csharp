using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        
        //keep track of number of valid pairs
        int count = 0;
        
        //loop throug the array and add the numbers to see if they are divisible by k, 
        //if they are, increase count
        for(int i = 0; i < n; i++){
            for(int j = i; j < n; j++){
                if(((a[i] + a[j]) % k == 0) && (i != j)){
                    count++;
                }
            }
        }
        
        Console.WriteLine(count);
    }
}
