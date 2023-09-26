﻿

Task t = new Task49();
t.Run();

abstract class Task
{
public static int[,] Gen2DArray(int axis0, int axis1, int low = -2147483648, int high = 2147483647)
{
    int[,] array = new int[axis0,axis1];
    for(int i = 0 ; i < axis0; i++){
        for(int j = 0;  j < axis1; j++)
        {
            array[i,j] = new Random().Next(low,high);
        }
    }
    return array;
}

public static void Print2DArray<T>(T[,] array)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.BackgroundColor = ConsoleColor.Black;
    Console.Write("[");
    for(int i = 0; i < array.GetLength(0)-1; i++){
            Console.Write("[");
    for(int j = 0; j < array.GetLength(1)-1; j++)
    {
    {
        Console.Write($"{array[i,j ]}, ");
    }
    }
    Console.Write($"{array[i,array.GetLength(1)-1]}],");
    Console.WriteLine();
    }
    Console.Write("[");
    for(int j = 0; j < array.GetLength(1)-1; j++)
    
    {
    {
        Console.Write($"{array[array.GetLength(0)-1,j]}, ");
        
    }
    }
    Console.Write($"{array[array.GetLength(1)-1,array.GetLength(1)-1]}]");
    Console.WriteLine("]");
}

    public static int ReadData(){
        return int.Parse(Console.ReadLine()??"0");
    }

abstract public void Run();
}


class Task48: Task
{
    int m = Task.ReadData();
    int n = Task.ReadData();
    

    private int[,] FillArray(int m, int n)
    {
        int [,] array = new int[m,n];
        for(int i = 0; i < m; i++){
            for (int j = 0; j< n; j++)
            {
                array[i,j] = i+j;
            }
        }
        return array;
    }

    public override void Run()
    {
        Task.Print2DArray<int>(FillArray(m,n));
    }

}


class Task49: Task

{
    private int[,] array = Gen2DArray(ReadData(),ReadData(), -1000,1000);
    
    private void squareEvens(int[,] array)
    {
        for(int i = 0; i < array.GetLength(0); i+=2)
        {
            for (int j = 0; j < array.GetLength(1); j+=2)
            {
                array[i,j] = array[i,j]*array[i,j];
            }
        }
    }

    public override void Run()
    {
        squareEvens(array);
        Task.Print2DArray<int>(array);
    }



}