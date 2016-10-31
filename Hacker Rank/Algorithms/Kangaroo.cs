
 Domains
 Contests
 Rank
 Leaderboard
 Jobs
  7aylor  
 
All Domains  Algorithms  Implementation  Kangaroo
Badge Progress(Details)
Points: 171.00 Rank: 136358
Kangaroo
by wanbo
Problem
Submissions
Leaderboard
Discussions
Editorial
Submitted 4 hours ago • Score: 10.00 Status: Accepted
 Test Case #0
 Test Case #1
 Test Case #2
 Test Case #3
 Test Case #4
 Test Case #5
 Test Case #6
 Test Case #7
 Test Case #8
 Test Case #9
 Test Case #10
 Test Case #11
 Test Case #12
 Test Case #13
 Test Case #14
 Test Case #15
 Test Case #16
 Test Case #17
 Test Case #18
 Test Case #19
 Test Case #20
 Test Case #21
 Test Case #22
 Test Case #23
 Test Case #24
 Test Case #25
 Test Case #26
 Test Case #27
 Test Case #28
 Test Case #29

Submitted Code
Language: C#

 Open in editor

1
using System;
2
using System.Collections.Generic;
3
using System.IO;
4
using System.Linq;
5
class Solution {
6
​
7
    static void Main(String[] args) {
8
        string[] tokens_x1 = Console.ReadLine().Split(' ');
9
        int x1 = Convert.ToInt32(tokens_x1[0]); //kangaroo1 start pos
10
        int v1 = Convert.ToInt32(tokens_x1[1]); //kangaroo1 velocity  
11
        int x2 = Convert.ToInt32(tokens_x1[2]); //kangaroo2 start pos
12
        int v2 = Convert.ToInt32(tokens_x1[3]); //kangaroo2 velocity
13
        
14
        //if both the start position and velocity of one pair is less than the start position 
15
        //and velocity of the other pair, print no
16
        if(((x1 < x2) && (v1 < v2)) || ((x1 > x2) && (v1 > v2))){
17
            Console.WriteLine("NO");
18
        }
19
        else{
20
            //if the difference of start position mod the difference of velocities is 0, print yes
21
            if((v1 != v2) && ((x2 - x1) % (v1 - v2)) == 0){
22
                Console.WriteLine("YES");
23
            }
24
            //otherwise print no
25
            else{
26
                Console.WriteLine("NO");
27
            }
28
        }
29
    }
30
}
31
​
Join us on IRC at #hackerrank on freenode for hugs or bugs. 
Contest Calendar | Interview Prep | Blog | Scoring | Environment | FAQ | About Us | Support | Careers | Terms Of Service | Privacy Policy | Request a Feature
