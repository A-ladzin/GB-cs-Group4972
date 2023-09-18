using System.Numerics;

HomeWork a = new HomeWork();
Console.WriteLine(a.Task27(357));

class HomeWork{

        //TODO starred  - calculator;
    public BigInteger Task25(int A, int B){
        BigInteger result = 1;
        for(int i = 0; i < B; i++){
            result*=(BigInteger)A;
        }
        return result;
    }

        //TODO starred  - using string// 
    public int Task27(int n){
        int result = 0;
        while (n!=0){
            result+=n%10;
            n/=10;
        }
        return result;
    }



            //TODO random name choice;
}



class Calculator{
    
}

