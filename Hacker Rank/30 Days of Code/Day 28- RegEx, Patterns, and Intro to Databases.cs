using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int N = Convert.ToInt32(Console.ReadLine());
        
        //array of names with @gmail.com addresses
        string[] gmailNames = new string[N];
        
        for(int a0 = 0; a0 < N; a0++){
            //get array from each line separated by space
            string[] tokens_firstName = Console.ReadLine().Split(' ');
            
            //first name is the first element
            string firstName = tokens_firstName[0];
            
            //email address is the second element
            string emailID = tokens_firstName[1];
            
            //if the email address ends with @gmail.com, add to gmailNames array
            if(emailID.EndsWith("@gmail.com")){
                gmailNames[a0] = firstName;
            }
        }
        
        //sort gmailNames
        Array.Sort(gmailNames);
        
        //print the non-null, sorted names in gmailNames
        foreach(string name in gmailNames){
            if(name != null){
                Console.WriteLine(name);
            }
        }
    }
}
