using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        
        //size of array
        int n = Convert.ToInt32(tokens_n[0]);
        
        //num of rotations
        int k = Convert.ToInt32(tokens_n[1]);
        
        //num of queries
        int q = Convert.ToInt32(tokens_n[2]);
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
                
        //print elements by index
        for(int a0 = 0; a0 < q; a0++){
            
            //index of spot in new array after k rotations
            int m = Convert.ToInt32(Console.ReadLine());
            
            //if k is bigger than n, subtract the number of times n fits into k
            if(k > n){
                k = k - ((k / n) * n);
            }
            //if m - k is negative. m - k represents the shift the array went through after k rotations
            if(m - k < 0){
                //get the index of the sum of n and  (m - k)
                Console.WriteLine(a[n + (m - k)]);
            }
            else{
                //otherwise get the index of m - k
                Console.WriteLine(a[m - k]);
            }
        }
    }
}
