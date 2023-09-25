using System.Collections.Generic;


int[] GenArray()
{
    int[] array = new int[123];

    for(int i = 0; i< num; i++)
    {
        array[i] = new Random().Next();
    }
    return array;
}


int Count(int[] arr){
    int count = 0;
    foreach(int i in arr){
        if(i > 9 && i < 100) return count++;
    }
    return count;
}







Console.WriteLine(Count(GenArray()));