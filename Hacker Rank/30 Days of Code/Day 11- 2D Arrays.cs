using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        //2D array
        int[][] arr = new int[6][];
        
        //set largest sum to smallest int value in case of negatives
        int largestSum = int.MinValue;
        
        //create 2D array from input strings
        for(int arr_i = 0; arr_i < 6; arr_i++){
           string[] arr_temp = Console.ReadLine().Split(' ');
           arr[arr_i] = Array.ConvertAll(arr_temp,Int32.Parse);
        }
        
        //loop through grid, get the sum of each I and check to see if the sum is bigger than the 
        //largest sum.
        for(int i = 1; i < 5; i++){
            for(int j = 1; j < 5; j++){
                int sumOfI = arr[i-1][j-1] + arr[i-1][j] + arr[i-1][j+1] + arr[i][j] +
                             arr[i+1][j-1] + arr[i+1][j] + arr[i+1][j+1];
                
                if(sumOfI > largestSum){
                    largestSum = sumOfI;
                }
            }
        }
        
        //print largest sum
        Console.WriteLine(largestSum);
    }
}
