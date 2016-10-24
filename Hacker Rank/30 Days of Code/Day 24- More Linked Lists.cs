  public static Node removeDuplicates(Node head){
    //Write your code here
      //set to keep track of which data has been used (sets only contain unique data)
      HashSet<int> set = new HashSet<int>();
      
      //add first Node's data to set
      set.Add(head.data);
      
      //curr keeps track of current Node
      Node curr = head;
      
      //currNext keeps track of next Node
      Node currNext = curr.next;
      
      //While there is a next Node
      while(currNext != null){
          
          //if the next Node's data is not in the set, add it and set current Node to next Node
          if(!set.Contains(currNext.data)){
              set.Add(currNext.data);
              curr = currNext;
          }
          //otherwise, our current Node's next Node, should skip our current Next Node
          else{
              curr.next = currNext.next;
          }
          
          //set the current next to its next Node
          currNext = currNext.next;
      }
      
      //return the head Node of our linked list
      return head;
  }