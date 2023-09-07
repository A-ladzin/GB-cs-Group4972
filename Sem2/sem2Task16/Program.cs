int first_number = int.Parse(Console.ReadLine()??"0");
int second_number = int.Parse(Console.ReadLine()??"0");

Console.WriteLine((((first_number ^ (second_number*second_number))==0)|((second_number ^ (first_number*first_number))==0)^false));