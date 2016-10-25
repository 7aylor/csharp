using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_a0 = Console.ReadLine().Split(' ');
        int a0 = Convert.ToInt32(tokens_a0[0]);
        int a1 = Convert.ToInt32(tokens_a0[1]);
        int a2 = Convert.ToInt32(tokens_a0[2]);
        string[] tokens_b0 = Console.ReadLine().Split(' ');
        int b0 = Convert.ToInt32(tokens_b0[0]);
        int b1 = Convert.ToInt32(tokens_b0[1]);
        int b2 = Convert.ToInt32(tokens_b0[2]);
        
        int AliceScore = 0;
        int BobScore = 0;
        
        compare(a0, b0, ref AliceScore, ref BobScore);
        compare(a1, b1, ref AliceScore, ref BobScore);
        compare(a2, b2, ref AliceScore, ref BobScore);
        
        Console.WriteLine(AliceScore + " " + BobScore);
        
    }
    
    static void compare(int a, int b, ref int aScore, ref int bScore){
        if(a > b){
            aScore++;
        }
        else if(b > a){
            bScore++;
        }
    }
}
