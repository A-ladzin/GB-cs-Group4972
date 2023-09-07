
String? input = Console.ReadLine();

int a = int.Parse(input);

if (a == 1){
    Console.WriteLine("Monday");
}



string dayOfTheWeek = System.Globalization.CultureInfo.GetCultureInfo("en-Us").DateTimeFormat.GetDayName((DayOfWeek)Enum.GetValues(typeof(DayOfWeek)).GetValue(a));

Console.WriteLine(dayOfTheWeek);


