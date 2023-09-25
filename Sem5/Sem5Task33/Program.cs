﻿int[] GenArray(int num, int lowBorder,int highBorder)
{
    int[] array = new int[num];

    for(int i = 0; i< num; i++)
    {
        array[i] = new Random().Next(lowBorder,highBorder+1);
    }
    return array;
}

void inverseArray(int[] arr){
    foreach(ref int i in arr){
        i *= -1;
    }

}



void PrintArray(int[] arr)
{
    foreach(int i in arr){
        Console.Write($"{i}, ");
    }
    Console.WriteLine();
    
}


(int, int, int) a = (int.Parse(Console.ReadLine()??"0"), int.Parse(Console.ReadLine()??"0"), int.Parse(Console.ReadLine()??"0"));
var arr = GenArray(a.Item1, a.Item2, a.Item3);
PrintArray(arr);
inverseArray(arr);
PrintArray(arr);