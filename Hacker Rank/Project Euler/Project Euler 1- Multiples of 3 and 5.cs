using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            long n = Convert.ToInt32(Console.ReadLine());
            long a = (n - 1) / 3;
            long b = (n - 1) / 5;
            long c = (n - 1) / 15;
            
            long total = 3*(a*(a+1)/2)+5*(b*(b+1)/2)-15*(c*(c+1)/2);
            Console.WriteLine(total);
        }
    }
}
