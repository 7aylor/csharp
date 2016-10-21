using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i = 1; i <= 10; i++){
            int mult = i * n;
            Console.WriteLine("{0} x {1} = {2}", n, i, mult);
        }
    }
}
