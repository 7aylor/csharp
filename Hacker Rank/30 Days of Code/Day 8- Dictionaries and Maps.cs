using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = int.Parse(Console.ReadLine());
        Dictionary<string,string> phoneBook = new Dictionary<string, string>(n);
        for(int i = 0; i < n; i++){
            string[] line = Console.ReadLine().Split(' ');
            if(line[1].Length == 8){
                phoneBook.Add(line[0], line[1]);
            }
        }
        
        string searchName = "";
        while((searchName = Console.ReadLine()) != null){
            
            if(phoneBook.ContainsKey(searchName)){
                Console.WriteLine(searchName + "=" + phoneBook[searchName]);
            }
            else{
                Console.WriteLine("Not found");
            }
        }
    }
}