// See https://aka.ms/new-console-template for more information


int Square(int num){
    if(num <0) num = -num;
    int power = 0, result = 0, temp = num;

    while(temp >0){
        //  odd\even
        if((temp&1) > 0){
            // result+= num*(2^power)
            result += (num <<power); 

        }

        power++;
        // temp/=2;
        temp >>=1;

    }
    return result;
}





string inputNum = Console.ReadLine();

if(inputNum!=null)
{
    int num = int.Parse(inputNum);
    Console.WriteLine(Square(num));
}


