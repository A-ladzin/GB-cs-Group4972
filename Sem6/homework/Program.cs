HomeTask t;
t = new Task41();
t = new Task43();


abstract class HomeTask
{
    public static void PrintArray<T>(T[] array)
    {
        Console.Write("[");
        for (int i = 0; i < array.Length - 1; i++)
        {
            Console.Write($"{array[i]}, ");
        }
        Console.Write($"{array[array.Length - 1]}]");
        Console.WriteLine();
    }

    public static int ReadData()
    {
        return int.Parse(Console.ReadLine() ?? "0");
    }

}


class Task43 : HomeTask
{
    public Task43()
    {
        Console.WriteLine("\t*Task43*\n");
        new Triangle();
    }



    private class Triangle
    {


        int b1, k1, b2, k2, b3, k3;
        public Triangle()
        {
            Console.WriteLine("Enter b1: ");
            b1 = HomeTask.ReadData();
            Console.WriteLine("Enter k1: ");
            k1 = HomeTask.ReadData();
            Console.WriteLine("Enter b2: ");
            b2 = HomeTask.ReadData();
            Console.WriteLine("Enter k2: ");
            k2 = HomeTask.ReadData();
            Console.WriteLine("Enter b3: ");
            b3 = HomeTask.ReadData();
            Console.WriteLine("Enter k3: ");
            k3 = HomeTask.ReadData();
            dots[0] = findIntersection(b1, k1, b2, k2);
            dots[1] = findIntersection(b1, k1, b3, k3);

            dots[2] = findIntersection(b2, k2, b3, k3);
            Console.Write("Area of the triangle is: ");
            Console.WriteLine(0.5 * Math.Abs((dots[1].Item1 - dots[0].Item1) * (dots[2].Item2 - dots[1].Item2) - (dots[2].Item1 - dots[0].Item1) * (dots[1].Item2 - dots[0].Item2)));
        }
        private (double, double)[] dots = new (double, double)[3];

        private (double, double) findIntersection(int b1, int k1, int b2, int k2)
        {

            (double, double) dot;
            dot.Item1 = (double)(b1 - b2) / (k1 - k2);
            dot.Item2 = (double)k1 * dot.Item1 + b1;
            return dot;
        }



    }
}


class Task41: HomeTask
{
    public Task41(){
        Console.WriteLine("\tTask41\n");
        Console.WriteLine("Enter integers comma-separated: ");
        string[] s = Console.ReadLine().Split(",");
        int count = 0;
        for(int i = 0; i < s.Length; i++)
        {
            if(int.Parse(s[i])>0) count++;
        }
        Console.WriteLine(count);
        
    }
}