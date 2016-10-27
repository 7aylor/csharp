using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        
        int pos = 0;
        int zero = 0;
        int neg = 0;
        int total = arr.Length;
        
        //count number of pos, neg, zero
        for(int i = 0; i < total; i++){
            if(arr[i] < 0){
                neg++;
            }
            else if(arr[i] > 0){
                pos++;
            }
            else{
                zero++;
            }
        }
        
        //Print Positive percent, Negative, and zero
        Console.WriteLine(Math.Round((double)pos/total, 6));
        Console.WriteLine(Math.Round((double)neg/total, 6));
        Console.WriteLine(Math.Round((double)zero/total, 6));
        
    }
}

