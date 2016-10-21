//Generic method to print array of generic type
static void printArray<T>(T[] arr){
    foreach(T t in arr){
        Console.WriteLine(t);
    }
}