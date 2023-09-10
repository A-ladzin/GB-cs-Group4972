
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


HomeWork a = new HomeWork();
a.Task10();
a.Task13starred();

class HomeWork
{
    
    public long parseLongFromUser(int d) //Принимает желаемое количество знаков в качестве аргумента, возвращает первое желаемое количество цифр из строки ввода единым числом. 
    {
        unsafe
        {

            Console.Write("Enter a");
            Console.WriteLine(" number.");
            String data = Console.ReadLine()??"0";
            fixed (char* ptr = data)
            {
                int index = 0;
                long num = 0;
                bool sign = false;
                bool count = false;
                while (*(ptr + index) != 0)
                {
                    if(!count && *(ptr + index) == 48) {
                        index++;
                        continue;
                    }
                    if (*(ptr + index) > 47 && *(ptr + index) < 58)
                    {
                        if (count)
                        {
                            num*=10;
                            count = true;
                        }
                        num += *(ptr + index) - 48;
                        d--;
                        if (d == 0) return sign?-num:num;
                        count = true;

                    }
                    else
                    {
                        if (!count){
                        if (*(ptr + index) == 45)
                        {
                            sign = true;
                        }
                        }
                    }
                    index++;
                }
                if(d<0) {return sign?-num:num;}
                throw new ArgumentException("Not Enough Digits.");
                
            }
        }
    }

    public void Task10(){
        Console.WriteLine("Task 10");
        Console.WriteLine(parseLongFromUser(3)/10%10);

    }

    public void Task13starred(){
        Console.WriteLine("Task13");
        long number = parseLongFromUser(-1);
        long count = -3;
        long temp = number;
        while(temp!=0){
            temp/=10;
            count++;
        }
        if (count < 0){
            Console.WriteLine("There is no third digit");
            return;
        }
        
        for(int i = 0; i < count; i++){
            number /= 10;
        }
        Console.WriteLine(number%10);
        

    }

    public void Task15(){
        
    }


}



