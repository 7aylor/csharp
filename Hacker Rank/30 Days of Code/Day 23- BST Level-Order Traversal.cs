	
    //This method prints the BST in order going from left to right
    static void levelOrder(Node root){
  		//Create a queue of Nodes (queue is usefull here because it is FIFO)
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        
        //while the queue is not empty
        while(queue.Count != 0){
            //take the first in item and store it in a node
            Node curr = queue.Dequeue();
            
            //write the node data to console
            Console.Write(curr.data + " ");
            
            //if the curent node has a left child, add to queue
            if(curr.left != null){
                queue.Enqueue(curr.left);
            }
            
            //if the current node has a right child, add to the queue
            if(curr.right != null){
                queue.Enqueue(curr.right);
            }
        }
    }