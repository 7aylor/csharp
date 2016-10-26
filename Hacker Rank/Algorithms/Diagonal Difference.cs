using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] a = new int[n][];
        
        //total of left diag and right diag
        int leftToRightSum = 0;
        int rightToLeftSum = 0;
        
        for(int a_i = 0; a_i < n; a_i++){
           string[] a_temp = Console.ReadLine().Split(' ');
           a[a_i] = Array.ConvertAll(a_temp,Int32.Parse);
        }
        
        //loop through the array and add up the sums of of diag
        for(int i = 0; i < n; i++){
           leftToRightSum += a[i][i];
           rightToLeftSum += a[n - i - 1][i];
        }
        
        //right the absolutate value of the difference of the sum of diags to the screen
        Console.WriteLine(Math.Abs(leftToRightSum - rightToLeftSum));
    }
}
