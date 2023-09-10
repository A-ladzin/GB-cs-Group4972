
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;



HomeWork a = new HomeWork();
a.Task10();

class HomeWork
{
    
    public int parseIntFromUser(int d) //Принимает желаемое количество знаков в качестве аргумента.
    {
        unsafe
        {

            Console.Write("Enter a");
            Console.WriteLine(" number.");
            String data = Console.ReadLine();
            fixed (char* ptr = data)
            {
                int index = 0;
                int num = 0;
                bool is_digit = false;
                bool sign = false;
                bool count = false;
                while ((int)*(ptr + index) != 0)
                {
                    if (d == 0) return sign?-num:num;
                    if (((int)*(ptr + index)) > 47 && ((int)*(ptr + index)) < 58)
                    {
                        if (is_digit)
                        {
                            num*=10;
                            count = true;
                        }
                        num += (((int)*(ptr + index)) - 48);
                        d--;
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
                if (!count)
                {
                    throw new ArgumentException("Not Enough Numbers.");

                }
                return sign?-num:num;
            }
        }
    }

    public void Task10(){
        
    }





}



