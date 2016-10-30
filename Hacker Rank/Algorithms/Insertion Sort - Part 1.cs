using System;
using System.Collections.Generic;
using System.IO;
class Solution {
static void insertionSort(int[] ar) {
    int temp = ar[ar.Length - 1];
    
    for(int i = ar.Length - 2; i >= 0; i--){
        temp = ar[i+1];
        if(temp < ar[i]){
            ar[i+1] = ar[i];
            printAr(ar);
        }
    }
}
    
static void printAr(int[] ar){
    for(int i = 0; i < ar.Length - 1; i++){
        Console.Write(ar[i] + " ");
    }
    Console.WriteLine();
}
/* Tail starts here */
    static void Main(String[] args) {
           
           int _ar_size;
           _ar_size = Convert.ToInt32(Console.ReadLine());
           int [] _ar =new int [_ar_size];
           String elements = Console.ReadLine();
           String[] split_elements = elements.Split(' ');
           for(int _ar_i=0; _ar_i < _ar_size; _ar_i++) {
                  _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]); 
           }

           insertionSort(_ar);
    }
}
