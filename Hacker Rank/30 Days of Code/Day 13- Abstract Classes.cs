//Write MyBook class

class MyBook : Book {
    
    protected int price = 0;
    
    //MyBook Contructor that extends the base Book class constructor
    public MyBook(string title, string author, int price) : base(title, author){
        this.price = price;
    }
    
    //overrides the abstract base class's method for display
    public override void display(){
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Author: " + this.author);
        Console.WriteLine("Price: " + this.price);
    }