	static int getHeight(Node root){
      //Write your code here
        if(root == null){
            return -1;
        }
        int leftDepth = getHeight(root.left);
        int rightDepth = getHeight(root.right);
        
        return (leftDepth > rightDepth ? leftDepth : rightDepth) + 1;
    }
  