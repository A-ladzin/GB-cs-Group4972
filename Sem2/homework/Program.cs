
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;



HomeWork a = new HomeWork();
a.Task10();

class HomeWork
{
    
    public int parseIntFromUser(int d) //Принимает желаемое количество знаков в качестве аргумента, возвращает первое желаемое количество цифр единым числом.
    {
        unsafe
        {

            Console.Write("Enter a");
            Console.WriteLine(" number.");
            String data = Console.ReadLine()??"0";
            fixed (char* ptr = data)
            {
                int index = 0;
                int num = 0;
                bool is_digit = false;
                bool sign = false;
                bool count = false;
                while ((int)*(ptr + index) != 0)
                {
                    
                    if (((int)*(ptr + index)) > 47 && ((int)*(ptr + index)) < 58)
                    {
                        if (is_digit)
                        {
                            num*=10;
                            count = true;
                        }
                        num += (((int)*(ptr + index)) - 48);
                        d--;
                        if (d == 0) return sign?-num:num;
                        is_digit = true;

                    }
                    else
                    {
                        if (!count){
                        if (((int)*(ptr + index)) == 45)
                        {
                            sign = true;
                        }
                        }
                    }
                    index++;
                }
                throw new ArgumentException("Not Enough Digits.");
            }
        }
    }

    public void Task10(){
        Console.WriteLine(parseIntFromUser(3)/10%10);

    }





}



