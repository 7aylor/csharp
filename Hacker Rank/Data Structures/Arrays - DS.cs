using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

	//Reverse a string given by the users
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        
		//Loop through half of array and swap
        for(int i = 0; i < n-i ; i++){
            int temp = arr[i];
            arr[i] = arr[n - i - 1];
            arr[n - i - 1] = temp;
        }
        
		//print reversed array
        for(int i = 0; i < n; i++)
            Console.Write(arr[i] + " ");
    }
}
