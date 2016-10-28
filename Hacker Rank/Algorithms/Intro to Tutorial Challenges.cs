using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        //get input for V, array length, and the int array
        int V = int.Parse(Console.ReadLine());
        int arrLength = int.Parse(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        
        //loop through array and check if V is equal to the value of the current item in arr
        for(int i = 0; i < arrLength; i++){
            if(V == arr[i]){
                //print value and exit loop
                Console.WriteLine(i);
                break;
            }
        }
    }
}