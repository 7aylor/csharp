class Solution {
    //Write your code here
    public Stack<char> stack = new Stack<char>();
    public Queue<char> queue = new Queue<char>();
    
    void pushCharacter(char ch){
        stack.Push(ch);
    }
    void enqueueCharacter(char ch){
        queue.Enqueue(ch);
    }
    char popCharacter(){
        return stack.Pop();
    }
    char dequeueCharacter(){
        return queue.Dequeue();
    }