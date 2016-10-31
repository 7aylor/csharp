using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        
        string[] tokens_s = Console.ReadLine().Split(' ');
        int s = Convert.ToInt32(tokens_s[0]); //left side of house
        int t = Convert.ToInt32(tokens_s[1]); //right side of house
        string[] tokens_a = Console.ReadLine().Split(' ');
        int a = Convert.ToInt32(tokens_a[0]); //location of apple tree on left
        int b = Convert.ToInt32(tokens_a[1]); //location of orange tree on right
        string[] tokens_m = Console.ReadLine().Split(' ');
        int m = Convert.ToInt32(tokens_m[0]); //number of apples
        int n = Convert.ToInt32(tokens_m[1]); //number of oranges
        string[] apple_temp = Console.ReadLine().Split(' ');
        int[] apple = Array.ConvertAll(apple_temp,Int32.Parse); //array of apples distance from apple tree
        string[] orange_temp = Console.ReadLine().Split(' ');
        int[] orange = Array.ConvertAll(orange_temp,Int32.Parse); //array of oranges distance from orange tree
        
        //count of apples and oranges that hit the house
        int appleHitHouse = 0;
        int orangeHitHouse = 0;
        
        //loop through all apples, check if current apple hit the house
        for(int i = 0; i < m; i++){
            int distFromApple = a + apple[i];
            if(distFromApple >= s && distFromApple <= t){
                appleHitHouse++;
            }
        }
        
        //loop through all oranges, check if current orange hit the house
        for(int i = 0; i < n; i++){
            int distFromOrange = b + orange[i];
            if(distFromOrange >= s && distFromOrange <= t){
                orangeHitHouse++;
            }
        }
        
        //print number of apples and oranges that hit the house
        Console.WriteLine(appleHitHouse);
        Console.WriteLine(orangeHitHouse);
    }
}
