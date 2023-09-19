using System.Numerics;

Calculator a = new Calculator();
double result = a.Calculate();
Console.WriteLine();
Console.WriteLine($"RESULT: {result}");

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


    static private Queue<Action<Calculator>> ops = new Queue<Action<Calculator>>();
    static private Queue<double> numbers = new Queue<double>();

    private bool recursive;
    private int priority = 0;
    public Calculator(Calculator other, int priority)
    {
        this.priority = priority;
        first_number = numbers.Dequeue();
        recursive = true;
        Console.WriteLine("Copied");
    }

    public Calculator(){
        recursive = false;
        priority = 0;
    }


    private double first_number;
    private double second_number;
    static private void mult(Calculator obj){
        obj.first_number =  obj.first_number*obj.second_number;
    }
    static private void sum(Calculator obj){
        obj.first_number = obj.first_number+obj.second_number;
    }
    static private void sub(Calculator obj){
        obj.first_number = obj.first_number-obj.second_number;
    }
    static private void div(Calculator obj){
        obj.first_number = obj.first_number/obj.second_number;
    }
    static private void pow(Calculator obj){
        double temp = 1;
        for(int i = 0; i < obj.second_number; i++)
        {
            temp*= obj.first_number;
        }
        obj.first_number = temp;
    }
    private void Parser()
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
                int fixed_point_position = 1;
                while ((int)*(ptr + corr) != 0)
                {
                    if (((int)*(ptr + corr)) > 47 && ((int)*(ptr + corr)) < 58)
                    {
                        if (num)
                        {
                            if(point){
                                fixed_point_position *= 10;
                                
                            }
                            else temp *= 10;
                        }
                        else
                        {
                            num = !num;
                        }
                        temp+=((((double)*(ptr + corr)) - 48)/fixed_point_position);
                  
                    }
                    else
                    {
                        if (num)
                        {
                            num = !num;
                            if(sign) temp*=-1;
                            sign = false;
                        if (((int)*(ptr + corr)) == 46){
                            point = true;
                            num = !num;
                            corr++;
                            continue;
                        }
                        else if (((int)*(ptr + corr)) == 32){
                            num = !num;
                            corr++;
                            continue;
                        }
                            numbers.Enqueue(temp);

                        if (((int)*(ptr + corr)) == 42)
                        {
                            Action<Calculator> tempA = mult;
                            ops.Enqueue(tempA);
                        }
                        else if (((int)*(ptr + corr)) == 43)
                        {
                            Action<Calculator> tempA = sum;
                            ops.Enqueue(tempA);
                        }
                         else if(((int)*(ptr + corr)) == 45){
                            Action<Calculator> tempA = sub;
                            ops.Enqueue(tempA);
                        }
                        else if (((int)*(ptr + corr)) == 47)
                        {
                            Action<Calculator> tempA = div;
                            ops.Enqueue(tempA);
                        }
                        else if (((int)*(ptr + corr)) == 94){
                            Action<Calculator> tempA = pow;
                            ops.Enqueue(tempA);
                        }


                        else throw new ArgumentException("Something went wrong.");
                        sign = false;
                        point = false;
                        fixed_point_position = 1;
                        }
                        else if (((int)*(ptr + corr)) == 32){
                            corr++;
                            continue;
                        }
                        else if(((int)*(ptr + corr)) == 45){
                            sign = true;
                        }
                        else throw new ArgumentException("Something went wrong.");
                        temp = 0;
                    }
                    corr++;
                }
                    if (num)
                        {
                            if(sign) temp*=-1;
                            numbers.Enqueue(temp);
                        }
                        else throw new ArgumentException("Something went wrong.");
                return;
            }
        }
    }// End Parser

    public double Calculate()
    {
        
        if(!recursive) {
            Parser();
            first_number = numbers.Dequeue();
        }
        Console.WriteLine(ops.Count());

        
        while(numbers.Count() > 0){

    
            if (ops.Peek().Method.Name == "pow"){
                Console.WriteLine("Pow");
                priority = 2;
                second_number = numbers.Dequeue();
                ops.Dequeue()(this);
                Console.WriteLine($"Returned pow: {second_number}");
                
            }

            else if(ops.Peek().Method.Name == "mult" || ops.Peek().Method.Name == "div"){
                Console.WriteLine("Mult");
                Console.WriteLine(first_number);
                if(priority> 1) return first_number;
                Action<Calculator> tempMethod = ops.Dequeue();
                if(ops.Count == 0){
                    second_number = numbers.Dequeue();
                    tempMethod(this);
                    break;
                }
                if(ops.Peek().Method.Name == "pow") {
                    second_number = new Calculator(this,1).Calculate();
                    tempMethod(this);
                }
                else{
                    second_number = numbers.Dequeue();
                    tempMethod(this);
                }
                Console.WriteLine($"Returned mult: {second_number}");

            }
            else {
                Console.WriteLine("Sum");
                if(priority> 0) return first_number;
                Action<Calculator> tempMethod = ops.Dequeue();
                if(ops.Count == 0){
                    second_number = numbers.Dequeue();
                    tempMethod(this);
                    break;
                }
                if(ops.Peek().Method.Name != "sum" && ops.Peek().Method.Name != "sub") {
                    second_number = new Calculator(this,0).Calculate();
                    tempMethod(this);
                }
                else{
                    second_number = numbers.Dequeue();
                    tempMethod(this);
                }
                
                Console.WriteLine($"Returned sum: {second_number}");
            }
            Console.WriteLine("Operated");

        
    }

    return first_number;



}
}


