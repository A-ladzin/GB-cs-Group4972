
abstract class Program<T,D>
{
    public abstract D func(T data);
}

class Program12 : Program<int,int>
{
    public override int func(int count)
    {
        unsafe
        {
            Console.Write("Enter ");
            Console.Write(count);
            Console.WriteLine(" numbers.");
            String data = Console.ReadLine();
            fixed (char* ptr = data)
            {
                int corr = 0;
                int temp = 0;
                int max = -0b1111111111111111111111111111111 - 1;
                bool num = false;
                bool sign = false;
                while ((int)*(ptr + corr) != 0 && count > 0)
                {
                    if (((int)*(ptr + corr)) > 47 && ((int)*(ptr + corr)) < 58)
                    {
                        if (num)
                        {
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
                            max = max < temp ? temp : max;
                            count--;
                        }
                        if(((int)*(ptr + corr)) == 45){
                            sign = true;
                        }
                        else sign = false;
                        temp = 0;
                    }
                    corr++;
                }
                if (num)
                {
                    num = !num;
                    if(sign) temp*=-1;
                    max = max < temp ? temp : max;
                    count--;
                }
                if (count > 0)
                {
                    throw new ArgumentException("Not Enough Numbers.");
        
                }
                return max;
            }
        }
    }
}


class Program6 : Program<int,bool>
{
    private bool result;


    public Program6() {
        Program12 parseInt = new Program12();
        result = func(parseInt.func(1));

    }
    public bool GetResult() { return result;  }

    public override bool func(int num)
    {
        return num % 2 == 0;
    }
}

class Program8: Program<int, List_>
{
    private List_ result;
    
    public Program8()
    {
        Program12 parseInt = new Program12();
        result = func(parseInt.func(1));
    }

    public List_ GetResult()
    {
        return result;
    }
    public override List_ func(int n)
    {
        List_ ns;
        if(n < 2) {
            return new List_();
        };
        if (n % 2 == 1) n--;
        if (n > 2)
        {
            ns = func(n-2);
            ns.push(n);
        }
        else
        {
            ns = new List_();
            ns.push(n);
        }
        return ns;
    }
    
}




public class List_
{
  
    public class Node
    {
    
        public Node(int val){
            this.val = val;
        }
        public int val;
        public Node next = null;
    }

    public void push(int val){
        if (head == null){
            head = new Node(val);
            tail = head;
        }
        else{
        tail.next = new Node(val);
        tail = tail.next;
        }
    }
    public Node head = null;
    public Node tail = null;




}


public class Homework
{

    public static void Main()
    {
        Program12 program2 = new Program12();
        int a = program2.func(2);
        Console.Write("Program 1: max -> ");
        Console.WriteLine(a);
        Program12 program4 = new Program12();
        a = program4.func(3);
        Console.Write("Program 2: -> ");
        Console.WriteLine(a);
        Program6 program6 = new Program6();
        Console.Write("Program 6: -> ");
        Console.WriteLine(program6.GetResult());
        Program8 program8 = new Program8();
        Console.Write("Program 8: -> ");
        List_.Node curr = program8.GetResult().head;
        while(curr != null)
        {
            Console.Write(curr.val);
            Console.Write(' ');
            curr = curr.next;
        }

    }
}



