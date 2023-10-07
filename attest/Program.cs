new Task64();
new Task66();
new Task68();
abstract class Task{
    
    protected int ReadData(){
        return int.Parse(Console.ReadLine()??"0");
    }
}


class Task64:Task
{
    public Task64() {Console.WriteLine("\tTask64\n"); Run();}
    void NextNuber(int n)
    {
        Console.Write($"{n}");
        if(n == 1) return;
        Console.Write(", ");
        NextNuber(n-1);
    }

    void Run()
    {
        Console.WriteLine("Enter a number: ");
        int N = ReadData();
        NextNuber(N);
        Console.WriteLine();

    }

}


class Task66: Task
{
    public Task66() {Console.WriteLine("\tTask66\n"); Run();}

    void Run()
    {
        Console.WriteLine("Enter lower bound");
        int l = ReadData();
        Console.WriteLine("Enter upper bound");
        int h = ReadData();
        int sum = 0;
        for(int i = l; i < h+1; ++i)
        {
            sum+=i;
        }
        Console.WriteLine(sum);
    }
}


class Task68: Task
{
    public Task68() {Console.WriteLine("\tTask68\n"); Run();}

    uint ackermann(uint m, uint n)
            {
            if (m == 0) return n + 1;
            if (n == 0) return ackermann(m - 1, 1);
            return ackermann(m - 1, ackermann(m, n - 1));
            }

    void Run()
    {
        Console.WriteLine("Enter m");
        uint m = uint.Parse(Console.ReadLine()??"0");
        Console.WriteLine("Enter n");
        uint n = uint.Parse(Console.ReadLine()??"0");
        Console.WriteLine(ackermann(m,n));

    }

}