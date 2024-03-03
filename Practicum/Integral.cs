using System;

public class TrapezoidalIntegration
{
    public static double CalculateIntegral(Func<double, double> func, double intervalStart, double intervalEnd, double dx)
    {
        double result = 0;
        int intervals = (int)((intervalEnd - intervalStart)/dx);
        
        for(int i = 0; i < intervals; i++)
        {
            double x1 = intervalStart + i * dx;
            double x2 = intervalStart + (i+1) * dx;
            double area = Math.Abs((func(x1) + func(x2))/ 2 * dx);
            result += area;
        }

        if (Math.Abs(result) < double.Epsilon)
        {
            throw new Exception("Результат близок к машинному нулю");
        }

        return result;
    }


    public static void Main()
    {
        Func<double, double> func = (double x) => -x * x + 9;
        double intervalStart = -3;
        double intervalEnd = 3;
        double dx = 0.1;
        

        try
        {
            double result = CalculateIntegral(func, intervalStart, intervalEnd, dx);
            Console.WriteLine("Результат: " + result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
