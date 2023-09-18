using System.Numerics;

Calculator a = new Calculator();
a.Parser();

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


    private Queue<Action> ops = new Queue<Action>();
    private Queue<double> numbers = new Queue<double>();

    private void mult(){}
    private void sum(){}
    private void sub(){}
    private void div(){}
    private void pow(){}
    public void Parser()
    {
        unsafe
        {
            Console.Write("Enter an expression");
            String data = Console.ReadLine();
            fixed (char* ptr = data)
            {
                int corr = 0;
                double temp = 0;
                bool num = false;
                bool sign = false;
                bool point = false;
                int fixed_point_position = 0;
                while ((int)*(ptr + corr) != 0)
                {
                    if (((int)*(ptr + corr)) > 47 && ((int)*(ptr + corr)) < 58)
                    {
                        if (num)
                        {
                            if(point){
                                fixed_point_position *= 10;
                                temp+=(((int)*(ptr + corr)) - 48)/(10*fixed_point_position);
                            }
                            temp *= 10;
                        }
                        else
                        {
                            num = !num;
                        }
                        temp += (((int)*(ptr + corr)) - 48);
                  
                    }
                    else
                    {
                        if (num)
                        {
                            num = !num;
                            if(sign) temp*=-1;
                            numbers.Enqueue(temp);
                        if (((int)*(ptr + corr)) == 46){
                            point = true;
                            num = !num;
                            continue;
                        }
                        else if (((int)*(ptr + corr)) == 42)
                        {
                            ops.Enqueue(() => mult());
                        }
                        else if (((int)*(ptr + corr)) == 43)
                        {
                            ops.Enqueue(() => sum());
                        }
                         else if(((int)*(ptr + corr)) == 45){
                            ops.Enqueue(() => sub());
                        }
                        else if (((int)*(ptr + corr)) == 47)
                        {
                            ops.Enqueue(() => div());
                        }
                        else if (((int)*(ptr + corr)) == 94){
                            ops.Enqueue(() => pow());
                        }

                        else if (((int)*(ptr + corr)) == 32){}
                        else throw new ArgumentException("Something went wrong.");
                        sign = false;
                        point = false;
                        fixed_point_position = 0;
                        }
                        else if (((int)*(ptr + corr)) == 32){}
                        else if(((int)*(ptr + corr)) == 45){
                            sign = true;
                        }
                        else throw new ArgumentException("Something went wrong.");
                        temp = 0;
                    }
                    corr++;
                }
                Console.WriteLine(ops.Dequeue());
                Console.WriteLine(numbers.Dequeue());
                return;
            }
        }
    }
}


