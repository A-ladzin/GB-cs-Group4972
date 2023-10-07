Task t;
t= new Task64();
t.Run();
abstract class Task{
    
    public static int ReadData(){
        return int.Parse(Console.ReadLine()??"0");
    }
    public abstract void Run();
}


class Task64:Task
{
    private void NextNuber(int n)
    {
        Console.Write($"{n}");
        if(n == 1) return;
        Console.Write(", ");
        NextNuber(n-1);
    }

    public override void Run()
    {
        Console.WriteLine("Enter a number: ");
        int N = ReadData();
        NextNuber(N);

    }

}


class Task66: Task
{
    public override void Run()
    {
        Console.WriteLine("Enter lower bound");
        int l = ReadData();
        Console.WriteLine("Enter upper bound");
        
    

    }

}