namespace testout;

class Program
{
    static void Main(string[] args)
    {
        
        int sum2 = Sum(150, 150, out int sum);
        Console.WriteLine(sum2);
    }

    static int Sum(int a, int b, out int sum)
    {
        return sum = a + b;
    }
}

