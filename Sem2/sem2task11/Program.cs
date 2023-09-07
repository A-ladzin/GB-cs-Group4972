// See https://aka.ms/new-console-template for more information

int task(){
    System.Random numGen = new Random();
    
    int a = numGen.Next(100,1000);
    Console.WriteLine(a);
    return (a/100*10+a%10);
}


Console.WriteLine(task());