using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        
        //Number of swaps
        int swapCount = 0;
        
        //Use Bubble Sort
        for(int i = 0; i < n; i++){
            
            for(int j = 0; j < n - 1; j++){
                if(a[j] > a[j+1]){
                    int temp = a[j];
                    a[j] = a[j+1];
                    a[j+1] = temp;
                    swapCount++;
                }
            }
        }
        
        //Print number of swaps, first and last elements
        Console.WriteLine("Array is sorted in {0} swaps.", swapCount);
        Console.WriteLine("First Element: {0}", a[0]);
        Console.WriteLine("Last Element: {0}", a[a.Length-1]);
    }
}
