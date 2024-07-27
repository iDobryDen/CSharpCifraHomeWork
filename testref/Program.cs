namespace testref;

class Program
{
    static void Main(string[] args)
    {
        
        int age = 0;
        Increment(ref age);
        Console.WriteLine(age);
    }

    static void Increment (ref int value)
    {
        
        value++;
        
    }
}

