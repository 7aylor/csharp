using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        //number of days, number of ads spread starting at 5, number of likes this day, 
        //and number of total Likes
        int days = int.Parse(Console.ReadLine());
        int adsSpread = 5;
        int likes = 0;
        int totalLikes = 0;
        
        //loop through days, get the likes for that day with formula, add likes total likes, get 
        //num adsSpread for tomorrow
        for(int i = 0; i < days; i++){
            likes = Convert.ToInt32(Math.Floor(adsSpread/2.0));
            totalLikes += likes;
            adsSpread = likes * 3;
        }
        
        //write out total number of likes
        Console.WriteLine(totalLikes);
    }
}