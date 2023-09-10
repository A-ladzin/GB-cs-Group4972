
using System.Linq.Expressions;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


HomeWork a = new HomeWork();
// a.Task10();
// a.Task13starred();
Console.WriteLine(a.Task15());
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



    private static async Task<string> CallUrl(string fullUrl)
{
	HttpClient client = new HttpClient();
	var response = await client.GetStringAsync(fullUrl);
	return response;
}
    public bool Task15(){
        int n = int.Parse(Console.ReadLine()??"0");
        if (n < 1 || n > 7) Console.WriteLine("Дня недели нет");
        DateTime now = DateTime.Now;
        // now= new DateTime(2023,10,01);
        int month = now.Month;
        int dow = (int)now.DayOfWeek;
        if(dow == 0) dow = 7;
        int day = now.DayOfYear;
        int last_mon = day-dow+1;
        var url = "https://www.consultant.ru/law/ref/calendar/proizvodstvennye/2023/";

        String response = CallUrl(url).Result;
        int m = response.IndexOf("month");
        response = response.Substring(m+1,response.Length-m-1);
        for(int i = 1; i < month-1; i++){
            m = response.IndexOf("month");
            day_counter += DateTime.DaysInMonth(now.Year,i);
            response = response.Substring(m+1,response.Length-m-1);
        }


        removeEmpties(response);
        response = nextSlice(response,last_mon);

        day_counter = 1;
        response = nextSlice(response,n);

        if (response[0] == 'h' || response[0] == 'w') return true;

        return false;

    }

    private int day_counter = 0;

    public String removeEmpties(String response)
    {
    while(response[response.IndexOf("td class")+10] == 'i'){
            int next_cell = response.IndexOf("td class")+10;
            response = response.Substring(next_cell, response.Length-next_cell);
        }
        return response;
    }

    public String nextSlice(String response, int day_of_the_year)
    {
        while(day_counter < day_of_the_year){
        response = removeEmpties(response);
        int next_cell = response.IndexOf("td class")+10;
        response = response.Substring(next_cell, response.Length-next_cell);
            day_counter++;   
        }
        return response;

    }
    


}



